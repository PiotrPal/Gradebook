﻿using Gradebook.App.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;
using Gradebook.Domain.Exceptions;
using Gradebook.Domain.Entities;

namespace Gradebook.App.Commands.Students.AddStudent {
    internal class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentDto> {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork) {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken) {
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

            var studentDto = new StudentDto {
                ID = newStudent.ID,
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                Email = newStudent.Email,
                Age = DateTime.Now.Year - newStudent.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00")).Year,
                YearEnrolled = newStudent.YearEnrolled
            };
            return studentDto;
        }
    }
}