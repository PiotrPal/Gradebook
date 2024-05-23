using MediatR;

namespace Gradebook.App.Configuration.Commands {
    public interface ICommandHandler<in TComand> : IRequestHandler<TComand>
        where TComand : ICommand{
    }

    public interface ICommandHandler<in TComand, TResult> : IRequestHandler<TComand, TResult>
        where TComand : ICommand<TResult> {
    }
}
