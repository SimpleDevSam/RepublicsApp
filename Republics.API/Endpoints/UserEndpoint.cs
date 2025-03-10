using MediatR;
using Republics.API.Abstractions;
using Republics.Application.UseCases;

namespace Republics.API.Endpoints
{
    public class UserEndpoints : IEndPointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var company = app.MapGroup("/api/user");

            company.MapPost("/register", async (RegisterCommand command, IMediator mediator) =>
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