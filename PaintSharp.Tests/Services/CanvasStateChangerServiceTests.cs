using Autofac.Extras.Moq;
using PaintSharp.Core.Services;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xunit;

namespace PaintSharp.Tests.Services
{
    public class CanvasStateChangerServiceTests
    {
        [Fact]
        public void SetCanvas_WithValidData_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var canvasStateChangerService = mock.Create<CanvasStateChangerService>();

                canvasStateChangerService.SetCanvas(100, 100, Colors.Red, false);

                Assert.Equal(100, CanvasState.CanvasWidth);
                Assert.Equal(100, CanvasState.CanvasHeight);
                Assert.Equal(Colors.Red, CanvasState.CanvasBackground);
            }
        }

        [Fact]
        public void SetCanvas_WithIsTransparentTrue_ShouldSetTransparentBackground()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var canvasStateChangerService = mock.Create<CanvasStateChangerService>();

                canvasStateChangerService.SetCanvas(100, 100, Colors.Red, true);

                Assert.Equal(100, CanvasState.CanvasWidth);
                Assert.Equal(100, CanvasState.CanvasHeight);
                Assert.Equal(Colors.Transparent, CanvasState.CanvasBackground);
            }
        }

        [Theory]
        [InlineData(0,0, "width")]
        [InlineData(-1, -1, "width")]
        [InlineData(10, -10, "height")]
        [InlineData(-100, 100, "width")]
        public void SetCanvas_WithInvalidSize_ShouldThrowException(int width, int height, string paramName)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var canvasStateChangerService = mock.Create<CanvasStateChangerService>();

                Assert.Throws<ArgumentOutOfRangeException>(paramName, () => canvasStateChangerService.SetCanvas(width, height, Colors.Red, false));
            }
        }
    }
}
