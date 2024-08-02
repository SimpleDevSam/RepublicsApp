using DiscountContext.Application.UseCases.Company;
using DiscountContext.Application.UseCases.Company.Delete;
using DiscountContext.Application.UseCases.Discount;
using DiscountContext.Application.UseCases.Discount.Delete;
using DiscountContext.Domain.UseCases.Discount.Create;
using DiscountContext.Presenter.Abstractions;
using MediatR;

namespace DiscountContext.Presenter.Endpoints
{
    public class CompanyEndpoints : IEndPointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var company = app.MapGroup("/api/companies");

            company.MapGet("/", async (IMediator mediator) =>
            {
                var query = new GetAllCompaniesQuery();
                var response = await mediator.Send(query);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("GetAll Companies")
            .WithOpenApi();

            company.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetCompanyQuery { CompanyId = id };
                var response = await mediator.Send(query);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Get Company")
            .WithOpenApi();

            company.MapPost("/", async (CreateCompanyCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("Create Company")
            .WithOpenApi();

            company.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var command = new DeleteCompanyCommand { CompanyId = id };
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Delete Company")
            .WithOpenApi();

            company.MapPut("/", async (Guid id, UpdateCompanyCommand command, IMediator mediator) =>
            {
                command.CompanyId = id;
                var response = await mediator.Send(command);

                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);
                if (!response.Success && response.Code == 404)
                    return Results.NotFound(response);

                return Results.Ok(response);
            })
            .WithName("Update Company")
            .WithOpenApi();
        }
    }
}