using System.Diagnostics;
using Yzl.Extensions.Actuator.Abstractions;
using Yzl.Extensions.Actuator.Endpoints.Health;

namespace Yzl.Extensions.Actuator.Samples.Web.HealthContributors;

public sealed class DatabaseHealthContributor : IHealthContributor
{
    public string Name => "db";

    public Task<HealthComponent> CheckAsync(CancellationToken ct)
    {
        var sw = Stopwatch.StartNew();
        sw.Stop();

        return Task.FromResult(new HealthComponent
        {
            Status = HealthStatus.Up,
            Details = new Dictionary<string, object>
            {
                ["database"] = "sample-db",
                ["latency"] = $"{sw.ElapsedMilliseconds}ms"
            }
        });
    }
}
