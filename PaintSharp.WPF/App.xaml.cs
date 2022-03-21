using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaintSharp.Core.Factories;
using PaintSharp.Core.Navigation;
using PaintSharp.Core.Navigation.Interfaces;
using PaintSharp.Core.Services;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State.ToolStateHelpers;
using PaintSharp.Core.ViewModels;
using PaintSharp.Core.ViewModels.Layers;
using PaintSharp.Core.ViewModels.Tools;
using PaintSharp.WPF.Services;
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

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDrawDelegatesHelper, DrawDelegatesHelper>();

            services.AddSingleton<IChangeLayerVisibilityService, ChangeLayerVisibilityService>();
            services.AddSingleton<IAddLayerService, AddLayerService>();
            services.AddSingleton<IDeleteLayerService, DeleteLayerService>();
            services.AddSingleton<IToolStateChangerService, ToolStateChangerService>();
            services.AddSingleton<ICanvasStateChangerService, CanvasStateChangerService>();
            services.AddSingleton<ICreateBitmapSourceFromFileService, CreateBitmapSourceFromFileService>();

            services.AddSingleton<IOpenWindowService, OpenWindowService>();
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<ISaveCanvasService, SaveCanvasService>();

            services.AddSingleton<PenOptionsViewModel>();
            services.AddSingleton<EraserOptionsViewModel>();
            services.AddSingleton<SprayOptionsViewModel>();
            services.AddSingleton<EmptyOptionsViewModel>();

            services.AddSingleton<ToolOptionsViewModelFactory>();
            services.AddSingleton<IToolOptionsNavigator, ToolOptionsNavigator>();

            services.AddSingleton<AddLayerMessageViewModel>();
            services.AddSingleton<AddImageLayerMessageViewModel>();
            services.AddSingleton<CreateNewFileViewModel>();

            services.AddSingleton<ToolBarViewModel>();
            services.AddSingleton<LayersBarViewModel>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
