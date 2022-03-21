using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface IAddLayerService
    {
        void AddLayer(string name, Size size, Color background, bool isLayerTransparent);
        void AddLayer(string name, Size size, Color background, bool isLayerTransparent, float opacity);
        void AddLayer(string name, Size size, BitmapSource background, float opacity, bool autoScale);
    }
}
