using Iwaneq.FileSystem.Systems;
using Iwaneq.FileSystem.Systems.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaintSharp.Core.Commands.OpenView;
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

            /*   ---   ADD FILE SYSTEMS   ---   */
            services.AddSingleton<IFile, FileSystem>();
            services.AddSingleton<IDirectory, DirectorySystem>();

            /*   ---   ADD SERVICE HELPERS   ---   */
            services.AddSingleton<IToolStateChangerHelper, ToolStateChangerHelper>();


            /*   ---   ADD BASIC SERVICES   ---   */
            services.AddSingleton<IChangeLayerVisibilityService, ChangeLayerVisibilityService>();
            services.AddSingleton<IAddLayerService, AddLayerService>();
            services.AddSingleton<IDeleteLayerService, DeleteLayerService>();
            services.AddSingleton<IToolStateChangerService, ToolStateChangerService>();
            services.AddSingleton<ICanvasStateChangerService, CanvasStateChangerService>();
            services.AddSingleton<ICreateBitmapSourceFromFileService, CreateBitmapSourceFromFileService>();


            /*   ---   ADD WINDOWS-SPECIFIC SERVICES   ---   */
            services.AddSingleton<IOpenWindowService, OpenWindowService>();
            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<ISaveCanvasService, SaveCanvasService>();


            /*   ---   ADD ADD/CREATE MESSAGE VIEW MODELS   ---   */
            services.AddTransient<AddLayerMessageViewModel>();
            services.AddTransient<AddImageLayerMessageViewModel>();
            services.AddTransient<CreateNewFileViewModel>();


            /*   ---   ADD TOOL OPTIONS VIEW MODELS   ---   */
            services.AddSingleton<PenOptionsViewModel>();
            services.AddSingleton<EraserOptionsViewModel>();
            services.AddSingleton<SprayOptionsViewModel>();
            services.AddSingleton<EmptyOptionsViewModel>();


            /*   ---   ADD FACTORIES AND NAVIGATORS   ---   */
            services.AddSingleton<ToolOptionsViewModelFactory>();
            services.AddSingleton<IToolOptionsNavigator, ToolOptionsNavigator>();


            /*   ---   ADD BASIC VIEW MODELS   ---   */
            services.AddSingleton<ToolBarViewModel>();
            services.AddSingleton<LayersBarViewModel>();


            /*   ---   ADD MAIN OBJECTS   ---   */
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
