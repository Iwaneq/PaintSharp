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
    public class SprayOptionsViewModel : BaseToolOptionsViewModel
    {
        public ChangeToolShapeCommand ChangeToolShapeCommand { get; set; }

        #region Constructor / Setup

        public SprayOptionsViewModel(IToolStateChangerService toolStateChangerService) : base(toolStateChangerService)
        {
            ChangeToolShapeCommand = new ChangeToolShapeCommand(toolStateChangerService, ToolType.Spray);

            SetupHasOptionProperties();
        } 

        private void SetupHasOptionProperties()
        {
            ToolType = ToolType.Spray;
            HasRadiusProperty = true;
            HasTypeProperty = true;
        }

        #endregion
    }
}
