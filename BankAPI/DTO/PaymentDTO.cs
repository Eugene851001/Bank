using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class PaymentDTO
    {
        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
