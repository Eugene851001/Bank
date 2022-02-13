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
using BankAPI.Helpers;

namespace BankAPI.Controllers
{
    public class UsersController: ApiControllerBase
    {

        public UsersController(IBankContext db): base(db) { }

        [HttpGet]
        public IActionResult GetUsers()
        {
            UserDemo[] users = this.db.Users
                .Where(u => !u.Deleted)
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

            if (user is null || user.Deleted)
            {
                return NotFound();
            }

            UserDTO result = this.mapper.Map<UserDTO>(user);
            
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            var newUser = request.Value;
            User user = GetById(request.Id);

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

            foreach (var property in newUser.GetType().GetProperties())
            {
                object value = property.GetValue(newUser);
                user.GetType().GetProperty(property.Name).SetValue(user, value);
            }

            this.db.SaveChanges();

            return Ok();
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = GetById(id);

            if (user.Accounts.Any(ac => ac.Active == Constants.Accounts.Active 
                && ac.CreditMainAccountNavigations.First().Sum != 0))
            {
                return BadRequest("Can not delete user with open credits");
            }

            user.Deleted = true;

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
