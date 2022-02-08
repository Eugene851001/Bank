using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class CreateContractRequest
    {
        public int User { get; set; }

        public DateTime StartDate { get; set; }

        public int Sum { get; set; }
    }
}
