using PaintSharp.Core.Services.ServiceHelpers.Interfaces;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services.ServiceHelpers
{
    public class LayerCreatorHelper : ILayerCreatorHelper
    {
        public LayerViewModel CreateLayer()
        {
            return new LayerViewModel(Colors.Transparent);
        }

        public LayerViewModel CreateLayer(Color background)
        {
            return new LayerViewModel(background);
        }

        public ImageLayerViewModel CreateImageLayer(BitmapSource background, bool autoScale)
        {
            return new ImageLayerViewModel(background, autoScale);
        }
    }
}
