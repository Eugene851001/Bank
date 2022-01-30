using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAPI.DTO
{
    public class UserValidator: AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotNull()
                .Must(IsValidName);

            RuleFor(u => u.Surname)
                .NotNull()
                .Must(IsValidName);

            RuleFor(u => u.Lastname)
                .NotNull()
                .Must(IsValidName);

            RuleFor(u => u.PassportSeries)
                .NotNull()
                .Length(2);

            RuleFor(u => u.PassportNumber)
                .NotNull()
                .Matches(new Regex(@"^\d{7}"));

            RuleFor(u => u.PassportId)
                .NotNull()
                .Matches(new Regex(@"^\d{14}"));

            RuleFor(u => u.MobilePhone)
                .Matches(new Regex(@"^\d{7}&"));

            

            RuleFor(u => u.Email)
                .EmailAddress();
        }

        private static bool IsValidName(string name)
        {
            var regex = new Regex(@"^[a-zA-ZА-Яа-я]+$");

            return regex.IsMatch(name);
        }
    }
}
