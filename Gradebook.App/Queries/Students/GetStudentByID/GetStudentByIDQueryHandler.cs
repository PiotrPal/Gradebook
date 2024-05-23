using AutoMapper;
using Gradebook.App.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;

namespace Gradebook.App.Queries.Students.GetStudentByID {
    internal class GetStudentByIDQueryHandler : IRequestHandler<GetStudentByIDQuery, StudentDto> {

        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentByIDQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentDto> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken) {
            var student = await _studentRepository.GetByIDAsync(request.ID,cancellationToken);

            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;

        }
    }
}
