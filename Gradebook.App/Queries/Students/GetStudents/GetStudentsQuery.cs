using Gradebook.App.Dtos;
using MediatR;

namespace Gradebook.App.Queries.Students.GetStudents {
    public record GetStudentsQuery() : IRequest<IEnumerable<StudentDto>>{ //dto - data transfer object

    }
}
