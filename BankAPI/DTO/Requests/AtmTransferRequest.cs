using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class AtmTransferRequest
    {
        public string CardNumber { get; set; }

        public string DestinationAccount { get; set; }

        public decimal Sum { get; set; }
    }
}
