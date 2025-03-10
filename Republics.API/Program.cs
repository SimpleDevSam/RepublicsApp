using DiscountContext.Infrastructure;
using Republics.API.Middlewares;
using Republics.API.Extensions;
using Republics.Application;
using Republics.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.AddIdentity();
builder.AddSecurity();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Baha'i Prayers API");
    c.InjectStylesheet("/swagger/custom.css");
    c.RoutePrefix = String.Empty;
});

app.RegisterEndpointDefinitions();


app.Run();



