using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Scalar.AspNetCore;
using VisualFXVault.API.Middlewares;
using VisualFXVault.Domain.Extensions;
using VisualFXVault.Domain.Mappers;
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

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RegisterRequestMappingProfile).Assembly);

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Replace with frontend URL
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseExceptionHandling();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi(); // Enable OpenAPI in development
    app.MapScalarApiReference(); // Enable Swagger UI in development
}

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
