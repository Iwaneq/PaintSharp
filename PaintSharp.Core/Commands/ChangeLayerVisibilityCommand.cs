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
    public class ChangeLayerVisibilityCommand : ICommand
    {
        private readonly LayerTabViewModel _layerTab;
        private readonly IChangeLayerVisibilityService _changeLayerVisibilityService;

        #region Constructor / Setup

        public ChangeLayerVisibilityCommand(LayerTabViewModel layerTab, IChangeLayerVisibilityService changeLayerVisibilityService)
        {
            _layerTab = layerTab;
            _changeLayerVisibilityService = changeLayerVisibilityService;
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
            _changeLayerVisibilityService.ChangeLayerVisibility(_layerTab.Layer);
        } 

        #endregion
    }
}
