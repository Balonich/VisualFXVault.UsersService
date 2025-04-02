using System.Text.Json.Serialization;
using VisualFXVault.API.Middlewares;
using VisualFXVault.Domain.Extensions;
using VisualFXVault.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddInfrastructure();

// Json serialization settings for enums
// This is necessary to ensure that enums are serialized as strings in the JSON response
builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter()
    )
);

var app = builder.Build();

app.UseExceptionHandling();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
