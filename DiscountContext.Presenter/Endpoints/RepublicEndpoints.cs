using DiscountContext.Application.UseCases.Discount.Delete;
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
            var republic = app.MapGroup("/api/republics");

            republic.MapGet("/", async (IMediator mediator) =>
            {
                try
                {
                    var query = new GetAllRepublicsQuery();
                    var response = await mediator.Send(query);
                    return response.Success ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);

                }
            })
                .WithName("GetAll Republics")
                .WithOpenApi();

            republic.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                try
                {
                    var query = new GetRepublicQuery { RepublicId = id};
                    var response = await mediator.Send(query);

                    return response.Data != null ? Results.Ok(response.Data) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
               .WithName("Get Republic")
               .WithOpenApi();

            republic.MapPost("/", async (CreateRepublicCommand command, IMediator mediator) =>
            {
                try
                {
                    var response = await mediator.Send(command);

                    return response.Success ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
               .WithName("Create Republic")
               .WithOpenApi();


            republic.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                try
                {
                    var command = new DeleteRepublicCommand { RepublicId = id };
                    var response = await mediator.Send(command);

                    return response.Success ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
               .WithName("Delete Republic")
               .WithOpenApi();


            republic.MapPut("/", async (Guid id, UpdateRepublicCommand command, IMediator mediator) =>
            {
                try
                {
                    command.RepublicId = id;
                    var response = await mediator.Send(command);

                    return response.Success ? Results.Ok(response) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            })
               .WithName("Update Republic")
               .WithOpenApi();
        }

    }
}
