using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintSharp.Core.Commands
{
    public class CreateNewFileCommand : ICommand
    {
        private readonly ICanvasStateChangerService _canvasStateChangerService;
        private readonly CreateNewFileViewModel _createNewFileViewModel;
        private readonly IAddLayerService _addLayerService;

        #region Constructor / Setup

        public CreateNewFileCommand(ICanvasStateChangerService canvasStateChangerService, CreateNewFileViewModel createNewFileViewModel, IAddLayerService addLayerService)
        {
            _canvasStateChangerService = canvasStateChangerService;
            _createNewFileViewModel = createNewFileViewModel;
            _addLayerService = addLayerService;
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
            _canvasStateChangerService.SetCanvas(_createNewFileViewModel.CanvasWidth,
                _createNewFileViewModel.CanvasHeight,
                _createNewFileViewModel.CanvasBackground,
                _createNewFileViewModel.IsCanvasTransparent);

            LayerState.ClearLayers();

            _addLayerService.AddLayer("Background", new Size(1, 1), Colors.Transparent);
        } 

        #endregion
    }
}
