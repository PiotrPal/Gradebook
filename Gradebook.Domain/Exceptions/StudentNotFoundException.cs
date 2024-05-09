using System.Net;

namespace Gradebook.Domain.Exceptions {
    public class StudentNotFoundException : GradebookException {
        public int ID { get; set; }
        public StudentNotFoundException(int id) : base($"Student with ID {id} not found :( so sad ") 
            => ID = id;

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
