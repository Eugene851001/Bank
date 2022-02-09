using BankAPI.DTO.Requests;
using BankAPI.Helpers;
using BankAPI.Services.Model;
using BankDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class AccountsService
    {
        private readonly IBankContext db;

        public AccountsService(IBankContext bankContext)
        {
            this.db = bankContext;
        }

        public string GetAccountNumber(int accountType)
        {
            string code = accountType switch
            {
                Constants.AccountTypes.Current => "3014",
                Constants.AccountTypes.Credit => "2400",
                Constants.AccountTypes.CashRegister => "1010",
                Constants.AccountTypes.DevelopmentFund => "7327",
                _ => "0000"
            };

            var guid = Guid.NewGuid();

            return $"{code}{guid.ToString().Substring(0, 9)}";
        }

        public AddedAccounts AddDepositAccounts(byte currency, int userId) =>
            AddContractAccounts(Constants.Accounts.Passive, currency, userId);

        public AddedAccounts AddCreditsAccounts(byte currency, int userId) =>
            AddContractAccounts(Constants.Accounts.Active, currency, userId);

        private AddedAccounts AddContractAccounts(byte activity, byte currency, int userId)
        {
            var accountCurrent = new Account()
            {
                Owner = userId, 
                Active = activity,
                AccountType = Constants.AccountTypes.Current,
                Credit = 0,
                Debit = 0,
                Number = GetAccountNumber(Constants.AccountTypes.Current),
                Code = "",
                Currency = currency,
            };

            var accountPercent = new Account()
            {
                Owner = userId,
                Active = activity,
                AccountType = Constants.AccountTypes.Credit,
                Credit = 0,
                Debit = 0,
                Number = GetAccountNumber(Constants.AccountTypes.Credit),
                Code = "",
                Currency = currency,
            };

            //TODO: improve trigger to work when add multiple values
            this.db.Accounts.Add(accountCurrent);
            this.db.SaveChanges();

            this.db.Accounts.Add(accountPercent);
            this.db.SaveChanges();

            return new AddedAccounts() 
            { 
                MainAccountId = accountCurrent.Id, 
                PercentAccountId = accountPercent.Id 
            };
        }
    }
}
