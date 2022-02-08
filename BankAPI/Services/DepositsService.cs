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

        public void Create(CreateDepositRequest request)
        {
            var plan = this.db.DepositsPlans.Find(request.DepositPlan);

            var contract = new Deposit()
            {
                StartDate = request.StartDate,
                EndDate = request.StartDate.AddDays(plan.Duration),
                Sum = request.Sum,
                Percent = plan.Percent,
                Currency = plan.Currency,
                Revocable = plan.Revocable,
                DepositPlan = request.DepositPlan,
            };

            this.accountsService.AddDepositAccounts(contract, request.User);

            this.db.Deposits.Add(contract);
            this.db.SaveChanges();

            var mainAccount = contract.MainAccountNavigation;

            var cashAccount = this.db.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            var bankAccount = this.db.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            this.transactionsService.TrunsferToCashRegister(contract.Sum);
            this.transactionsService.CommitTransaction(cashAccount, mainAccount, contract.Sum);
            this.transactionsService.CommitTransaction(mainAccount, bankAccount, contract.Sum);
        }

        public void CloseBankDay(DateTime currentDate)
        {
            var contracts = this.db.Deposits
                .Where(contract => contract.StartDate <= currentDate
                    && contract.EndDate >= currentDate)
                .ToArray();

            foreach (var contact in contracts)
            {
                CommitPercents(contact);

                if ((currentDate - contact.StartDate).Days == Constants.Intervals.Month)
                {
                    WithdrawCash(contact);
                }
            }

            var system = this.db.SystemVariables.Find(1);

            system.CurrentDate = system.CurrentDate.AddDays(1);
            this.db.SaveChanges();
        }

        public void WithdrawPercents(int depositId, DateTime currentDate)
        {
            var contract = this.db.Deposits.Find(depositId);

            var account = contract.PercentAccountNavigation;

            if (!contract.Revocable)
            {
                throw new ArgumentException("Can not withdraw money from not revocable deposit");
            }

            if (contract.StartDate > currentDate || contract.EndDate < currentDate || contract.Sum == 0)
            {
                throw new ArgumentException("This deposit is not active");
            }

            var cashRegisterAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            decimal sum = (decimal)account.Balance;
            this.transactionsService.CommitTransaction(account, cashRegisterAccount, sum);
            this.transactionsService.WithdrawFromCashRegister(sum);
        }


        public void CloseDeposit(int contractId, DateTime currentDate)
        {
            var contract = this.db.Deposits.Find(contractId);

            if (!contract.Revocable && contract.EndDate > currentDate)
            {
                throw new ArgumentException("You can not close deposit until it ends");
            }

            var cashAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            var mainAccount = contract.MainAccountNavigation;

            var creditAccount = contract.PercentAccountNavigation;

            decimal totalSum = mainAccount.Balance.Value + creditAccount.Balance.Value;

            this.transactionsService.CommitTransaction(bankAccount, mainAccount, contract.Sum);

            this.transactionsService.CommitTransaction(mainAccount, cashAccount, mainAccount.Balance.Value);

            this.transactionsService.CommitTransaction(creditAccount, cashAccount, creditAccount.Balance.Value);

            this.transactionsService.WithdrawFromCashRegister(totalSum);

            contract.Sum = 0;
        }

        private void CommitPercents(Deposit contract)
        {
            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);
            var percentAccount = contract.PercentAccountNavigation;

            //int daysPassed = (currentDate - contract.StartDate).Days;
            decimal sum = GetDayliSum(contract);

            this.transactionsService.CommitTransaction(bankAccount, percentAccount, sum);
        }

        private void WithdrawCash(Deposit contract)
        {
            var cashAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            decimal sum = GetDayliSum(contract) * Constants.Intervals.Month;
            this.transactionsService.CommitTransaction(contract.PercentAccountNavigation, cashAccount, sum);
        }

        private static decimal GetDayliSum(Deposit contract) =>
            contract.Sum * (decimal)contract.Percent / ((contract.EndDate - contract.StartDate).Days * 100);
    }
}
