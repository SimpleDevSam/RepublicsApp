using MediatR;
using static Republics.Shared.Commands.ICommandResult;

namespace Republics.Shared.Commands;

public interface ICommand<T> : IRequest<T> where T : ICommandResult
{
    void Validate();
}