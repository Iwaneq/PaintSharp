using PaintSharp.Core.Services.Interfaces;
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
    public class AddLayerCommand : ICommand
    {
        private readonly IAddLayerService _addLayerService;

        #region Constructor / Setup

        public AddLayerCommand(IAddLayerService addLayerService)
        {
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
            _addLayerService.AddLayer("NewLayer", new Size(1, 1), Colors.Green);
        } 

        #endregion
    }
}
