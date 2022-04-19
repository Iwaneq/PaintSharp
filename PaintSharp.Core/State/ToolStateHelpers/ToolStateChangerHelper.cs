using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.State.ToolStateHelpers
{
    public class ToolStateChangerHelper : IToolStateChangerHelper
    {
        private readonly IChangeToolTypeHelper _changeToolTypeHelper;

        #region Constructor / Setup

        public ToolStateChangerHelper(IChangeToolTypeHelper changeToolTypeHelper)
        {
            _changeToolTypeHelper = changeToolTypeHelper;
        } 

        #endregion

        public void ChangeTool(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Pen:
                    _changeToolTypeHelper.ChangeToPen();
                    break;
                case ToolType.Eraser:
                    _changeToolTypeHelper.ChangeToEraser();
                    break;
                case ToolType.Spray:
                    _changeToolTypeHelper.ChangeToSpray();
                    break;
                case ToolType.Fill:
                    _changeToolTypeHelper.ChangeToFloodFill();
                    break;
            }
        }
    }
}
