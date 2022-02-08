using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaintSharp.Core.Factories;
using PaintSharp.Core.Navigation;
using PaintSharp.Core.Navigation.Interfaces;
using PaintSharp.Core.Services;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State.ToolStateHelpers;
using PaintSharp.Core.ViewModels;
using PaintSharp.Core.ViewModels.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PaintSharp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDrawDelegatesHelper, DrawDelegatesHelper>();

            services.AddSingleton<IAddLayerService, AddLayerService>();
            services.AddSingleton<IToolStateChangerService, ToolStateChangerService>();

            services.AddSingleton<PenOptionsViewModel>();
            services.AddSingleton<EraserOptionsViewModel>();
            services.AddSingleton<SprayOptionsViewModel>();

            services.AddSingleton<ToolOptionsViewModelFactory>();
            services.AddSingleton<IToolOptionsNavigator, ToolOptionsNavigator>();

            services.AddSingleton<ToolBarViewModel>();
            services.AddSingleton<LayersBarViewModel>();
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
