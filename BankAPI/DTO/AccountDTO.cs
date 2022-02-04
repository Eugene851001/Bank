using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class AccountDTO
    {
        public string Number { get; set; }

        public decimal? Balance { get; set; }

        public int? Owner { get; set; }
    }
}
