namespace DiscountContext.Shared.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; }
    }

    public interface ICommandResult<T> : ICommandResult
    {
        T Data { get; }
    }
}