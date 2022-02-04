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
    public class ChangeToolShapeCommand : ICommand
    {
        private readonly IToolStateChangerService _toolStateChanger;
        private readonly ToolType _toolType;

        #region Constructor / Setup

        public ChangeToolShapeCommand(IToolStateChangerService toolStateChanger, ToolType toolType)
        {
            _toolStateChanger = toolStateChanger;
            _toolType = toolType;
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

            ToolShape shape = (ToolShape)parameter;
            _toolStateChanger.ChangeToolShape(shape, _toolType);
        } 

        #endregion
    }
}
