namespace DiscountContext.API.Extensions;

public static class AppExtension
{
    public static void UseExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(exceptionHandlerApp
            => exceptionHandlerApp.Run(async context
                => await Results.Problem()
                             .ExecuteAsync(context)));
    }
}