using Yzl.Extensions.Actuator.Abstractions;
using Yzl.Extensions.Actuator.Endpoints.Health;

namespace Yzl.Extensions.Actuator.Samples.Web.HealthContributors;

public sealed class RedisHealthContributor : IHealthContributor
{
    public string Name => "redis";

    public Task<HealthComponent> CheckAsync(CancellationToken ct)
    {
        return HealthComponents.Up();
    }
}
