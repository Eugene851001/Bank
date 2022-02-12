using BankAPI.DTO;
using BankDatabase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    public class TransactionsController: ApiControllerBase
    {
        public TransactionsController(IBankContext db): base(db) { }

        [HttpGet]
        public ActionResult GetAll()
        {
            TransactionDTO[] result = this.db.Transactions
                .Select(t => this.mapper.Map<TransactionDTO>(t))
                .ToArray();

            HelpGetTransactions(result);

            return Ok(result);
        }

        [HttpGet("yesterday")]
        public ActionResult GetYesterday()
        {
            var system = this.db.SystemVariables.Find((byte)1);

            var date = system.CurrentDate.AddDays(-1);

            TransactionDTO[] result = this.db.Transactions
                .Where(t => t.Time == date)
                .Select(t => this.mapper.Map<TransactionDTO>(t))
                .ToArray();

            HelpGetTransactions(result);

            return Ok(result);
        }

        private IEnumerable<TransactionDTO> HelpGetTransactions(TransactionDTO[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                var transaction = this.db.Transactions.Find(result[i].Id);
                result[i].Source = transaction.SourceNavigation.Number;
                result[i].Destination = transaction.DestinationNavigation.Number;
            }

            return result;
        }
    }
}
