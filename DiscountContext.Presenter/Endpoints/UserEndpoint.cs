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
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("Register User")
            .WithOpenApi();

            company.MapPost("/login", async (LoginCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("LoginUser")
            .WithOpenApi();
        }
    }
}