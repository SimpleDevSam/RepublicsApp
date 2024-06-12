using DiscountContext.Shared.Commands;

namespace DiscountContext.Shared.Handlers 
{
    public interface IHandler<T> where T:ICommand
    {
        ICommandResult Handle (T command);
    }
}