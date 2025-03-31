using VisualFXVault.API.Middlewares;
using VisualFXVault.Domain.Extensions;
using VisualFXVault.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandling();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
