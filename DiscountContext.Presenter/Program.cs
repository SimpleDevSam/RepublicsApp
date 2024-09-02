using DiscountContext.Infrastructure;
using DiscountContext.Presenter.Extensions;
using DiscountContext.Application;
using DiscountContext.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.AddIdentity();
builder.AddSecurity();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI();

app.RegisterEndpointDefinitions();


app.Run();
