using BankAPI.DTO.Requests;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Helpers;
using BankAPI.Services;

namespace BankAPI.Controllers
{
    public class ContractsController: ApiControllerBase
    {
        private readonly AccountsService _accountsService;

        public ContractsController(IBankContext db, AccountsService accountsService) : base(db)
        {
            _accountsService = accountsService;
        }

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
                Number = _accountsService.GetAccountNumber(Constants.AccountTypes.Current),
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
                Number = _accountsService.GetAccountNumber(Constants.AccountTypes.Credit),
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
                .FirstOrDefault();

            account.Credit = account.Credit + sum;

            this.db.SaveChanges();
        }
    }
}
