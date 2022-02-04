using BankAPI.DTO.Requests;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Helpers;

namespace BankAPI.Controllers
{
    public class ContractsController: ApiControllerBase
    {
        public ContractsController(IBankContext db) : base(db) { }

        [HttpPost]
        public ActionResult Add([FromBody] CreateContractRequest request)
        {
            var contract = this.mapper.Map<Contract>(request);
            this.db.Contracts.Add(contract);

            this.db.SaveChanges();

            this.AddAccounts(request);
            this.AddSumToDevelopmentFund(request.Sum);

            return Ok();
        }

        private void AddAccounts(CreateContractRequest request)
        {
            var accountCurrent = new Account()
            {
                Owner = request.User,
                Active = Constants.Accounts.Passive,
                AccountType = Constants.AccountTypes.Current,
                Credit = request.Sum,
                Debit = 0,
                Number = request.AccountNumber,
                Code = request.AccountCode,
                Currency = request.Currency,

            };

            var accountPercent = new Account()
            {
                Owner = request.User,
                Active = Constants.Accounts.Passive,
                AccountType = Constants.AccountTypes.Credit,
                Credit = 0,
                Debit = 0,
                //TODO: generate number from accont type and guid
                Number = request.AccountNumber,
                Code = request.AccountCode,
                Currency = request.Currency,
            };

            //TODO: improve trigger to work when add multiple values
            this.db.Accounts.Add(accountCurrent);
            this.db.SaveChanges();

            this.db.Accounts.Add(accountPercent);
            this.db.SaveChanges();
        }

        private void AddSumToDevelopmentFund(decimal sum)
        {
            var account = this.db.Accounts
                .Where(ac => ac.AccountType == Constants.AccountTypes.DevelopmentFund)
                .SingleOrDefault();

            account.Credit = account.Credit + sum;

            this.db.SaveChanges();
        }
    }
}
