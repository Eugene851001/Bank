using BankAPI.Helpers;
using BankDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class TransactionsService
    {
        private readonly IBankContext db;
        private readonly SystemService systemService;

        public TransactionsService(IBankContext db, SystemService systemService)
        {
            this.db = db;
            this.systemService = systemService;
        }

        public void CommitTransaction(Account source, Account destination, decimal sum)
        {
            if (source.Active == Constants.Accounts.Active)
            {
                source.Credit += sum;
            }
            else
            {
                source.Debit += sum;
            }

            if (destination.Active == Constants.Accounts.Active)
            {
                destination.Debit += sum;
            }
            else
            {
                destination.Credit += sum;
            }

            var transasction = new Transaction() 
            {
                Source = source.Id,
                Destination = destination.Id,
                Sum = sum,
                Time = this.systemService.CurrentDate,
            };

            this.db.Transactions.Add(transasction);

            this.db.SaveChanges();
        }

        public void WithdrawFromCashRegister(decimal sum)
        {
            var account = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            account.Credit += sum;

            this.db.SaveChanges();
        }

        public void TrunsferToCashRegister(decimal sum)
        {
            var account = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.CashRegister);

            account.Debit += sum;

            this.db.SaveChanges();
        }
    }
}
