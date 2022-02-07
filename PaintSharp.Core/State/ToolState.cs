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
        Pen,
        Eraser,
        Spray
    }
    public enum ToolShape
    {
        Circle,
        Rect
    }

    public delegate void DrawDelegate(Point pt, WriteableBitmap writeableBitmap);

    public static class ToolState
    {
        public static bool IsLeftButtonPressed { get; set; }
        public static DrawDelegate DrawDelegate { get; set; }
        public static ToolShape ToolShape { get; set; } = ToolShape.Circle;

        private static Color _brushColor = Colors.Black;
        public static Color BrushColor
        {
            get { return _brushColor; }
            set { _brushColor = value; }
        }

        private static Size _brushSize = new Size(10,10);
        public static Size BrushSize
        {
            get { return _brushSize; }
            set { _brushSize = value; }
        }

        private static int _brushRadius = 10;
        public static int BrushRadius
        {
            get { return _brushRadius; }
            set { _brushRadius = value; }
        }

    }
}
