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
    public class MaritalStatusesController: ApiControllerBase
    {

        public MaritalStatusesController(IBankContext db) : base(db) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            SelectableItemDTO[] items = await this.db.MaritalStatuses
                .Select(ms => this.mapper.Map<SelectableItemDTO>(ms))
                .ToArrayAsync();

            return Ok(items);
        }
    }
}
