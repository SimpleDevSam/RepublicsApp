using DiscountContext.Shared.Commands;
using System.Text.Json.Serialization;

namespace DiscountContext.Application.Commands
{
    public class CommandResult<TData> : ICommandResult<TData>
    {
        [JsonConstructor]
        public CommandResult()
                    => Code = 200;

        public CommandResult(TData? data, int code = 200, string? message=null)
        {
            Message = message;
            Data = data;
            Code = code;
        }

        [JsonIgnore]
        public string? Message { get; set; }
        public int Code { get; set; }
        public TData? Data { get; set; }

        [JsonIgnore]
        public bool Success => Code is >= 200 and <= 299;
    }
}