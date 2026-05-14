using Yzl.Extensions.Actuator;
using Yzl.Extensions.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpringNetActuator(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => new
{
    message = "Yzl.Extensions.Actuator Samples",
    actuator = "/actuator",
    examples = new[]
    {
        "/actuator/health",
        "/actuator/info",
        "/actuator/metrics",
        "/actuator/loggers",
        "/actuator/caches",
        "/cache/add?name=demo",
        "/logger?str=demo"
    }
});

app.UseSpringNetActuatorMapEndpoints(builder.Configuration);
app.MapControllers();
app.RegisterApplicationLifetimeEvents();

app.Run();
