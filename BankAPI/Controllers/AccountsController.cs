using BankAPI.DTO;
using BankAPI.DTO.Requests;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    public class AccountsController: ApiControllerBase
    {
        public AccountsController(IBankContext db): base(db) { }

        [HttpGet]
        public ActionResult GetAll()
        {
            AccountDTO[] accounts = this.db.Accounts
                .Select(ac => this.mapper.Map<AccountDTO>(ac))
                .ToArray();

            return Ok(accounts);
        }

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetUserAccounts([FromRoute] int id)
        {
            AccountDTO[] accounts = this.db.Accounts
                .Where(ac => ac.Owner == id)
                .Select(ac => this.mapper.Map<AccountDTO>(ac))
                .ToArray();

            return Ok(accounts);
        }

        [Route("CloseDay")]
        [HttpPut]
        public ActionResult BankDayClosing([FromBody] CloseDayRequest request)
        {
            return Ok();
        }
    }
}
