using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class CreateDepositRequest: CreateContractRequest
    {

        public int DepositPlan { get; set; }
    }
}
