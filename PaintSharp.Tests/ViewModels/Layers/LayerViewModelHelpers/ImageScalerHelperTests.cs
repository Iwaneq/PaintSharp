using Moq;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers.LayerViewModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Xunit;

namespace PaintSharp.Tests.ViewModels.Layers.LayerViewModelHelpers
{
    public class ImageScalerHelperTests
    {
        private readonly ImageScalerHelper _imageScalerHelper;

        public ImageScalerHelperTests()
        {
            _imageScalerHelper = new Mock<ImageScalerHelper>().Object;
        }

        [Fact]
        public void ScaleImage_WithBitmapSmallerThanCanvas_ShouldWork()
        {
            var bitmap = BitmapFactory.New(10, 10);
            CanvasState.CanvasWidth = 100;
            CanvasState.CanvasHeight = 100;

            bitmap = _imageScalerHelper.ScaleImage(bitmap);

            Assert.Equal(100, bitmap.PixelHeight);
            Assert.Equal(100, bitmap.PixelWidth);
        }

        [Fact]
        public void ScaleImage_WithBitmapLargerThanCanvas_ShouldWork()
        {
            var bitmap = BitmapFactory.New(200, 200);
            CanvasState.CanvasWidth = 100;
            CanvasState.CanvasHeight = 100;

            bitmap = _imageScalerHelper.ScaleImage(bitmap);

            Assert.Equal(100, bitmap.PixelHeight);
            Assert.Equal(100, bitmap.PixelWidth);
        }
    }
}
