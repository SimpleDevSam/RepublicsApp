using DiscountContext.Application.UseCases.User.Login;
using DiscountContext.Presenter.Abstractions;
using MediatR;

namespace DiscountContext.Presenter.Endpoints
{
    public class UserEndpoints : IEndPointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var company = app.MapGroup("/api/user");

            company.MapPost("/register", async (RegisterCommand command,IMediator mediator) =>
            {

                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response.Message);

                return Results.Ok(response.Message);
            })
            .WithName("Register User")
            .WithOpenApi();

            company.MapPost("/login", async (LoginCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response.Message);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response.Message);

                return Results.Ok(response);
            })
            .WithName("LoginUser")
            .WithOpenApi();
        }
    }
}