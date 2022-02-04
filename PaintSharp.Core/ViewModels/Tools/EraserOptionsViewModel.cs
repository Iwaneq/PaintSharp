using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.ViewModels.Tools
{
    public class EraserOptionsViewModel : BaseToolOptionsViewModel
    {
        public ChangeToolShapeCommand ChangeToolShapeCommand { get; set; }

        #region Constructor / Setup

        public EraserOptionsViewModel(IToolStateChangerService toolStateChanger) : base(toolStateChanger)
        {
            SetupHasOptionProperties();

            ChangeToolShapeCommand = new ChangeToolShapeCommand(toolStateChanger, ToolType);
        }

        private void SetupHasOptionProperties()
        {
            ToolType = ToolType.Eraser;
            HasSizeProperty = true;
            HasTypeProperty = true;
        }

        #endregion
    }
}
