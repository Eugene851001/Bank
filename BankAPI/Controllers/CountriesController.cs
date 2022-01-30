using BankAPI.DTO;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Controllers
{
    public class CountriesController: ApiControllerBase
    {
        public CountriesController(IBankContext db): base(db) { }
            
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            SelectableItemDTO[] items = await this.db.Countries.
                Select(c => this.mapper.Map<SelectableItemDTO>(c))
                .ToArrayAsync();

            return Ok(items);
        }
    }
}
