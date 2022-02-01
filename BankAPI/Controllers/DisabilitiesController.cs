using BankAPI.DTO;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace BankAPI.Controllers
{
    public class DisabilitiesController: ApiControllerBase
    {
        public DisabilitiesController(IBankContext db) : base(db) { }

        [HttpGet]
        public ActionResult GetAll()
        {
            SelectableItemDTO[] items = this.db.Disabilities
                .Select(d => this.mapper.Map<SelectableItemDTO>(d))
                .ToArray();

            return Ok(items);
        }
    }
}
