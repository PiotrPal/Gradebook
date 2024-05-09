using System.Net;

namespace Gradebook.Domain.Exceptions {
    internal class StudentAlreadyExistsException : GradebookException {
        public string Email { get; set; }
        public StudentAlreadyExistsException(string email) : base($"Student with email: {email} already exist.")
            => Email = email; 

        public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    }
}
