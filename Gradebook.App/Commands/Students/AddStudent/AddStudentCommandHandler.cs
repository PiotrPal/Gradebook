using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Gradebook.App.Configuration.Commands;
using Gradebook.App.Dtos;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using Gradebook.Domain.Exceptions;

namespace Gradebook.App.Commands.Students.AddStudent {
    internal class AddStudentCommandHandler : ICommandHandler<AddStudentCommand, StudentDto> {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AddStudentCommand> _validator;

        public AddStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<AddStudentCommand> validator) {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken) {

            ValidationResult result = _validator.Validate(request);
            if (!result.IsValid) {
                var errorList = result.Errors.Select(x => x.ErrorMessage);
                throw new ValidationException($" Invalid command ;(  {string.Join(",", errorList.ToArray())}");
            }

            bool isAlreadyExist = await _studentRepository.IsAlreadyExistAsync(request.Email, cancellationToken);
            if(isAlreadyExist) {
                throw new StudentAlreadyExistsException(request.Email);
            }

            var newStudent = new Student() {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                YearEnrolled = request.YearEnrolled,
            };

            _studentRepository.Add(newStudent);
            await _unitOfWork.SaveChangesAsycn();

            var studentDto = _mapper.Map<StudentDto>(newStudent);

            return studentDto;
        }
    }
}
