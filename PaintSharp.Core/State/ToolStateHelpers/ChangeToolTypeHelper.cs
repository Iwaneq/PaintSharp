using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.State.ToolStateHelpers
{
    public class ChangeToolTypeHelper : IChangeToolTypeHelper
    {
        private readonly IDrawDelegatesHelper _drawDelegatesHelper;

        #region Constructor / Setup

        public ChangeToolTypeHelper(IDrawDelegatesHelper drawDelegatesHelper)
        {
            _drawDelegatesHelper = drawDelegatesHelper;
        } 

        #endregion

        #region ChangeToolType Methods

        public void ChangeToPen()
        {
            ToolState.IsToolOneClickType = false;

            switch (ToolState.ToolShape)
            {
                case ToolShape.Circle:
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.DrawCircle);
                    break;
                case ToolShape.Rect:
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.DrawRect);
                    break;
                default:
                    //If provided ToolShape is not supported, set DrawDelegate to default value (Circle Pen)
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.DrawCircle);
                    break;
            }
        }

        public void ChangeToEraser()
        {
            ToolState.IsToolOneClickType = false;

            switch (ToolState.ToolShape)
            {
                case ToolShape.Circle:
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleErase);
                    break;
                case ToolShape.Rect:
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.RectErase);
                    break;
                default:
                    //If provided ToolShape is not supported, set DrawDelegate to default value (Circle Eraser)
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleErase);
                    break;
            }
        }

        public void ChangeToSpray()
        {
            ToolState.IsToolOneClickType = false;

            switch (ToolState.ToolShape)
            {
                case ToolShape.Circle:
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleSpray);
                    break;
                case ToolShape.Rect:
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.RectSpray);
                    break;
                default:
                    ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleSpray);
                    break;
            }
        }

        public void ChangeToFloodFill()
        {
            ToolState.IsToolOneClickType = true;
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.FloodFill);
        }

        #endregion

        
    }
}
