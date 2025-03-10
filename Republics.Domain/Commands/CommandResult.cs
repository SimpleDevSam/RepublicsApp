using Republics.Shared.Commands;
using static Republics.Shared.Commands.ICommandResult;

namespace Republics.Domain.Commands
{
    public class CommandResult<TData> : ICommandResult<TData>
    {
        public CommandResult()
                    => Code = 200;

        public CommandResult(TData? data, int code = 200, string? message = null)
        {
            Message = message;
            Data = data;
            Code = code;
        }

        public string? Message { get; set; }
        public int Code { get; set; }
        public TData? Data { get; set; }
        public bool Success => Code is >= 200 and <= 299;
    }
}