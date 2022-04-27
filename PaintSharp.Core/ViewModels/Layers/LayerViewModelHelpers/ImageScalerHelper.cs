using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers.LayerViewModelHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.ViewModels.Layers.LayerViewModelHelpers
{
    public class ImageScalerHelper : IImageScalerHelper
    {
        public WriteableBitmap ScaleImage(WriteableBitmap oldBitmap)
        {
            //Get sizes of Old Bitmap
            float width = oldBitmap.PixelWidth;
            float height = oldBitmap.PixelHeight;

            //Get width offset between old bitmap and canvas and calculate scale precentage
            var widthOffset = width - CanvasState.CanvasWidth;
            var scalePrecentage = ((float)(widthOffset / width));

            //Calculate new image size with scale precentage
            width = width - (width * scalePrecentage);
            height = height - (height * scalePrecentage);

            //If image is still higher than Canvas, repeat the process
            if (height > CanvasState.CanvasHeight)
            {
                var heightOffset = height - CanvasState.CanvasHeight;
                scalePrecentage = ((float)(heightOffset / height));

                width = width - (width * scalePrecentage);
                height = height - (height * scalePrecentage);
            }

            //Return new resized bitmap
            return oldBitmap.Resize(((int)width), ((int)height), WriteableBitmapExtensions.Interpolation.Bilinear);
        }
    }
}
