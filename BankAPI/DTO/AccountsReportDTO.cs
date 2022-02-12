using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class AccountsReportDTO
    {
        public AccountDTO BankAccount { get; set; }

        public AccountDTO CashAccount { get; set; }

        public IEnumerable<AccountDTO> DepositAccounts { get; set; }

        public IEnumerable<AccountDTO> CreditAccounts { get; set; }
    }
}
