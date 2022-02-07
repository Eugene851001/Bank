using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class DepositDTO
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Sum { get; set; }

        public double Percent { get; set; }

        public byte Currency { get; set; }

        public bool Revocable { get; set; }
    }
}
