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
using BankAPI.Mappings;

namespace BankAPI.Controllers
{
    public class UsersController: ApiControllerBase
    {

        public UsersController(IBankContext db): base(db) { }

        [HttpGet]
        public IActionResult GetUsers()
        {
            UserDemo[] users = this.db.Users.Select(u => this.mapper.Map<UserDemo>(u)).ToArray();
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

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            var newUser = this.mapper.Map<User>(request.Value);
            User user = GetById(request.Id);
            
            //primary key should not change
            newUser.Id = user.Id;

            foreach (var property in user.GetType().GetProperties())
            {
                property.SetValue(user, property.GetValue(newUser));
            }

            try
            {
                this.db.Save();
            }
            catch
            {
                return BadRequest("Passport number and id should be unique");
            }

            return Ok();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = GetById(id);

            this.db.Users.Remove(user);
            this.db.Save();

            return Ok();
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            var dbUser = this.mapper.Map<User>(user);
            this.db.Users.Add(dbUser);
            this.db.Save();

            return Ok();
        }

        private User GetById(int id)
        {
            return this.db.Users.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
