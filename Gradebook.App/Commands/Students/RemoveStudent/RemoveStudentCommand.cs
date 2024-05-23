using Gradebook.App.Configuration.Commands;

namespace Gradebook.App.Commands.Students.RemoveStudent {
    public record RemoveStudentCommand (int ID) :ICommand {

    }
}
