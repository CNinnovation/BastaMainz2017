using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIWithContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();

            var controller = Container.GetRequiredService<HomeController>();
            string message = controller.Hello("Katharina");
            Console.WriteLine(message);
        }

        static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddTransient<HomeController>();
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
