using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using static FrameShopWPF.ConfigAccess;

namespace FrameShopWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var service = new ServiceCollection();
            ConfigureServices(service);
            ServiceProvider = service.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceCollection.BuildServiceProvider();

            var viewModel = new MainViewModel(ServiceProvider.GetService<IFrameService>(), 
                ServiceProvider.GetService<IFrameShopService>(), ServiceProvider.GetService<IMaterialService>());

            var mainWindow = new MainWindow() { DataContext = viewModel };

            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FrameShopDbContext>(opt =>
                opt.UseSqlServer(ConnectionString));
            services.AddTransient(typeof(MainWindow));
            services.AddScoped<IRepository<Frame>, Repository<Frame>>();
            services.AddScoped<IRepository<FrameShop>, Repository<FrameShop>>();
            services.AddScoped<IRepository<Material>, Repository<Material>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(new MapperConfiguration(c => c.AddProfile(new Mapper())).CreateMapper());
            services.AddTransient<IFrameService, FrameService>();
            services.AddTransient<IFrameShopService, FrameShopService>();
            services.AddTransient<IMaterialService, MaterialService>();
        }
    }
}
