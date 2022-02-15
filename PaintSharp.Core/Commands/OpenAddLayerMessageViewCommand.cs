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
    public class OpenAddLayerMessageViewCommand : ICommand
    {
        private readonly IOpenWindowService _openWindowService;
        private readonly AddLayerMessageViewModel _addLayerMessageViewModel;

        #region Constructor / Setup

        public OpenAddLayerMessageViewCommand(IOpenWindowService openWindowService, AddLayerMessageViewModel addLayerMessageViewModel)
        {
            _openWindowService = openWindowService;
            _addLayerMessageViewModel = addLayerMessageViewModel;
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
            _addLayerMessageViewModel.ResetViewModel();
            _openWindowService.OpenWindow("Add Layer", _addLayerMessageViewModel, 400, 300);
        } 

        #endregion
    }
}
