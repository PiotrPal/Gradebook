using MediatR;

namespace Gradebook.App.Configuration.Queries {
    public interface IQuery<out TResult> : IRequest<TResult> {

    }
}
