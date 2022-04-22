using ASPCoreWebAPI_Course.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course.Models.Validators
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(RestaurantDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
            RuleFor(x => x.Email).Custom((value, context) =>
              {
                  var emailInUse = dbContext.Users.Any(u => u.Email == value);
                  if (emailInUse)
                  {
                      context.AddFailure("Email", "That Email is taken");
                  }
              });
        }
    }
}
