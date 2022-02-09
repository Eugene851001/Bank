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
        }

        public override void CloseBankDay()
        {
            var system = this.db.SystemVariables.Find((byte)1);
            var currentDate = system.CurrentDate;

            var credits = this.db.Credits
                .Where(credit => credit.StartDate >= currentDate && credit.EndDate <= currentDate)
                .ToArray();

            foreach (var credit in credits)
            {
                AccrualOfInterest(credit);
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

        private void AccrualOfInterest(Credit contract)
        {
            int totalDays = (contract.EndDate - contract.StartDate).Days;
            decimal sum = contract.Sum * (decimal)(contract.Percent / (totalDays * 100));

            if (contract.Annuity)
            {
                sum += contract.Sum;
            }

            var bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            this.transactionsService.CommitTransaction(contract.PercentAccountNavigation, bankAccount, sum);
        }
    }
}
