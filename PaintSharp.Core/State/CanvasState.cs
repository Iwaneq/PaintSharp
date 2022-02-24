using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.State
{
    public static class CanvasState
    {
        private static double _canvasWidth;
        public static double CanvasWidth
        {
            get { return _canvasWidth; }
            set 
            {
                _canvasWidth = value;
                StateChanged?.Invoke();
            }
        }

        private static double _canvasHeight;
        public static double CanvasHeight
        {
            get { return _canvasHeight; }
            set
            {
                _canvasHeight = value;
                StateChanged?.Invoke();
            }
        }

        private static Color _canvasBackground;
        public static Color CanvasBackground
        {
            get { return _canvasBackground; }
            set 
            {
                _canvasBackground = value;
                StateChanged?.Invoke();
            }
        }


        public static event Action StateChanged;
    }
}
