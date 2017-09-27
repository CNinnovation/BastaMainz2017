using BooksServices.Services;
using BooksServices.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism.Events;
using System;
using System.Windows;

namespace BooksAppSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterServices();
        }

        public void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IBooksService, SampleBooksService>();
            services.AddTransient<BooksMasterDetailViewModel>();
            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
    }
}
