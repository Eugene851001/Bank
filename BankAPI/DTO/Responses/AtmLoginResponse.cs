using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Responses
{
    public class AtmLoginResponse
    {
        public string AccountNumber { get; set; }

        public string Currency { get; set; }
    }
}
