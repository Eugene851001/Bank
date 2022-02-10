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
            CreateMap<CreateContractRequest, Deposit>();

            CreateMap<Deposit, DepositDTO>();

            CreateMap<DepositsPlan, DepositPlanDTO>();
            //.ForMember(nameof(DepositPlanDTO.Name), opt => opt.MapFrom(p => p.NameNavigation.Name));

            CreateMap<Credit, CreditDTO>();

            CreateMap<CreditPlan, CreditPlanDTO>();
              //  .ForMember(nameof(CreditPlanDTO.Object), opt => opt.MapFrom(p => p.ObjectNavigation.Name));
        }
    }
}
