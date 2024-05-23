using Gradebook.App.Configuration.Commands;

namespace Gradebook.App.Commands.Students.UpdateStudent {
    public class UpdateStudentCommand : ICommand {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int YearEnrolled { get; set; }
    }
}
