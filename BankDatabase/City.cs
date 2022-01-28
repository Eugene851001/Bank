using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
