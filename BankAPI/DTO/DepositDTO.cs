﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class DepositDTO: ContractDTO
    {
        public bool Revocable { get; set; }
    }
}
