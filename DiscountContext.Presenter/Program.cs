using DiscountContext.Infrastructure;
using DiscountContext.Presenter.Extensions;
using DiscountContext.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddApplicationServices();


var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context
        => await Results.Problem()
                     .ExecuteAsync(context)));

app.MapGet("/exception", () =>
{
    throw new InvalidOperationException("Sample Exception");
}).WithOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.RegisterEndpointDefinitions();

app.Run();
