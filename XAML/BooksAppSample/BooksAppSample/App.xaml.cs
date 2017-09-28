using BooksAppSample.WPFServices;
using BooksServices.Models;
using BooksServices.Services;
using BooksServices.ViewModels;
using CNElements.MVVM.Networking;
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
#if NET
            services.AddSingleton<IBooksService, NetBooksService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IHttpHelper<Book>, HttpHelper<Book>>();
#else
            services.AddSingleton<IBooksService, SampleBooksService>();
#endif
            services.AddTransient<BooksMasterDetailViewModel>();
            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton<IDialogService, WPFDialogService>();
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
    }
}
