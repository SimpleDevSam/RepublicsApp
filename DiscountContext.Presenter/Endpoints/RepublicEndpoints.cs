using DiscountContext.Application.UseCases.Republic;
using DiscountContext.Application.UseCases.Republic.Create;
using DiscountContext.Application.UseCases.Republic.Delete;
using DiscountContext.Presenter.Abstractions;
using MediatR;

namespace DiscountContext.Presenter.Endpoints
{
    public class RepublicEndpoints : IEndPointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var republic = app.MapGroup("/api/republics").RequireAuthorization();

            republic.MapGet("/", async (IMediator mediator) =>
            {
                var query = new GetAllRepublicsQuery();
                var response = await mediator.Send(query);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("GetAll Republics")
            .WithOpenApi();

            republic.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetRepublicQuery { RepublicId = id };
                var response = await mediator.Send(query);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Get Republic")
            .WithOpenApi();

            republic.MapPost("/", async (CreateRepublicCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("Create Republic")
            .WithOpenApi();

            republic.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var command = new DeleteRepublicCommand { RepublicId = id };
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Delete Republic")
            .WithOpenApi();

            republic.MapPut("/", async (Guid id, UpdateRepublicCommand command, IMediator mediator) =>
            {
                command.RepublicId = id;
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Update Republic")
            .WithOpenApi();
        }
    }
}