using BankAPI.DTO;
using BankAPI.DTO.Requests;
using BankAPI.Services;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    public class CreditsController: ContractsController
    {
        private readonly CreditsService creditsService;

        public CreditsController(IBankContext db, CreditsService creditsService): base(db) 
        {
            this.creditsService = creditsService;
        }

        [HttpPost]
        public ActionResult Add([FromBody] CreateCreditRequest request)
        {
            creditsService.Create(request);
            return Ok();
        }

        public override ActionResult GetAccounts([FromRoute] int id)
        {
            var credit = this.db.Credits.Find(id);
            AccountDTO[] accounts = new[]
            {
                    credit.MainAccountNavigation,
                    credit.PercentAccountNavigation
                }.Select(ac => this.mapper.Map<AccountDTO>(ac))
                .ToArray();

            return Ok(accounts);
        }

        public override ActionResult GetAll()
        {
            CreditDTO[] credits = this.db.Credits
                .Select(credit => this.mapper.Map<CreditDTO>(credit))
                .ToArray();

            return Ok(credits);
        }

        public override ActionResult GetPlans()
        {

            CreditPlanDTO[] plans = this.db.CreditPlans
                .Select(plan => this.mapper.Map<CreditPlanDTO>(plan))
                .ToArray();

            for (int i = 0; i < plans.Length; i++)
            {
                var plan = this.db.CreditPlans.Find(plans[i].Id);
                plans[i].Name = plan.NameNavigation.Name;
                plans[i].Currency = "USD";
                plans[i].Object = plan.ObjectNavigation.Name;
            }

            return Ok(plans);
        }

        public override ActionResult GetReport([FromRoute] int id)
        {
            var credit = this.db.Credits.Find(id);

            var report = ReportsService.GenerateCreditReport(credit);

            PaymentDTO[] payments = report.Keys.Select(date => new PaymentDTO() { Date = date, Sum = report[date] }).ToArray();

            return Ok(payments);
        }

        public override ActionResult GetSingle([FromRoute] int id)
        {
            var contract = this.db.Credits.Find(id);

            var result = this.mapper.Map<CreditDTO>(contract);

            return Ok(result);
        }
    }
}
