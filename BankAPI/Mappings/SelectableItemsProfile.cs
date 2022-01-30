using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankAPI.DTO;
using BankDatabase;

namespace BankAPI.Mappings
{
    public class SelectableItemsProfile: Profile
    {
        public SelectableItemsProfile()
        {
            CreateMap<City, SelectableItemDTO>();

            CreateMap<MaritalStatus, SelectableItemDTO>();

            CreateMap<Country, SelectableItemDTO>();
        }
    }
}
