using BankAPI.DTO;
using BankAPI.DTO.Requests;
using BankAPI.DTO.Responses;
using BankAPI.Services;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    public class AtmController: ApiControllerBase
    {
        private readonly AtmService atmService;

        public AtmController(IBankContext db, AtmService atmService): base(db) 
        {
            this.atmService = atmService;
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login(CardLoginationRequest request)
        {
            bool cardFound = this.db.Cards
                .Any(card => card.Number == request.Number && card.Pin == request.Pin);

            if (cardFound)
            {
                return Ok();
            }

            return Unauthorized();
        }

        [Route("balance/{number}")]
        [HttpGet]
        public ActionResult GetBalance([FromRoute] string number)
        {
            var card = this.db.Cards.Find(number);

            return Ok(new GetBalanceResponse() { Balance = card.AccountNavigation.Balance.Value });
        }

        [HttpPost("withdraw")]
        public ActionResult WithdrawMoney([FromBody] AtmWthdrawRequest request)
        {
            try
            {
                this.atmService.WithdrawMoney(request.Number, request.Sum);
            }
            catch(Exception e)
            {
                return BadRequest(new ErrorDTO() { Message = e.Message });
            }

            return Ok();
        }

        [HttpPost("transfer")]
        public ActionResult TRansferMoney([FromBody] AtmTransferRequest request)
        {
            try
            {
                this.atmService.TransferMoney(request.CardNumber, request.DestinationAccount, request.Sum);
            }
            catch(Exception e)
            {
                return BadRequest(new ErrorDTO() { Message = e.Message });
            }

            return Ok();
        }
    }
}
