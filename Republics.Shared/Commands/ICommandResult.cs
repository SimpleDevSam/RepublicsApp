namespace Republics.Shared.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; }
        int Code { get; }
    }

    public interface ICommandResult<T> : ICommandResult
    {
        T Data { get; }
    }
}