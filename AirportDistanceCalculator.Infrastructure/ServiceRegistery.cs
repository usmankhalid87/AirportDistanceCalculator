using AirportDistanceCalculator.Core.Application;
using AirportDistanceCalculator.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace AirportDistanceCalculator.Infrastructure
{
    public static class ServiceRegistery
    {
        private static int _retryCount = GlobalConstants.NumberOfRetries;
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient("AirportDistanceCalculator", option =>
            {
                option.DefaultRequestHeaders.Add("User-Agent", "AirportDistanceCalculator");
            })
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(_retryCount))
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(_retryCount, TimeSpan.FromSeconds(30)));

            services.AddTransient<IAirportService, AirportService>();
            services.AddTransient<IAirportDistanceService, AirportDistanceService>();
        }
    }
}