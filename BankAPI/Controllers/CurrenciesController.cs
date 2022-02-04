using BankAPI.DTO;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    public class CurrenciesController: ApiControllerBase
    {
        public CurrenciesController(IBankContext db) : base(db) { }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            SelectableItemDTO[] items = this.db.Currencies
                .Select(c => this.mapper.Map<SelectableItemDTO>(c))
                .ToArray();

            return Ok(items);
        }
    }
}
