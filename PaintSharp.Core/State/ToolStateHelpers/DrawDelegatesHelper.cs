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
                case ToolType.Spray:
                    ChangeToSpray();
                    break;
                case ToolType.Fill:
                    ToolState.IsToolOneClickType = true;
                    ToolState.DrawDelegate = new DrawDelegate(FloodFill);
                    break;
            }
        }

        #region ChangeToolType Methods

        private void ChangeToPen()
        {
            ToolState.IsToolOneClickType = false;

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
            ToolState.IsToolOneClickType = false;

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

        private void ChangeToSpray()
        {
            ToolState.IsToolOneClickType = false;

            switch (ToolState.ToolShape)
            {
                case ToolShape.Circle:
                    ToolState.DrawDelegate = new DrawDelegate(CircleSpray);
                    break;
                case ToolShape.Rect:
                    ToolState.DrawDelegate = new DrawDelegate(RectSpray);
                    break;
                default:
                    ToolState.DrawDelegate = new DrawDelegate(CircleSpray);
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
                    WriteableBitmapExtensions.ConvertColor(ToolState.BrushColor), true);
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
                    WriteableBitmapExtensions.ConvertColor(ToolState.BrushColor), true);
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

        private void CircleSpray(Point pt, WriteableBitmap writeableBitmap)
        {
            using (writeableBitmap.GetBitmapContext())
            {
                Random random = new Random();
                Color color = ToolState.BrushColor;

                int r = (int)ToolState.BrushRadius;
                for(int x = -r; x < r; x++)
                {
                    int height = (int)Math.Sqrt(r * r - x * x);
                    
                    for(int y = -height; y < height; y++)
                    {
                        color.A = (byte)random.Next(0, 30);
                        writeableBitmap.FillRectangle(((int)(x + pt.X)), ((int)(y + pt.Y)), ((int)(x + pt.X + 1)), ((int)(y + pt.Y + 1)), WriteableBitmapExtensions.ConvertColor(color), true);
                    }
                }
            }
        }

        private void RectSpray(Point pt, WriteableBitmap writeableBitmap)
        {
            using (writeableBitmap.GetBitmapContext())
            {
                Random random = new Random();
                Color color = ToolState.BrushColor;

                for (int i = 0; i < ToolState.BrushRadius*2; i++)
                {
                    for (int j = 0; j < ToolState.BrushRadius*2; j++)
                    {
                        color.A = (byte)random.Next(0, 30);

                        writeableBitmap.FillRectangle((int)pt.X - ((int)ToolState.BrushRadius) + i,
                                    (int)pt.Y - ((int)ToolState.BrushRadius) + j,
                                    (int)pt.X - ((int)ToolState.BrushRadius) + i + 1,
                                    (int)pt.Y - ((int)ToolState.BrushRadius) + j + 1,
                                    WriteableBitmapExtensions.ConvertColor(color), true);
                    }
                }
            }
        }
        private void FloodFill(Point pt, WriteableBitmap writeableBitmap)
        {
            Color oldColor = writeableBitmap.GetPixel(((int)pt.X), ((int)pt.Y));
            if (ToolState.BrushColor.Equals(oldColor))
            {
                return;
            }

            Stack<Point> pixels = new Stack<Point>();

            pixels.Push(pt);
            while(pixels.Count != 0)
            {
                Point temp = pixels.Pop();
                int y1 = ((int)temp.Y);
                while(y1 >= 0 && writeableBitmap.GetPixel(((int)temp.X), y1) == oldColor)
                {
                    y1--;
                }
                y1++;
                bool spanLeft = false;
                bool spanRight = false;
                while(y1 < writeableBitmap.PixelHeight && writeableBitmap.GetPixel(((int)temp.X), y1) == oldColor)
                {
                    writeableBitmap.SetPixel(((int)temp.X), y1, ToolState.BrushColor);

                    if (!spanLeft && temp.X > 1 && writeableBitmap.GetPixel(((int)temp.X) - 1, y1) == oldColor)
                    {
                        pixels.Push(new Point(temp.X - 1, y1));
                        spanLeft = true;
                    }
                    else if (spanLeft && temp.X - 1 == 0 && writeableBitmap.GetPixel(((int)temp.X) - 1, y1) != oldColor)
                    {
                        spanLeft = false;
                    }
                    if (!spanRight && temp.X < writeableBitmap.Width - 1 && writeableBitmap.GetPixel(((int)temp.X) + 1, y1) == oldColor)
                    {
                        pixels.Push(new Point(temp.X + 1, y1));
                        spanRight = true;
                    }
                    else if (spanRight && temp.X < writeableBitmap.Width - 1 && writeableBitmap.GetPixel(((int)temp.X) + 1, y1) != oldColor)
                    {
                        spanRight = false;
                    }
                    y1++;
                }
            }
        }

        #endregion
    }
}
