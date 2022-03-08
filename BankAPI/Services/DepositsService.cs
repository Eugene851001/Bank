using BankAPI.DTO.Requests;
using BankAPI.Helpers;
using BankDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class DepositsService: ContractService
    {
        private readonly IBankContext db;
        private readonly AccountsService accountsService;
        private readonly SystemService systemService;

        private readonly TransactionsService transactionsService;
    
        public DepositsService(
            IBankContext db, 
            TransactionsService transactionsService,
            AccountsService accountsService,
            SystemService systemService)
        {
            this.db = db;
            this.transactionsService = transactionsService;
            this.accountsService = accountsService;
            this.systemService = systemService;
        }

        public void Create(CreateDepositRequest request)
        {
            if (request.Sum <= 0)
            {
                throw new ArgumentException("Sum should be more than zero");
            }

            var plan = this.db.DepositsPlans.Find(request.DepositPlan);

            if (plan.MinValue.HasValue && plan.MinValue.Value > request.Sum)
            {
                throw new ArgumentException($"Sum should be from {plan.MinValue.Value}");
            }

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

            var accounts = this.accountsService.AddDepositAccounts(contract.Currency, request.User);

            contract.MainAccount = accounts.MainAccountId;
            contract.PercentAccount = accounts.PercentAccountId;
            this.db.Deposits.Add(contract);
            this.db.SaveChanges();

            var mainAccount = contract.MainAccountNavigation;

            var cashAccount = this.db.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            var bankAccount = this.db.Accounts.FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            this.transactionsService.TrunsferToCashRegister(contract.Sum);
            this.transactionsService.CommitTransaction(cashAccount, mainAccount, contract.Sum);
            this.transactionsService.CommitTransaction(mainAccount, bankAccount, contract.Sum);
        }

        public override void CloseBankDay()
        {
            var currentDate = this.systemService.CurrentDate;

            var contracts = this.db.Deposits
                .Where(contract => contract.StartDate <= currentDate
                    && contract.EndDate >= currentDate
                    && contract.Sum > 0)
                .ToArray();

            foreach (var contact in contracts)
            {
                CommitPercents(contact);

                if (currentDate != contact.StartDate &&  
                    (currentDate - contact.StartDate).Days % Constants.Intervals.Month == 0)
                {
                    WithdrawCashMonthly(contact);
                }

                if (currentDate == contact.EndDate)
                {
                    CloseDeposit(contact.Id);
                }
            }
        }

        public void WithdrawPercents(int depositId)
        {
            var currentDate = this.systemService.CurrentDate;

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


        public void CloseDeposit(int contractId)
        {
            var currentDate = this.systemService.CurrentDate;

            var contract = this.db.Deposits.Find(contractId);

            if (!contract.Revocable && contract.EndDate > currentDate)
            {
                throw new ArgumentException("You can not close deposit until it ends");
            }

            if (contract.Sum == 0)
            {
                throw new ArgumentException("This deposit is alreday closed");
            }

            var cashAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            var mainAccount = contract.MainAccountNavigation;

            var creditAccount = contract.PercentAccountNavigation;

            this.transactionsService.CommitTransaction(bankAccount, mainAccount, contract.Sum);
            this.transactionsService.CommitTransaction(mainAccount, cashAccount, mainAccount.Balance.Value);
            this.transactionsService.CommitTransaction(creditAccount, cashAccount, creditAccount.Balance.Value);
            this.transactionsService.WithdrawFromCashRegister(cashAccount.Balance.Value);

            contract.Sum = 0;
            this.db.SaveChanges();
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

        private void WithdrawCashMonthly(Deposit contract)
        {
            var cashAccount = this.accountsService.GetCashAccount();

            decimal sum = GetDayliSum(contract) * Constants.Intervals.Month;
            this.transactionsService.CommitTransaction(contract.PercentAccountNavigation, cashAccount, sum);
            this.transactionsService.WithdrawFromCashRegister(sum);
        }

        private static decimal GetDayliSum(Deposit contract) =>
            contract.Sum * (decimal)contract.Percent / (Constants.Intervals.Year * 100);
    }
}
