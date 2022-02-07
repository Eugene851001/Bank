using BankAPI.DTO.Requests;
using BankAPI.Helpers;
using BankDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class DepositsService
    {
        private readonly IBankContext db;
        private readonly AccountsService accountsService;


        private readonly TransactionsService transactionsService;
    
        public DepositsService(
            IBankContext db, 
            TransactionsService transactionsService,
            AccountsService accountsService)
        {
            this.db = db;
            this.transactionsService = transactionsService;
            this.accountsService = accountsService;
        }

        public void Create(Contract contract, int userId)
        {
            this.db.Contracts.Add(contract);
            this.db.SaveChanges();

            this.accountsService.AddDepositAccounts(contract, userId);

            var mainAccount = contract.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.Current);

            var cashAccount = this.db.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            var bankAccount = this.db.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            this.transactionsService.TrunsferToCashRegister(contract.Sum);
            this.transactionsService.CommitTransaction(cashAccount, mainAccount, contract.Sum);
            this.transactionsService.CommitTransaction(mainAccount, bankAccount, contract.Sum);
        }

        public void CloseBankDay(DateTime currentDate)
        {
            var contracts = this.db.Contracts
                .Where(contract => contract.StartDate <= currentDate
                    && contract.EndDate >= currentDate)
                .ToArray();

            foreach (var contact in contracts)
            {
                CommitPercents(contact);
            } 
        }

        public void WithdrawPercents(int depositId, DateTime currentDate)
        {
            var contract = this.db.Contracts.Find(depositId);

            var account = contract.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.Credit);

            if (!contract.Revocable)
            {
                throw new ArgumentException("Can not withdraw money from not revocable service");
            }

            if (contract.StartDate > currentDate || contract.EndDate < currentDate)
            {
                throw new ArgumentException("This deposit is not active");
            }

            if (contract.StartDate.Day != currentDate.Day)
            {
                throw new ArgumentException("The percent can be withrowed only once a month");
            }

            var cashRegisterAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            decimal sum = (decimal)account.Balance;
            this.transactionsService.CommitTransaction(account, cashRegisterAccount, sum);
            this.transactionsService.WithdrawFromCashRegister(sum);
        }


        public void CloseDeposit(int contractId, DateTime currentDate)
        {
            var contract = this.db.Contracts.Find(contractId);

            if (!contract.Revocable && contract.EndDate > currentDate)
            {
                throw new ArgumentException("You can not close deposit until it ends");
            }

            var cashAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            var mainAccount = contract.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.Current);

            var creditAccount = contract.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.Credit);

            decimal totalSum = mainAccount.Balance.Value + creditAccount.Balance.Value;

            this.transactionsService.CommitTransaction(bankAccount, mainAccount, contract.Sum);

            this.transactionsService.CommitTransaction(mainAccount, cashAccount, mainAccount.Balance.Value);

            this.transactionsService.CommitTransaction(creditAccount, cashAccount, creditAccount.Balance.Value);

            this.transactionsService.WithdrawFromCashRegister(totalSum);
        }

        private void CommitPercents(Contract contract)
        {
            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);
            var percentAccount = contract.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.Credit);

            //int daysPassed = (currentDate - contract.StartDate).Days;
            decimal sum = contract.Sum * (decimal)contract.Percent / ((contract.EndDate - contract.StartDate).Days * 100);

            this.transactionsService.CommitTransaction(bankAccount, percentAccount, sum);
        }
    }
}
