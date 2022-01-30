using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace BankAPI.DTO.Requests
{
    public class UpdateRequestValidator: AbstractValidator<UpdateUserRequest>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.Value)
                .NotNull()
                .SetValidator(new UserValidator())
                .WithMessage("Inavalid users properties");
        }
    }
}
