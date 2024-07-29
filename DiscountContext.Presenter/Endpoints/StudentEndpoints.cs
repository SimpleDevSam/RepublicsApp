using DiscountContext.Domain.UseCases.CreateStudent;
using DiscountContext.Domain.UseCases.DeleteStudent;
using DiscountContext.Domain.UseCases.GetAllStudents;
using DiscountContext.Domain.UseCases.GetStudent;
using DiscountContext.Domain.UseCases.UpdateStudent;
using DiscountContext.Presenter.Abstractions;
using MediatR;

namespace DiscountContext.Presenter.Endpoints
{
    public class StudentEndpoints : IEndPointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var student = app.MapGroup("/api/student");

            student.MapGet("/", async (IMediator mediator) =>
            {
                var query = new GetAllStudentsQuery();
                var response = await mediator.Send(query);
                return response.Success ? Results.Ok(response) : Results.NotFound();
            })
            .WithName("GetAll Students")
            .WithOpenApi();

            student.MapGet("/{id}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetStudentQuery { StudentId = id };
                var response = await mediator.Send(query);
                return response.Data != null ? Results.Ok(response.Data) : Results.NotFound();
            })
            .WithName("Get Student")
            .WithOpenApi();

            student.MapPost("/", async (CreateStudentCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("Create Student")
            .WithOpenApi();

            student.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var command = new DeleteStudentCommand { StudentId = id };
                var response = await mediator.Send(command);
                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("Delete Student")
            .WithOpenApi();

            student.MapPut("/", async (Guid id, UpdateStudentCommand command, IMediator mediator) =>
            {
                command.StudentId = id;
                var response = await mediator.Send(command);
                if (!response.Success && response.Code == 400)
                    return Results.BadRequest(response);

                return Results.Ok(response);
            })
            .WithName("Update Student")
            .WithOpenApi();
        }
    }
}