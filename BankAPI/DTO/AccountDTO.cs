using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public decimal? Balance { get; set; }

        public int? Owner { get; set; }

        public int AccountType { get; set; }
    }
}
