using Autofac.Extras.Moq;
using PaintSharp.Core.Services;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaintSharp.Tests.Services
{
    public class DeleteLayerServiceTests
    {
        [Fact]
        public void DeleteLayer_WithValidData_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                //Arrange
                LayerViewModel layerViewModel = new LayerViewModel();
                LayerTabViewModel layerTab = mock.Create<LayerTabViewModel>();
                layerTab.Layer = layerViewModel;

                var deleteLayerSerivce = mock.Create<DeleteLayerService>();

                LayerState.LayerTabs.Add(layerTab);
                LayerState.Layers.Add(layerViewModel);

                //Act
                deleteLayerSerivce.DeleteLayer(layerTab);

                //Assert
                Assert.Empty(LayerState.Layers);
                Assert.Empty(LayerState.LayerTabs);
            }
        }

        [Fact]
        public void DeleteLayer_WithTabWithoutLayer_ShouldDeleteOnlyLayerTab()
        {
            using(var mock = AutoMock.GetLoose())
            {
                LayerTabViewModel layerTab = mock.Create<LayerTabViewModel>();

                var deleteLayerService = mock.Create<DeleteLayerService>();

                deleteLayerService.DeleteLayer(layerTab);
            }
        }

        [Fact]
        public void DeleteLayer_WithNullParameter_ShouldThrowException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var deleteLayerService = mock.Create<DeleteLayerService>();

                Assert.Throws<ArgumentNullException>("layerTab", () => deleteLayerService.DeleteLayer(null));
            }
        }
    }
}
