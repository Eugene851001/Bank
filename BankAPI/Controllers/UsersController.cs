using BankAPI.DTO;
using BankAPI.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankDatabase;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBankContext db;

        public UsersController(IBankContext db)
        {
            var config = new MapperConfiguration(c => c.CreateMap<User, UserDTO>());
            this.mapper = new Mapper(config);
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {

            UserDTO[] users = this.db.Users.Select(u => this.mapper.Map<UserDTO>(u)).ToArray();
            return Ok(users);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetUser([FromRoute] int id)
        {
            User user = GetById(id);

            if (user is null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            User user = GetById(request.Id);

            user.Name = request.Value.Name;

            this.db.Save();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {

            return Ok();
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            return Ok();
        }

        private User GetById(int id)
        {
            return this.db.Users.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
