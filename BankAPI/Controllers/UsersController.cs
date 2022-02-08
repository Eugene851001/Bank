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
            UserDemo[] users = this.db.Users
                .OrderBy(u => u.Lastname)
                .Select(u => this.mapper.Map<UserDemo>(u))
                .ToArray();

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

            UserDTO result = this.mapper.Map<UserDTO>(user);
            
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            var newUser = this.mapper.Map<User>(request.Value);
            User user = GetById(request.Id);
            
            //primary key should not change
            newUser.Id = user.Id;

            if (this.db.Users.Any(u => u.PassportNumber == newUser.PassportNumber && u.Id != request.Id))
            {
                return BadRequest(new ErrorDTO()
                {
                    Message = $"There is already passport with number {user.PassportNumber}"
                });
            }

            if (this.db.Users.Any(u => u.PassportId == newUser.PassportId && u.Id != request.Id))
            {
                return BadRequest(new ErrorDTO()
                {
                    Message = $"There is already user with passport id {user.PassportId}"
                });
            }

            foreach (var property in user.GetType().GetProperties())
            {
                property.SetValue(user, property.GetValue(newUser));
            }

            this.db.SaveChanges();

            return Ok();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = GetById(id);

            this.db.Users.Remove(user);
            this.db.SaveChanges();

            return Ok();
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            var dbUser = this.mapper.Map<User>(user);
            this.db.Users.Add(dbUser);

            if (this.db.Users.Any(u => u.PassportNumber == user.PassportNumber))
            {
                return BadRequest(new ErrorDTO() 
                { 
                    Message = $"There is already passport with number {user.PassportNumber}" 
                });
            }

            if (this.db.Users.Any(u => u.PassportId == user.PassportId))
            {
                return BadRequest(new ErrorDTO()
                {
                    Message = $"There is already user with passport id {user.PassportId}"
                });
            }

            this.db.SaveChanges();

            return Ok();
        }

        private User GetById(int id)
        {
            return this.db.Users.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
