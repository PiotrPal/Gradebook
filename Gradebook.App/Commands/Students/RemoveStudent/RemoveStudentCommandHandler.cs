using Gradebook.App.Configuration.Commands;
using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Gradebook.App.Commands.Students.RemoveStudent {
    internal class RemoveStudentCommandHandler : ICommandHandler<RemoveStudentCommand> {

        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveStudentCommandHandler> _logger;

        public RemoveStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, ILogger<RemoveStudentCommandHandler> logger) {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _logger.LogDebug("Nlog is integrated to Book Controller");
        }

        public async Task Handle(RemoveStudentCommand request, CancellationToken cancellationToken) {
            
            var student = await _studentRepository.GetByIDAsync(request.ID, cancellationToken);
            if (student == null) {
                throw new StudentNotFoundException(request.ID);
            }

            _studentRepository.Delete(student);
            await _unitOfWork.SaveChangesAsycn(cancellationToken);

            _logger.LogDebug($"Student with ID {request.ID} was removed.");
        }
    }
}
