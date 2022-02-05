using BankAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class AccountsService
    {
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
    }
}
