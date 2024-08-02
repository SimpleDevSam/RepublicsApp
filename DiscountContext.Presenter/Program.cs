using DiscountContext.Infrastructure;
using DiscountContext.Presenter.Extensions;
using DiscountContext.Application;
using DiscountContext.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using DiscountContext.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName));
builder.Services.AddApplicationServices();
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<DiscountDbContext>()
    .AddApiEndpoints();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();



var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp
    => exceptionHandlerApp.Run(async context
        => await Results.Problem()
                     .ExecuteAsync(context)));

app.MapGet("/exception", () =>
{
    throw new InvalidOperationException("Sample Exception");
}).WithOpenApi();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("/identity").WithTags("Identity").MapIdentityApi<User>();

app.RegisterEndpointDefinitions();

app.Run();
