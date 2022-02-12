using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public decimal Amount { get; set; }
    }
}
