using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PaintSharp.Core.Commands
{
    public class SaveCanvasCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        #region Constructor / Setup

        public SaveCanvasCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
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
        } 

        #endregion
    }
}
