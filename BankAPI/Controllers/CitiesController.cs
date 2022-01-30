using BankAPI.DTO;
using BankDatabase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Controllers
{
 
    public class CitiesController : ApiControllerBase
    {

        public CitiesController(IBankContext db) : base(db) { }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            SelectableItemDTO[] items = await this.db.Cities.
                Select(c => this.mapper.Map<SelectableItemDTO>(c))
                .ToArrayAsync();

            return Ok(items);
        }
    }
}
