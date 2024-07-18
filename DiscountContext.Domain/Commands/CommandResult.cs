using DiscountContext.Shared.Commands;
using static DiscountContext.Shared.Commands.ICommandResult;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult<T> : ICommandResult<T>
    {
        public CommandResult()
        {
        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public CommandResult(bool success, string message, T data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}