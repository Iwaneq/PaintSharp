using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
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

        #region Constructor / Setup

        public ChangeToolTypeCommand(IToolStateChangerService toolStateChanger)
        {
            _toolStateChanger = toolStateChanger;
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

            ToolType type = (ToolType)parameter; 

            _toolStateChanger.ChangeToolType(type);
        }

        #endregion
    }
}
