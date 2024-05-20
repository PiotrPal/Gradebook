using Gradebook.App.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.App.Queries.Students.GetStudentByID {
    public record GetStudentByIDQuery(int ID) : IRequest<StudentDto>{

    }
}
