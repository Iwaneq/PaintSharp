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
using PaintSharp.Core.Services.ServiceHelpers;
using PaintSharp.Core.Services.ServiceHelpers.Interfaces;
using PaintSharp.Core.State.ToolStateHelpers;
using PaintSharp.Core.State.ToolStateHelpers.ChangeToolTypeHelpers;
using PaintSharp.Core.ViewModels;
using PaintSharp.Core.ViewModels.Layers;
using PaintSharp.Core.ViewModels.Layers.LayerViewModelHelpers;
using PaintSharp.Core.ViewModels.Layers.LayerViewModelHelpers.Interfaces;
using PaintSharp.Core.ViewModels.Tools;
using PaintSharp.WPF.Services;
using Squirrel;
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
        protected override async void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            base.OnStartup(e);

            //If Application isn't in debug mode, check for Updates
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                await serviceProvider.GetRequiredService<IUpdateService>().CheckForUpdates(); 
            }
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            /*   ---   ADD FILE SYSTEMS   ---   */
            services.AddSingleton<IFile, FileSystem>();
            services.AddSingleton<IDirectory, DirectorySystem>();

            /*   ---   ADD SERVICE HELPERS   ---   */
            //CHANGE TOOL HELPERS
            services.AddSingleton<IDrawDelegatesHelper, DrawDelegatesHelper>();
            services.AddSingleton<ChangeToPenHelper>();
            services.AddSingleton<ChangeToEraserHelper>();
            services.AddSingleton<ChangeToSprayHelper>();
            services.AddSingleton<ChangeToFloodFillHelper>();

            services.AddSingleton<IToolStateChangerHelper, ToolStateChangerHelper>();

            services.AddSingleton<ILayerCreatorHelper, LayerCreatorHelper>();
            services.AddSingleton<IBitmapImageCreatorHelper, BitmapImageCreatorHelper>();

            services.AddSingleton<IImageScalerHelper, ImageScalerHelper>();


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
            services.AddSingleton<IUpdateService, UpdateService>();


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
