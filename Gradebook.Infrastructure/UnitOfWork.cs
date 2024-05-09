using Gradebook.Domain.Abstractions;

namespace Gradebook.Infrastructure {
    internal class UnitOfWork : IUnitOfWork {
        public Task SaveChangesAsycn(CancellationToken cancellation = default) {
            throw new NotImplementedException();
        }
    }
}
