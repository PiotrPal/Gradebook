using FluentValidation;

namespace Gradebook.App.Commands.Students.UpdateStudent {
    public class UpdateStudentCommandValidation : AbstractValidator<UpdateStudentCommand> {
        public UpdateStudentCommandValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("First name cannot be longer than 50 characters)");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .MaximumLength(50).WithMessage("Last Name cannot be longer than 50 characters)");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(100).WithMessage("Email cannot be longer than 100 characters)")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("DateOfBirth is required")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-18))).WithMessage("Student must be at least 18 years old");

            RuleFor(x => x.YearEnrolled)
                .NotEmpty().WithMessage("YearEnrolled is required");
        }
    }
}
