using Gradebook.App.Dtos;
using MediatR;

namespace Gradebook.App.Queries.Students.GetStudents {
    internal record GetStudentsQuery() : IRequest<IEnumerable<StudentDto>>{ //dto - data transfer object

    }
}
