using System.Text.Json;

namespace Republics.API.CustomErrors;


public class InternalServerError : IResult
{
    public int StatusCode { get; }
    public string Message { get; }

    public InternalServerError(string message)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
        Message = message;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCode;
        httpContext.Response.ContentType = "application/json";

        var response = new { Error = Message };
        var jsonResponse = JsonSerializer.Serialize(response);

        await httpContext.Response.WriteAsync(jsonResponse);
    }
}