using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services
{
    public class CreateBitmapSourceFromFileService : ICreateBitmapSourceFromFileService
    {
        public BitmapSource CreateBitmapSource(string filePath)
        {
            BitmapImage image = new BitmapImage(new Uri(filePath, UriKind.Absolute));
            double dpi = 96;

            int stride = image.PixelWidth * 4;
            byte[] pixelData = new byte[stride * image.PixelHeight];

            image.CopyPixels(pixelData, stride, 0);

            return BitmapSource.Create(image.PixelWidth, image.PixelHeight, dpi, dpi, PixelFormats.Bgra32, null, pixelData, stride);
        }
    }
}
