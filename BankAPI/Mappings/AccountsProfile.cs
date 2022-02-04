using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankAPI.DTO;
using BankDatabase;

namespace BankAPI.Mappings
{
    public class AccountsProfile: Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountDTO>();
        }
    }
}
