using BankAPI.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankDatabase;
using BankAPI.Helpers;

namespace BankAPI.Services
{
    public class CreditsService: ContractService
    {
        private readonly AccountsService accountsService;
        private readonly IBankContext db;
        private readonly TransactionsService transactionsService;

        public CreditsService(
            IBankContext db, 
            AccountsService accountsService,
            TransactionsService transactionsService)
        {
            this.db = db;
            this.accountsService = accountsService;
            this.transactionsService = transactionsService;
        }

        public override void CloseBankDay()
        {
            var system = this.db.SystemVariables.Find((byte)1);
            var currentDate = system.CurrentDate;

            var credits = this.db.Credits
                .Where(credit => credit.StartDate <= currentDate && credit.EndDate >= currentDate)
                .ToArray();

            foreach (var credit in credits)
            {
                AccrualOfInterest(credit);

                if (credit.StartDate != currentDate 
                    && (currentDate - credit.StartDate).Days % Constants.Intervals.Month == 0)
                {
                    PayPercents(credit);
                    PayMainSum(credit, Constants.Intervals.Month);
                }

                if (credit.EndDate == currentDate)
                {
                    CloseCredit(credit);
                }
            }
        }

        public void Create(CreateCreditRequest request)
        {
            CreditPlan plan = this.db.CreditPlans.Find(request.CreditPlan);

            var credit = new Credit()
            {
                StartDate = request.StartDate,
                EndDate = request.StartDate.AddDays(plan.Duration),
                Sum = request.Sum,
                Annuity = plan.Annuity,
                Percent = plan.Percent,
                Currency = 1,
                CreditPlan = plan.Id,
            };

            var accounts = this.accountsService.AddCreditsAccounts(credit.Currency, request.User);

            credit.MainAccount = accounts.MainAccountId;
            credit.PercentAccount = accounts.PercentAccountId;

            this.db.Credits.Add(credit);
            this.db.SaveChanges();

            var cashRegister = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            this.transactionsService.CommitTransaction(bankAccount, credit.MainAccountNavigation, credit.Sum);
            this.transactionsService.CommitTransaction(credit.MainAccountNavigation, cashRegister, credit.Sum);
            this.transactionsService.WithdrawFromCashRegister(credit.Sum);
        }

        public void PayPercents(Credit credit)
        {
            decimal sum = Math.Abs(credit.PercentAccountNavigation.Balance.Value);
            var cashAccount = this.accountsService.GetCashAccount();
            var creditAccount = credit.PercentAccountNavigation;

            this.transactionsService.TrunsferToCashRegister(sum);
            this.transactionsService.CommitTransaction(cashAccount, creditAccount, sum);
        }

        private void PayMainSum(Credit credit, int interval)
        {
            decimal sum = credit.Sum * interval / (credit.EndDate - credit.StartDate).Days;
            var cashAccount = this.accountsService.GetCashAccount();
            var mainAccount = credit.MainAccountNavigation;

            this.transactionsService.TrunsferToCashRegister(sum);
            this.transactionsService.CommitTransaction(cashAccount, mainAccount, sum);
        }

        public void CloseCredit(Credit credit)
        {
            var bankAccount = this.accountsService.GetBankAccount();
            var cashAccount = this.accountsService.GetCashAccount();
            var mainAccount = credit.MainAccountNavigation;
            var percentAccount = credit.PercentAccountNavigation;

            decimal mainSum = credit.Sum - mainAccount.Balance.Value;
            if (mainSum != 0)
            {
                this.transactionsService.TrunsferToCashRegister(mainSum);
                this.transactionsService.CommitTransaction(cashAccount, mainAccount, mainSum);
            }

            decimal percentSum = Math.Abs(percentAccount.Balance.Value);
            if (percentSum != 0)
            {
                this.transactionsService.TrunsferToCashRegister(percentSum);
                this.transactionsService.CommitTransaction(cashAccount, percentAccount, percentSum);
            }

            this.transactionsService.CommitTransaction(mainAccount, bankAccount, credit.Sum);

            credit.Sum = 0;
            this.db.SaveChanges();
        }

        private void AccrualOfInterest(Credit contract)
        {
            int totalDays = (contract.EndDate - contract.StartDate).Days;
            decimal sum = contract.Sum * (decimal)(contract.Percent / (totalDays * 100));

            if (contract.Annuity)
            {
                sum = contract.Sum * (decimal)(contract.Percent / (totalDays * 100));
            }
            else
            {
                sum = (contract.Sum - contract.MainAccountNavigation.Balance.Value) *
                    (decimal)(contract.Percent / (totalDays * 100));
            }

            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            this.transactionsService.CommitTransaction(contract.PercentAccountNavigation, bankAccount, sum);
        }
    }
}
