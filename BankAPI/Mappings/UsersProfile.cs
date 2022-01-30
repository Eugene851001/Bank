using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankAPI.DTO;
using BankDatabase;

namespace BankAPI.Mappings
{
    public class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDTO>();
             //   .ForMember(nameof(UserDTO.ResidenceCity), opt => opt.MapFrom(u => u.ResidenceCityNavigation.Name));

            CreateMap<UserDTO, User>();

            CreateMap<User, UserDemo>();
        }
    }
}
