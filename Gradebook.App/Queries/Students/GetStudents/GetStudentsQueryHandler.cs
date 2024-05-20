using Gradebook.App.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.App.Queries.Students.GetStudents {
    internal class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentDto>> {
        private readonly IStudentReadOnlyRepository _studentReadOnlyRepository;
        public GetStudentsQueryHandler(IStudentReadOnlyRepository studentReadOnlyRepository) {
            _studentReadOnlyRepository = studentReadOnlyRepository;
        }
        public async Task<IEnumerable<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken) {
            var students = await _studentReadOnlyRepository.GetAllAsync(cancellationToken);

            var studentsDto = students.Select(x => new StudentDto {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Age = DateTime.Now.Year - x.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00")).Year,
                YearEnrolled = x.YearEnrolled
            });
            return studentsDto;

        }
    }
}
