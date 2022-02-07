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
    public class DepositsController: ApiControllerBase
    {
        private readonly AccountsService _accountsService;
        private readonly DepositsService _deposistsService;

        public DepositsController(
            IBankContext db, 
            AccountsService accountsService,
            DepositsService depositsService) : base(db)
        {
            _accountsService = accountsService;
            _deposistsService = depositsService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            DepositDemo[] deposits = this.db.Contracts
                .Select(contract => this.mapper.Map<DepositDemo>(contract))
                .ToArray();

            return Ok(deposits);
        }

        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetSingle([FromRoute] int id)
        {
            var contract = this.db.Contracts.Find(id);

            var result = this.mapper.Map<DepositDTO>(contract);

            return Ok(result);
        }

        [Route("{id:int}/Accounts")]
        [HttpGet]
        public ActionResult GetAccounts([FromRoute] int id)
        {
            AccountDTO[] accounts = this.db.Contracts
                 .Find(id).Accounts
                 .Select(ac => this.mapper.Map<AccountDTO>(ac))
                 .ToArray();

            return Ok(accounts);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CreateContractRequest request)
        {
            var contract = this.mapper.Map<Contract>(request);
            _deposistsService.Create(contract, request.User);

            return Ok();
        }

        [Route("CloseDay")]
        [HttpPut]
        public ActionResult CloseBankDay([FromBody] CloseDayRequest request)
        {
            try
            {
                _deposistsService.CloseBankDay(request.CurrentDate);
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
                _deposistsService.WithdrawPercents(request.DepositId, request.CurrentDate);
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
                _deposistsService.CloseDeposit(request.ContractId, request.CurrentDate);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO() { Message = e.Message });
            }

            return Ok();
        }

        [Route("{id:int}/report")]
        [HttpGet]
        public ActionResult GetReport([FromRoute] int id)
        {
            var contract = this.db.Contracts.Find(id);

            var report = ReportsService.GenerateReportMonth(contract);

            PaymentDTO[] payments = report.Keys.Select(date => new PaymentDTO() { Date = date, Sum = report[date] }).ToArray();

            ExcelService.GenerateXlsxReport(report);

            return Ok(payments);
        }
    }
}
