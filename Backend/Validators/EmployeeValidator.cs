using FluentValidation;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(x => x.Position).NotEmpty().WithMessage("Position is required.");
            RuleFor(x => x.Department).NotEmpty().WithMessage("Department is required.");
        }
    }
}