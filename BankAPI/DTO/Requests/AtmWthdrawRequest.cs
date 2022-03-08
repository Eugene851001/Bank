using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class AtmWthdrawRequest
    {
        public string Number { get; set; }

        public decimal Sum { get; set; }
    }
}
