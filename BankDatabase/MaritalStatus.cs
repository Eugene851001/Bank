using System;
using System.Collections.Generic;

#nullable disable

namespace BankDatabase
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            Users = new HashSet<User>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
