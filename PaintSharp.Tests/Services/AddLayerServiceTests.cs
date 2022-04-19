using Autofac.Extras.Moq;
using Moq;
using PaintSharp.Core.Services;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.Services.ServiceHelpers.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xunit;

namespace PaintSharp.Tests.Services
{
    public class AddLayerServiceTests
    {
        [Fact]
        public void AddLayer_WithValidDataAndBackground_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var addLayerService = mock.Create<AddLayerService>();

                mock.Mock<ILayerCreatorHelper>()
                    .Setup(x => x.CreateLayer(Colors.Red))
                    .Returns(new LayerViewModel(Colors.Red));

                //Act
                addLayerService.AddLayer("Layer1", Colors.Red, false);

                //Assert 
                mock.Mock<ILayerCreatorHelper>()
                    .Verify(x => x.CreateLayer(Colors.Red), Times.Once);

                    //Checking Layer
                Assert.True(LayerState.Layers.Count == 1);

                var actualLayer = LayerState.Layers[0];
                Assert.NotNull(actualLayer.WriteableBitmap);
                Assert.True(actualLayer.Opacity == 100);

                Assert.NotNull(actualLayer.MouseDrawCommand);
                Assert.NotNull(actualLayer.LeftButtonDownCommand);
                Assert.NotNull(actualLayer.LeftButtonUpCommand);

                    //Checking LayerTab
                Assert.True(LayerState.LayerTabs.Count == 1);

                var actualTab = LayerState.LayerTabs[0];
                Assert.True(actualTab.Layer == actualLayer);
                Assert.True(actualTab.Name == "Layer1");

                LayerState.Layers.Clear();
                LayerState.LayerTabs.Clear();
            }
        }

        [Fact]
        public void AddLayer_WithValidDataAndTransparentBackground_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Arrange
                var addLayerService = mock.Create<AddLayerService>();

                mock.Mock<ILayerCreatorHelper>()
                    .Setup(x => x.CreateLayer())
                    .Returns(new LayerViewModel(Colors.Transparent));

                //Act
                addLayerService.AddLayer("Layer1", Colors.Red, true);

                //Assert 
                mock.Mock<ILayerCreatorHelper>()
                    .Verify(x => x.CreateLayer(), Times.Once);

                    //Checking Layer
                Assert.True(LayerState.Layers.Count == 1);

                var actualLayer = LayerState.Layers[0];
                Assert.NotNull(actualLayer.WriteableBitmap);
                Assert.True(actualLayer.Opacity == 100);

                Assert.NotNull(actualLayer.MouseDrawCommand);
                Assert.NotNull(actualLayer.LeftButtonDownCommand);
                Assert.NotNull(actualLayer.LeftButtonUpCommand);

                    //Checking LayerTab
                Assert.True(LayerState.LayerTabs.Count == 1);

                var actualTab = LayerState.LayerTabs[0];
                Assert.True(actualTab.Layer == actualLayer);
                Assert.True(actualTab.Name == "Layer1");

                LayerState.Layers.Clear();
                LayerState.LayerTabs.Clear();
            }
        }

        [Theory]
        [InlineData(-100f)]
        [InlineData(101f)]
        public void AddLayer_WithInvalidOpacity_ShouldThrowException(float opacity)
        {
            using(var mock = AutoMock.GetLoose())
            {
                var addLayerService = mock.Create<AddLayerService>();

                mock.Mock<ILayerCreatorHelper>()
                    .Setup(x => x.CreateLayer())
                    .Returns(new LayerViewModel(Colors.Transparent));

                Assert.Throws<ArgumentOutOfRangeException>("opacity", () => addLayerService.AddLayer("Layer1", Colors.Red, true, opacity));
            }
        }

        [Fact]
        public void AddImageLayer_WithValidData_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var addLayerService = mock.Create<AddLayerService>();
                var bitmapSource = GetBitmapSource();

                mock.Mock<ILayerCreatorHelper>()
                    .Setup(x => x.CreateImageLayer(bitmapSource, true))
                    .Returns(new ImageLayerViewModel(bitmapSource, true));

                addLayerService.AddImageLayer("ImageLayer1", bitmapSource, 100, true);

                mock.Mock<ILayerCreatorHelper>()
                    .Verify(x => x.CreateImageLayer(bitmapSource, true), Times.Once);

                Assert.True(LayerState.Layers.Count == 1);

                var actualLayer = LayerState.Layers[0];
                Assert.NotNull(actualLayer.WriteableBitmap);
                Assert.True(actualLayer.Opacity == 100);

                Assert.NotNull(actualLayer.MouseDrawCommand);
                Assert.NotNull(actualLayer.LeftButtonDownCommand);
                Assert.NotNull(actualLayer.LeftButtonUpCommand);

                Assert.True(LayerState.LayerTabs.Count == 1);

                var actualTab = LayerState.LayerTabs[0];
                Assert.True(actualTab.Layer == actualLayer);
                Assert.True(actualTab.Name == "ImageLayer1");

                LayerState.Layers.Clear();
                LayerState.LayerTabs.Clear();
            }
        }

        [Theory]
        [InlineData(-100f)]
        [InlineData(101f)]
        public void AddImageLayer_WithInvalidOpacity_ShouldThrowException(float opacity)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var addLayerService = mock.Create<AddLayerService>();
                var bitmapSource = GetBitmapSource();

                mock.Mock<ILayerCreatorHelper>()
                    .Setup(x => x.CreateImageLayer(bitmapSource, true))
                    .Returns(new ImageLayerViewModel(bitmapSource, true));

                Assert.Throws<ArgumentOutOfRangeException>("opacity", () => addLayerService.AddImageLayer("Layer1", bitmapSource, opacity, true));
            }
        }

        private BitmapSource GetBitmapSource()
        {

            return BitmapImage.Create(2, 2, 96, 96, PixelFormats.Indexed1, new BitmapPalette(new List<Color> { Colors.Transparent }), new byte[] { 0, 0, 0, 0 }, 1);
        }
    }
}
