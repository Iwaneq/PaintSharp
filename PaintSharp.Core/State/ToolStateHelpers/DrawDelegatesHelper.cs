using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PaintSharp.Core.State.ToolStateHelpers
{
    public class DrawDelegatesHelper : IDrawDelegatesHelper
    {
        public void ChangeDrawDelegate(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.CirclePen:
                    ToolState.DrawDelegate = new DrawDelegate(DrawCircle);
                    break;
                case ToolType.RectPen:
                    ToolState.DrawDelegate = new DrawDelegate(DrawRect);
                    break;
                case ToolType.Eraser:
                    ToolState.DrawDelegate = new DrawDelegate(Erase);
                    break;
            }
        }

        #region Draw Delegates

        private void DrawCircle(Point pt, DrawingContext context)
        {
            Rect rect = new Rect(pt, ToolState.BrushSize);
            context.DrawRoundedRectangle(ToolState.BrushColor, null, rect, ToolState.BrushSize.Width, ToolState.BrushSize.Height);
        }
        private void DrawRect(Point pt, DrawingContext context)
        {
            Rect rect = new Rect(pt, ToolState.BrushSize);
            context.DrawRectangle(ToolState.BrushColor, null, rect);
        }

        private void Erase(Point pt, DrawingContext context)
        {
            Rect rect = new Rect(pt, ToolState.BrushSize);
            context.DrawRoundedRectangle(new SolidColorBrush(Colors.Transparent), null, rect, ToolState.BrushSize.Width, ToolState.BrushSize.Height);
        }

        #endregion
    }
}
