using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class CreateContractRequest
    {
        public int User { get; set; }

        public string AccountCode { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public decimal Sum { get; set; }
        
        public double Percent { get; set; }
        
        public byte Currency { get; set; }
        
        public short? DepositType { get; set; }
    }
}
