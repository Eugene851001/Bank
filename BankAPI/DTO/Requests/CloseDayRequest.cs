using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class CloseDayRequest
    {
        public DateTime CurrentDay { get; set; }
    }
}
