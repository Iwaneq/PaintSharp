using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.Services
{
    public class CanvasStateChangerService : ICanvasStateChangerService
    {
        public void SetCanvas(int width, int height, Color background, bool isTransparent)
        {
            CanvasState.CanvasWidth = width;
            CanvasState.CanvasHeight = height;

            if (isTransparent)
            {
                CanvasState.CanvasBackground = Colors.Transparent;
            }
            else
            {
                CanvasState.CanvasBackground = background;
            }
        }
    }
}
