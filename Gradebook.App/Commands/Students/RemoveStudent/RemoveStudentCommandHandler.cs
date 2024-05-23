using Gradebook.App.Dtos;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions;
using MediatR;

namespace Gradebook.App.Commands.Students.RemoveStudent {
    internal class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand> {

        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork) {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveStudentCommand request, CancellationToken cancellationToken) {
            
            var student = await _studentRepository.GetByIDAsync(request.ID, cancellationToken);
            if (student == null) {
                throw new StudentNotFoundException(request.ID);
            }

            _studentRepository.Delete(student);
            await _unitOfWork.SaveChangesAsycn(cancellationToken);
        }
    }
}
