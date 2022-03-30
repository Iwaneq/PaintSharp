using PaintSharp.Core.Navigation.Interfaces;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaintSharp.Core.Commands
{
    public class ChangeToolTypeCommand : ICommand
    {
        private readonly IToolStateChangerService _toolStateChanger;
        private readonly IToolOptionsNavigator _toolOptionsNavigator;
        private readonly ToolBarViewModel _toolBar;

        #region Constructor / Setup

        public ChangeToolTypeCommand(IToolStateChangerService toolStateChanger, IToolOptionsNavigator toolOptionsNavigator, ToolBarViewModel toolBar)
        {
            _toolStateChanger = toolStateChanger;
            _toolOptionsNavigator = toolOptionsNavigator;
            _toolBar = toolBar;
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
            //If ToolType hasn't been passed to command, return
            if (parameter == null) return;

            ToolType type = (ToolType)parameter; 

            //Change ToolType and Navigate to new ToolOptions
            _toolStateChanger.ChangeToolType(type);
            _toolOptionsNavigator.Navigate(type, _toolBar);
        }

        #endregion
    }
}
