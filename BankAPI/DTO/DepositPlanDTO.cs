using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class DepositPlanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public int Duration { get; set; }
        public bool Revocable { get; set; }
        public double Percent { get; set; }
        public bool Online { get; set; }
        public decimal? MinValue { get; set; }
    }
}
