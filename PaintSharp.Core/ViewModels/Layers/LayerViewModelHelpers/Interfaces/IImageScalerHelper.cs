using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.ViewModels.Layers.LayerViewModelHelpers.Interfaces
{
    public interface IImageScalerHelper
    {
        WriteableBitmap ScaleImage(WriteableBitmap oldBitmap);
    }
}
