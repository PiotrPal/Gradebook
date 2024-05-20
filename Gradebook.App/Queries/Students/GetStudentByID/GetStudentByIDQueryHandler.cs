using Gradebook.App.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;

namespace Gradebook.App.Queries.Students.GetStudentByID {
    internal class GetStudentByIDQueryHandler : IRequestHandler<GetStudentByIDQuery, StudentDto> {

        private readonly IStudentRepository _studentRepository;
        public GetStudentByIDQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentDto> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken) {
            var student = await _studentRepository.GetByIDAsync(request.ID,cancellationToken);

            var studentDto = new StudentDto {
                ID = student.ID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Age = DateTime.Now.Year - student.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00")).Year,
                YearEnrolled = student.YearEnrolled
            };
            return studentDto;

        }
    }
}
