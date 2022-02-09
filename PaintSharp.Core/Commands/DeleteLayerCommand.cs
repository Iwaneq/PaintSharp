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
    public class DeleteLayerCommand : ICommand
    {
        private readonly IDeleteLayerService _deleteLayerService;

        #region Constructor / Setup

        public DeleteLayerCommand(IDeleteLayerService deleteLayerService)
        {
            _deleteLayerService = deleteLayerService;
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
            if (parameter == null) return;

            LayerTabViewModel layerTab = (LayerTabViewModel)parameter;

            _deleteLayerService.DeleteLayer(layerTab);
        } 

        #endregion
    }
}
