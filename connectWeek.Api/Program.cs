using connectWeek.Api.Extensions;
using connectWeek.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar EF Core + PostgreSQL para usar Supabase
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Supabase"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerExtension();

var app = builder.Build();

// Swagger UI
app.UseSwaggerExtension();

// Develop
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => new
{
    message = "ConnectWeek API Working!",
    swagger = "/swagger",
    timestamp = DateTime.UtcNow
});

app.MapControllers();

app.Run();
