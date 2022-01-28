using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class Disability
    {
        public Disability()
        {
            Users = new HashSet<User>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
