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
    public class DrawDelegatesHelper : IDrawDelegatesHelper
    {
        public void ChangeTool(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Pen:
                    ChangeToPen();
                    break;
                case ToolType.Eraser:
                    ChangeToEraser();
                    break;
            }
        }

        #region ChangeToolType Methods

        private void ChangeToPen()
        {
            switch (ToolState.ToolShape)
            {
                case ToolShape.Circle:
                    ToolState.DrawDelegate = new DrawDelegate(DrawCircle);
                    break;
                case ToolShape.Rect:
                    ToolState.DrawDelegate = new DrawDelegate(DrawRect);
                    break;
                default:
                    //If provided ToolShape is not supported, set DrawDelegate to default value (Circle Pen)
                    ToolState.DrawDelegate = new DrawDelegate(DrawCircle);
                    break;
            }
        }

        private void ChangeToEraser()
        {
            switch (ToolState.ToolShape)
            {
                case ToolShape.Circle:
                    ToolState.DrawDelegate = new DrawDelegate(CircleErase);
                    break;
                case ToolShape.Rect:
                    ToolState.DrawDelegate = new DrawDelegate(RectErase);
                    break;
                default:
                    //If provided ToolShape is not supported, set DrawDelegate to default value (Circle Eraser)
                    ToolState.DrawDelegate = new DrawDelegate(CircleErase);
                    break;
            }
        }

        #endregion

        #region Draw Delegates

        private void DrawCircle(Point pt, WriteableBitmap writeableBitmap)
        {
            using (writeableBitmap.GetBitmapContext())
            {
                writeableBitmap.FillEllipseCentered(((int)pt.X),
                    ((int)pt.Y), 
                    ((int)ToolState.BrushSize.Width),
                    ((int)ToolState.BrushSize.Height),
                    ToolState.BrushColor);
            }
        }
        private void DrawRect(Point pt, WriteableBitmap writeableBitmap)
        {
            using (writeableBitmap.GetBitmapContext())
            {
                writeableBitmap.FillRectangle((int)pt.X - ((int)ToolState.BrushSize.Width / 2),
                    (int)pt.Y - ((int)ToolState.BrushSize.Height / 2),
                    ((int)pt.X) + ((int)ToolState.BrushSize.Width ),
                    ((int)pt.Y) + ((int)ToolState.BrushSize.Height ),
                    ToolState.BrushColor);
            }
        }

        private void CircleErase(Point pt, WriteableBitmap writeableBitmap)
        {
            using (writeableBitmap.GetBitmapContext())
            {
                writeableBitmap.FillEllipseCentered(((int)pt.X),
                    ((int)pt.Y),
                    ((int)ToolState.BrushSize.Width),
                    ((int)ToolState.BrushSize.Height),
                    Colors.Transparent);
            }
        }
        private void RectErase(Point pt, WriteableBitmap writeableBitmap)
        {
            using (writeableBitmap.GetBitmapContext())
            {
                writeableBitmap.FillRectangle((int)pt.X - ((int)ToolState.BrushSize.Width / 2),
                    (int)pt.Y - ((int)ToolState.BrushSize.Height / 2),
                    ((int)pt.X) + ((int)ToolState.BrushSize.Width),
                    ((int)pt.Y) + ((int)ToolState.BrushSize.Height),
                    Colors.Transparent);
            }
        }

        #endregion
    }
}
