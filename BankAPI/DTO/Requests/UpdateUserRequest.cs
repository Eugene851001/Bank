using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTO.Requests
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }

        public UserDTO Value { get; set; }
    }
}
