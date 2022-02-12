using BankAPI.DTO.Requests;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Helpers;
using BankAPI.Services;
using BankAPI.DTO;

namespace BankAPI.Controllers
{
    public class DepositsController: ContractsController
    {
        private readonly DepositsService _deposistsService;

        public DepositsController(
            IBankContext db, 
            DepositsService depositsService) : base(db)
        {
            _deposistsService = depositsService;
        }

        [HttpGet]
        public override ActionResult GetAll()
        {
            DepositDTO[] deposits = this.db.Deposits
                .Select(contract => this.mapper.Map<DepositDTO>(contract))
                .ToArray();

            return Ok(deposits);
        }

        [Route("{id:int}")]
        [HttpGet]
        public override ActionResult GetSingle([FromRoute] int id)
        {
            var contract = this.db.Deposits.Find(id);

            var result = this.mapper.Map<DepositDTO>(contract);

            return Ok(result);
        }

        [Route("{id:int}/Accounts")]
        [HttpGet]
        public override ActionResult GetAccounts([FromRoute] int id)
        {
            var deposit = this.db.Deposits.Find(id);
            AccountDTO[] accounts = new [] 
                { 
                    deposit.MainAccountNavigation, 
                    deposit.PercentAccountNavigation 
                }.Select(ac => this.mapper.Map<AccountDTO>(ac))
                .ToArray();

            return Ok(accounts);
        }

        [Route("Plans")]
        [HttpGet]
        public override ActionResult GetPlans()
        {

            DepositPlanDTO[] plans = this.db.DepositsPlans
                .Select(plan => this.mapper.Map<DepositPlanDTO>(plan))
                .ToArray();

            for (int i = 0; i < plans.Length; i++)
            {
                var plan = this.db.DepositsPlans.Find(plans[i].Id);
                plans[i].Name = plan.NameNavigation.Name;
                plans[i].Currency = plan.CurrencyNavigation.Code;
            }

            return Ok(plans);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CreateDepositRequest request)
        {
            try
            {
                _deposistsService.Create(request);
            }
            catch(Exception e)
            {
                return BadRequest(new ErrorDTO() { Message = e.Message });
            }

            return Ok();
        }

        [Route("WithdrawPercents")]
        [HttpPut]
        public ActionResult WithdrawPercents([FromBody] WithdrawRequest request)
        {
            try
            {
                _deposistsService.WithdrawPercents(request.DepositId);
            }
            catch(Exception e)
            {
                return BadRequest(new ErrorDTO() { Message = e.Message });
            }

            return Ok();
        }

        [Route("CloseDeposit")]
        [HttpPut]
        public ActionResult CloseDeposit([FromBody] CloseDepositRequest request)
        {
            try
            {
                _deposistsService.CloseDeposit(request.ContractId);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO() { Message = e.Message });
            }

            return Ok();
        }

        [Route("{id:int}/report")]
        [HttpGet]
        public override ActionResult GetReport([FromRoute] int id)
        {
            var contract = this.db.Deposits.Find(id);

            var report = ReportsService.GenerateDepositReport(contract);

            PaymentDTO[] payments = report.Keys.Select(date => new PaymentDTO() { Date = date, Sum = report[date] }).ToArray();

            ExcelService.GenerateXlsxReport(report);

            return Ok(payments);
        }
    }
}
