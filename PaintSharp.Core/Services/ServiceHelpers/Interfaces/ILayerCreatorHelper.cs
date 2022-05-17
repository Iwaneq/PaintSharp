using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services.ServiceHelpers.Interfaces
{
    public interface ILayerCreatorHelper
    {
        LayerViewModel CreateLayer();
        LayerViewModel CreateLayer(Color background);
        ImageLayerViewModel CreateImageLayer(BitmapSource background, bool autoScale);
    }
}
