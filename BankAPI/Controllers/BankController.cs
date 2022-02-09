using BankAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankService bankService;

        public BankController(BankService bankService)
        {
            this.bankService = bankService;
        }

        [HttpPost("CloseDay")]
        public ActionResult CloseDay()
        {
            this.bankService.CloseBankDay();
            return Ok();
        }

        [HttpPost("CloseMonth")]
        public ActionResult CloseMonth()
        {
            this.bankService.CloseBankMonth();
            return Ok();
        }
    }
}
