using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class CreditDTO: ContractDTO
    {
        public bool Annuity { get; set; }
    }
}
