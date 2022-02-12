using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankAPI.DTO;
using BankDatabase;

namespace BankAPI.Mappings
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(nameof(TransactionDTO.Amount), opt => opt.MapFrom(t => t.Sum));
                //.ForMember(nameof(TransactionDTO.Source), opt => opt.MapFrom(t => t.SourceNavigation.Number))
                //.ForMember(nameof(TransactionDTO.Destination), opt => opt.MapFrom(t => t.DestinationNavigation.Number));
        }
    }
}
