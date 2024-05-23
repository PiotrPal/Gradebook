using MediatR;

namespace Gradebook.App.Configuration.Commands {
    public interface ICommand : IRequest {
    }
    public interface ICommand<out TResult> : IRequest<TResult> {
    }
}
