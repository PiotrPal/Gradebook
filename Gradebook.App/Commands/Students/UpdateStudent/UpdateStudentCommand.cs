﻿using Gradebook.App.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.App.Commands.Students.UpdateStudent {
    public class UpdateStudentCommand : IRequest {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int YearEnrolled { get; set; }
    }
}
