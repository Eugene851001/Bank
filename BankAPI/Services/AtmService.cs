using BankDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class AtmService
    {
        private readonly IBankContext db;
        private readonly TransactionsService transactionsService;
        private readonly AccountsService accountsService;

        public AtmService(
            IBankContext db, 
            TransactionsService transactionsService, 
            AccountsService accountsService)
        {
            this.db = db;
            this.transactionsService = transactionsService;
            this.accountsService = accountsService;
        }

        public void WithdrawMoney(string cardNumber, decimal sum)
        {
            Card card = this.db.Cards.Find(cardNumber);

            Account cashAccount = this.accountsService.GetCashAccount();
            Account creditAccount = card.AccountNavigation;

            if (sum > creditAccount.Balance)
            {
                throw new InvalidOperationException("Not enough money in account");
            }

            this.transactionsService.CommitTransaction(creditAccount, cashAccount, sum);
            this.transactionsService.WithdrawFromCashRegister(sum);
        }

        public void TransferMoney(string cardNumber, string accountNumber, decimal sum)
        {
            var card = this.db.Cards.Find(cardNumber);
            var sourceAccount = card.AccountNavigation;
            var destinationAccount = this.db.Accounts.FirstOrDefault(ac => ac.Number == accountNumber);

            if (destinationAccount == null)
            {
                throw new ArgumentException($"Account with number {accountNumber} is not found");
            }

            if (sourceAccount.Balance < sum)
            {
                throw new ArgumentException("Not enough money");
            }

            this.transactionsService.CommitTransaction(sourceAccount, destinationAccount, sum);
        }
    }
}
