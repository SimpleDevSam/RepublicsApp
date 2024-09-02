using DiscountContext.Application.UseCases.Discount;
using DiscountContext.Application.UseCases.Discount.Delete;
using DiscountContext.Domain.UseCases.Discount.Create;
using DiscountContext.Presenter.Abstractions;
using MediatR;

namespace DiscountContext.Presenter.Endpoints
{
    public class DiscountEndpoints : IEndPointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var discount = app.MapGroup("/api/discounts").RequireAuthorization();

            discount.MapGet("/", async (IMediator mediator) =>
            {
                var query = new GetAllDiscountsQuery();
                var response = await mediator.Send(query);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("GetAll Discounts")
            .WithOpenApi();

            discount.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetDiscountQuery { DiscountId = id };
                var response = await mediator.Send(query);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Get Discount")
            .WithOpenApi();

            discount.MapPost("/", async (CreateDiscountCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("Create Discount")
            .WithOpenApi();

            discount.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var command = new DeleteDiscountCommand { DiscountId = id };
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Delete Discount")
            .WithOpenApi();

            discount.MapPut("/", async (Guid id, UpdateDiscountCommand command, IMediator mediator) =>
            {
                command.DiscountId = id;
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Update Discount")
            .WithOpenApi();
        }
    }
}