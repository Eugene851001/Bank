using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Helpers
{
    public static class Constants
    {
        public static class AccountTypes
        {
            public const int Current = 1;

            public const int Credit = 2;

            public const int CashRegister = 3;

            public const int DevelopmentFund = 4;
        }

        public static class Accounts
        {
            public static byte Passive = 0;

            public static byte Active = 1;

            public static byte ActivePassive = 2;
        }

    }
}
