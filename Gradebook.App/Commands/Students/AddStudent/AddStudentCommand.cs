using Gradebook.App.Configuration.Commands;
using Gradebook.App.Dtos;

namespace Gradebook.App.Commands.Students.AddStudent {
    public class AddStudentCommand : ICommand<StudentDto>{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int YearEnrolled { get; set; }
    }
}
