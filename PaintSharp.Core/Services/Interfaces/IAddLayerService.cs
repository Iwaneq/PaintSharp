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
        void AddLayer(string name, Color background, bool isLayerTransparent);
        void AddLayer(string name, Color background, bool isLayerTransparent, float opacity);
        void AddImageLayer(string name, BitmapSource background, float opacity, bool autoScale);
    }
}
