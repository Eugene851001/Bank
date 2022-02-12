using BankAPI.DTO;
using BankAPI.DTO.Requests;
using BankAPI.Helpers;
using BankAPI.Services;
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
        private readonly AccountsService accountsService;

        public AccountsController(IBankContext db, AccountsService accountsService): base(db) 
        {
            this.accountsService = accountsService;
        }

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

        [HttpGet("Bank")]
        public ActionResult GetBankAccount()
        {
            Account bankAccount = this.db.Accounts
                .FirstOrDefault(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund);

            var result = this.mapper.Map<AccountDTO>(bankAccount);

            return Ok(result);
        }

    }
}
