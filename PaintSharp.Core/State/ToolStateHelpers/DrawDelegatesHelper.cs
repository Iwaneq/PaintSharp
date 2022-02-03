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
                case ToolType.CircleEraser:
                    ToolState.DrawDelegate = new DrawDelegate(CircleErase);
                    break;
            }
        }

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

        #endregion
    }
}
