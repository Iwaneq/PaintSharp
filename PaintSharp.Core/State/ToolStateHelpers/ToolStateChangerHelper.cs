using PaintSharp.Core.State.ToolStateHelpers.ChangeToolTypeHelpers;
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
        private IChangeToolTypeHelper _currentChangeToolTypeHelper;
        private readonly ChangeToPenHelper _changeToPen;
        private readonly ChangeToEraserHelper _changeToEraser;
        private readonly ChangeToSprayHelper _changeToSpray;
        private readonly ChangeToFloodFillHelper _changeToFloodFill;

        #region Constructor / Setup

        public ToolStateChangerHelper(ChangeToPenHelper changeToPen, 
        ChangeToEraserHelper changeToEraser, 
        ChangeToSprayHelper changeToSpray, 
        ChangeToFloodFillHelper changeToFloodFill)
        {
            _changeToPen = changeToPen;
            _changeToEraser = changeToEraser;
            _changeToSpray = changeToSpray;
            _changeToFloodFill = changeToFloodFill;
        }

        #endregion

        public void ChangeTool(ToolType toolType)
        {
            SetCurrentToolType(toolType);

            _currentChangeToolTypeHelper.ChangeClickBooleans();

            ChangeToolShape();
        }

        public void ChangeToolShape()
        {
            switch (ToolState.ToolShape)
            {
                case ToolShape.Circle:
                    _currentChangeToolTypeHelper.ChangeToCircle();
                    break;
                case ToolShape.Rect:
                    _currentChangeToolTypeHelper.ChangeToRect();
                    break;
                default:
                    //If provided ToolShape is not supported, set DrawDelegate to default value
                    _currentChangeToolTypeHelper.ChangeToDefault();
                    break;
            }
        }

        public void SetCurrentToolType(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Pen:
                    _currentChangeToolTypeHelper = _changeToPen;
                    break;
                case ToolType.Eraser:
                    _currentChangeToolTypeHelper = _changeToEraser;
                    break;
                case ToolType.Spray:
                    _currentChangeToolTypeHelper = _changeToSpray;
                    break;
                case ToolType.Fill:
                    _currentChangeToolTypeHelper = _changeToFloodFill;
                    break;
                default:
                    throw new NotImplementedException($"Provided ToolType: {toolType} is not implemented!");
            }
        }
    }
}
