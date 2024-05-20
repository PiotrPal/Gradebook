using Gradebook.App.Dtos;
using Gradebook.App.Queries.Students.GetStudentByID;
using Gradebook.Domain.Abstractions;

namespace Gradebook.App.Queries.Students.GetStudentByEmail {
    internal class GetStudentByEmailQueryHandler {
        private readonly IStudentRepository _studentRepository;
        public GetStudentByEmailQueryHandler(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }
        public async Task<StudentDto> Handle(GetStudentByEmailQuery request, CancellationToken cancellationToken) {
            var student = await _studentRepository.GetByEmailAsync(request.Email, cancellationToken) ;

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
