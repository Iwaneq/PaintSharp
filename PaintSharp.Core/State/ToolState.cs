using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PaintSharp.Core.State
{
    public static class ToolState
    {
        public static bool IsLeftButtonPressed { get; set; }


        private static Brush _brushColor = Brushes.Black;
        public static Brush BrushColor
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
