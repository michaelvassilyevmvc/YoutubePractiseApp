using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace YoutubePractise.HealthChecksExtensions
{
    public class CustomHealthCheck: IHealthCheck
    {
        private Random _random = new Random();
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var responseTime = _random.Next(1, 300);
            return Task.FromResult(responseTime switch
            {
                < 100 => HealthCheckResult.Healthy("Healthy result from CustomHealthChecks"),
                (> 100) and (< 200) => HealthCheckResult.Degraded("Degrated result from CustomHealthCheck"),
                _ => HealthCheckResult.Unhealthy("Unhealthy result from CustomHealthCheck")
            });
        }
    }
}
