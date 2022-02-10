using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class CreditPlanDTO: ContractPlanDTO
    {
        public bool Annuity { get; set; }

        public string Object { get; set; }
    }
}
