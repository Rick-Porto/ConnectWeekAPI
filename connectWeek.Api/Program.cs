using connectWeek.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerExtension();

var app = builder.Build();

app.UseSwaggerExtension();

// Configure the HTTP request pipeline.
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
