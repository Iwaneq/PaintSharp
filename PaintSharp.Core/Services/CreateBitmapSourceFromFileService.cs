using Iwaneq.FileSystem.Systems.Interfaces;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.Services.ServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services
{
    public class CreateBitmapSourceFromFileService : ICreateBitmapSourceFromFileService
    {
        private readonly IBitmapImageCreatorHelper _bitmapImageCreatorHelper;
        private readonly IFile _fileSystem;

        public CreateBitmapSourceFromFileService(IBitmapImageCreatorHelper bitmapImageCreatorHelper, IFile fileSystem)
        {
            _bitmapImageCreatorHelper = bitmapImageCreatorHelper;
            _fileSystem = fileSystem;
        }

        public BitmapSource CreateBitmapSource(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }
            if (!_fileSystem.Exists(filePath))
            {
                throw new FileNotFoundException("File is valid!", filePath);
            }

            BitmapImage image = _bitmapImageCreatorHelper.CreateBitmapImage(filePath, UriKind.Absolute);
            double dpi = 96;

            int stride = image.PixelWidth * 4;
            byte[] pixelData = new byte[stride * image.PixelHeight];

            image.CopyPixels(pixelData, stride, 0);

            return BitmapSource.Create(image.PixelWidth, image.PixelHeight, dpi, dpi, PixelFormats.Bgra32, null, pixelData, stride);
        }
    }
}
