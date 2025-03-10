namespace Republics.API.CustomErrors;


public static class ResultsExtensions
{
    public static IResult InternalServerError(string message)
    {
        return new InternalServerError(message);
    }
}