var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDaprClient();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();
app.UseCloudEvents();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapSubscribeHandler();
});

app.Run();
