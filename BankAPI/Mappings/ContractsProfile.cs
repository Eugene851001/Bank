using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankDatabase;
using BankAPI.DTO.Requests;
using BankAPI.DTO;

namespace BankAPI.Mappings
{
    public class ContractsProfile: Profile
    {
        public ContractsProfile()
        {
            CreateMap<CreateContractRequest, Contract>();

            CreateMap<Contract, DepositDemo>();

            CreateMap<Contract, DepositDTO>();

            CreateMap<DepositsPlan, DepositPlanDTO>();
                //.ForMember(nameof(DepositPlanDTO.Name), opt => opt.MapFrom(p => p.NameNavigation.Name));
        }
    }
}
