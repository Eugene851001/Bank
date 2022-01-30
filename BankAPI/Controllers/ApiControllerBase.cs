using AutoMapper;
using BankAPI.Mappings;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase: ControllerBase
    {
        protected IBankContext db;
        protected IMapper mapper;

        public ApiControllerBase(IBankContext db)
        {
            var config = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<UsersProfile>();
                cnf.AddProfile<SelectableItemsProfile>();
            });

            this.mapper = new Mapper(config);
            this.db = db;
        }
    }
}
