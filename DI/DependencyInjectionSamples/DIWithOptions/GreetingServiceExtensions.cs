using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIWithOptions
{
    public static class GreetingServiceExtensions
    {
        public static IServiceCollection AddGreetingService(this IServiceCollection services,
            Action<GreetingServiceOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            services.Configure(setupAction);
            return services.AddTransient<IGreetingService, GreetingService>();
        }
    }
}
