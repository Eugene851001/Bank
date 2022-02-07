using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class CloseDepositRequest
    {
        public DateTime CurrentDate { get; set; }

        public int ContractId { get; set; }
    }
}
