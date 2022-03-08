using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class CardLoginationRequest
    {
        public string Number { get; set; }

        public string Pin { get; set; }
    }
}
