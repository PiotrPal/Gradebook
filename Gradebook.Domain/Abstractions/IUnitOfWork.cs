namespace Gradebook.Domain.Abstractions {
    public interface IUnitOfWork {
        Task SaveChangesAsycn(CancellationToken cancellation = default);
    }
}
