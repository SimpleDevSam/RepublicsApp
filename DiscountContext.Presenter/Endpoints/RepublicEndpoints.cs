using DiscountContext.Presenter.Abstractions;
using DiscountContext.Presenter.Services.Republic;

namespace DiscountContext.Presenter.Endpoints
{
    public class RepublicEndpoints : IEndPointDefinition
    {

        public void RegisterEndpoints(WebApplication app)
        {
            var republic = app.MapGroup("/api/republic");

            republic.MapGet("/", async (IRepublicService republicService) =>
            {
                try
                {
                    var republics = await republicService.GetAll().ConfigureAwait(false);
                    return republics != null ? Results.Ok(republics) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }).WithName("GetAll Republics");
        }
    }
}
