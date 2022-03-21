using PaintSharp.Core.Exceptions;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaintSharp.Core.Commands
{
    public class AddImageLayerCommand : ICommand
    {
        private readonly IAddLayerService _addLayerService;
        private readonly ICreateBitmapSourceFromFileService _createBitmapSourceFromFileService;
        private readonly IMessageBoxService _messageBoxService;

        #region Constructor / Setup

        public AddImageLayerCommand(IAddLayerService addLayerService, ICreateBitmapSourceFromFileService createBitmapSourceFromFileService, IMessageBoxService messageBoxService)
        {
            _addLayerService = addLayerService;
            _createBitmapSourceFromFileService = createBitmapSourceFromFileService;
            _messageBoxService = messageBoxService;
        }

        #endregion

        #region Command

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //if ViewModel hasn't been passed to command, return
            if (parameter == null) return;

            var viewModel = (AddImageLayerMessageViewModel)parameter;

            //if ViewModel's background file path is not valid, show error message
            if (string.IsNullOrEmpty(viewModel.BackgroundFilePath)) 
            {
                _messageBoxService.ShowError("Image path not valid", "Cannot create Image Layer without image. Make sure your Image Path is valid!");
                return;
            }

            //Get BitmapSource for Layer's background
            var background = _createBitmapSourceFromFileService.CreateBitmapSource(viewModel.BackgroundFilePath);

            //Add new Layer
            _addLayerService.AddLayer(viewModel.LayerName, new System.Windows.Size(1, 1), background, ((float)viewModel.LayerOpacity)/100, viewModel.AutoScaleImage);
        } 

        #endregion
    }
}
