using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class DepositPlanDTO: ContractPlanDTO
    {
        public bool Revocable { get; set; }
        public bool Online { get; set; }
    }
}
