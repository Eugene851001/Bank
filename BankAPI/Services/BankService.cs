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
        private readonly SystemService systemService;
        private readonly IBankContext db;

        public BankService(
            DepositsService depositsService, 
            CreditsService creditsService,
            SystemService systemService,
            IBankContext bankContext)
        {
            this.depositsService = depositsService;
            this.creditsService = creditsService;
            this.systemService = systemService;
            this.db = bankContext;
        }

        public override void CloseBankDay()
        {
            this.depositsService.CloseBankDay();
            this.creditsService.CloseBankDay();

            var date = this.systemService.CurrentDate;
            this.systemService.SaveCurrentDate(date.AddDays(1));
        }
    }
}
