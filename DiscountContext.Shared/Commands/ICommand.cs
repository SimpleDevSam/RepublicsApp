using MediatR;
using static DiscountContext.Shared.Commands.ICommandResult;

namespace DiscountContext.Shared.Commands
{
    public interface ICommand<T> : IRequest<T> where T : ICommandResult
    {
        void Validate();
    }
}