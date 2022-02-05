using BankAPI.DTO;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    public class SelectableItemsController: ApiControllerBase
    {
        public SelectableItemsController(IBankContext db): base(db) { }

        [HttpGet("Cities")]
        public ActionResult Cities() => Ok(HelpGetAll(this.db.Cities));

        [HttpGet("Countries")]
        public ActionResult Countries() => Ok(HelpGetAll(this.db.Countries));

        [HttpGet("MaritalStatuses")]
        public ActionResult MaritalStatuses() => Ok(HelpGetAll(this.db.MaritalStatuses));

        [HttpGet("Disabilities")]
        public ActionResult Disabilities() => Ok(HelpGetAll(this.db.Disabilities));

        [HttpGet("Currencies")]
        public ActionResult Currencies() => Ok(HelpGetAll(this.db.Disabilities));


        private IEnumerable<SelectableItemDTO> HelpGetAll<T>(DbSet<T> collection) where T: class
        {
            SelectableItemDTO[] items = collection
                .Select(item => this.mapper.Map<SelectableItemDTO>(item))
                .ToArray();

            return items;
        }

    }
}
