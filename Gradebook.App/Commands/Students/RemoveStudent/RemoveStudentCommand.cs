using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.App.Commands.Students.RemoveStudent {
    public record RemoveStudentCommand (int ID) :IRequest {

    }
}
