using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class ContractPlanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public int Duration { get; set; }
        public double Percent { get; set; }
        public decimal? MinValue { get; set; }
    }
}
