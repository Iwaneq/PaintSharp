using PaintSharp.Core.State.ToolStateHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.State
{
    public enum ToolType
    {
        CirclePen,
        RectPen,
        CircleEraser,
        RectEraser
    }

    public delegate void DrawDelegate(Point pt, WriteableBitmap writeableBitmap);

    public static class ToolState
    {
        public static bool IsLeftButtonPressed { get; set; }
        public static DrawDelegate DrawDelegate { get; set; }


        private static Color _brushColor = Colors.Black;
        public static Color BrushColor
        {
            get { return _brushColor; }
            set { _brushColor = value; }
        }

        private static Size _brushSize = new Size(5,5);
        public static Size BrushSize
        {
            get { return _brushSize; }
            set { _brushSize = value; }
        }
    }
}
