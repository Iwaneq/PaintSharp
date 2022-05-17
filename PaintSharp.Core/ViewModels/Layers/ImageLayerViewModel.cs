using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers.LayerViewModelHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.ViewModels.Layers
{
    public class ImageLayerViewModel : BaseLayerViewModel
    {
        private readonly IImageScalerHelper _imageScalerHelper;

        #region Constructor / Setup

        public ImageLayerViewModel(BitmapSource background, bool autoScale, IImageScalerHelper imageScalerHelper)
        {
            _imageScalerHelper = imageScalerHelper;

            if (autoScale)
            {
                var layer = new WriteableBitmap(background);
                ScaleImageLayer(layer);
            }
            else
            {
                WriteableBitmap = new WriteableBitmap(background);
            }

            SetupCommands();
        }

        private void ScaleImageLayer(WriteableBitmap layer)
        {
            WriteableBitmap = _imageScalerHelper.ScaleImage(layer);
        }

        #endregion
    }
}
