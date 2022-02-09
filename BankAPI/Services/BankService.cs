using BankDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public class BankService: ContractService
    {
        private readonly DepositsService depositsService;
        private readonly CreditsService creditsService;
        private readonly IBankContext db;

        public BankService(
            DepositsService depositsService, 
            CreditsService creditsService,
            IBankContext bankContext)
        {
            this.depositsService = depositsService;
            this.creditsService = creditsService;
            this.db = bankContext;
        }

        public override void CloseBankDay()
        {
            this.depositsService.CloseBankDay();
            this.creditsService.CloseBankDay();

            var system = this.db.SystemVariables.Find((byte)1);
            system.CurrentDate = system.CurrentDate.AddDays(1);
            this.db.SaveChanges();
        }
    }
}
