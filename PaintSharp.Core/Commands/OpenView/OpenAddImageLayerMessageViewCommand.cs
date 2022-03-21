using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaintSharp.Core.Commands.OpenView
{
    public class OpenAddImageLayerMessageViewCommand : ICommand
    {
        private readonly IOpenWindowService _openWindowService;
        private readonly AddImageLayerMessageViewModel _addImageLayerMessageView;

        #region Constructor / Setup

        public OpenAddImageLayerMessageViewCommand(IOpenWindowService openWindowService, AddImageLayerMessageViewModel addImageLayerMessageView)
        {
            _openWindowService = openWindowService;
            _addImageLayerMessageView = addImageLayerMessageView;
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
            _addImageLayerMessageView.ResetViewModel();
            _openWindowService.OpenWindow("Add Image Layer", _addImageLayerMessageView, 400, 300);
        } 

        #endregion
    }
}
