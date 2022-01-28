using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDatabase
{
    public interface IBankContext
    {
         DbSet<City> Cities { get; set; }
         DbSet<Country> Countries { get; set; }
         DbSet<Disability> Disabilities { get; set; }
         DbSet<MaritalStatus> MaritalStatuses { get; set; }
         DbSet<User> Users { get; set; }

        int Save(); 
    }
}
