using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface ICanvasStateChangerService
    {
        void SetCanvas(int width, int height, Color background, bool isTransparent);
    }
}
