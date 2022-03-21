using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PaintSharp.Core.ViewModels.Tools
{
    public class PenOptionsViewModel : BaseToolOptionsViewModel
    {
        #region Constructor / Setup

        public PenOptionsViewModel(IToolStateChangerService toolStateChanger) : base(toolStateChanger)
        {
            SetupHasOptionProperties();

            ChangeToolShapeCommand = new ChangeToolShapeCommand(toolStateChanger, ToolType);
        }

        private void SetupHasOptionProperties()
        {
            ToolType = ToolType.Pen;
            HasSizeProperty = true;
            HasTypeProperty = true;
        }

        #endregion
    }
}
