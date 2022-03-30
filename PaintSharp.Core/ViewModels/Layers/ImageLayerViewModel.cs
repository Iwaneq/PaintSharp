using PaintSharp.Core.State;
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
        #region Constructor / Setup

        public ImageLayerViewModel(BitmapSource background, bool autoScale)
        {
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

            float width = layer.PixelWidth;
            float height = layer.PixelHeight;

            var widthOffset = width - CanvasState.CanvasWidth;
            var scalePrecentage = ((float)(widthOffset / width));

            width = width - (width * scalePrecentage);
            height = height - (height * scalePrecentage);

            if (height > CanvasState.CanvasHeight)
            {
                var heightOffset = height - CanvasState.CanvasHeight;
                scalePrecentage = ((float)(heightOffset / height));

                width = width - (width * scalePrecentage);
                height = height - (height * scalePrecentage);
            }

            WriteableBitmap = layer.Resize(((int)width), ((int)height), WriteableBitmapExtensions.Interpolation.Bilinear);
        }

        #endregion
    }
}
