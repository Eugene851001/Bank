using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    public abstract class ContractsController: ApiControllerBase
    {
        public ContractsController(IBankContext db): base(db) { }

        [HttpGet]
        public abstract ActionResult GetAll();

        [Route("{id:int}")]
        [HttpGet]
        public abstract ActionResult GetSingle([FromRoute] int id);

        [Route("{id:int}/Accounts")]
        [HttpGet]
        public abstract ActionResult GetAccounts([FromRoute] int id);

        [Route("Plans")]
        [HttpGet]
        public abstract ActionResult GetPlans();

        [Route("{id:int}/report")]
        [HttpGet]
        public abstract ActionResult GetReport([FromRoute] int id);

    }
}
