using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class WithdrawRequest
    {
        public DateTime CurrentDate { get; set; }

        public int DepositId { get; set; }
    }
}
