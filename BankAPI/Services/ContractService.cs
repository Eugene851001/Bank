using BankAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public abstract class ContractService
    {
        public void CloseBankMonth()
        {
            for (int i = 0; i < Constants.Intervals.Month; i++)
            {
                CloseBankDay();
            }
        }

        public abstract void CloseBankDay();
    }
}
