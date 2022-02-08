using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.DTO;
using BankAPI.DTO.Requests;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    public class SystemController: ApiControllerBase
    {
        public SystemController(IBankContext db): base(db) { }

        [HttpGet]
        public ActionResult GetSystemVariable()
        {
            var system = this.db.SystemVariables.Find(1);
            return Ok(new SystemVariableDTO() { CurrentDate = system.CurrentDate });
        }

        [HttpPost]
        public ActionResult UpdateSystemVariable([FromBody] UpdateSystemRequest request)
        {
            var system = this.db.SystemVariables.Find(1);

            system.CurrentDate = request.CurrentDate;

            this.db.SaveChanges();

            return Ok();
        }
    }
}
