using BankDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Services
{
    public  class SystemService
    {
        private readonly IBankContext db;

        public SystemService(IBankContext db)
        {
            this.db = db;
            this.CurrentDate = db.SystemVariables.Find((byte)1).CurrentDate;
        }
 
        public DateTime CurrentDate { get; set; }

        public void SaveCurrentDate(DateTime date)
        {
            this.CurrentDate = date;

            var system = this.db.SystemVariables.Find((byte)1);

            system.CurrentDate = date;

            this.db.SaveChanges();
        }
    }
}
