namespace WebApi.Validators
{
    using FluentValidation;
    using WebApi.Commands;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");
        }
    }

}
