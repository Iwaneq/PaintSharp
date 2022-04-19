using PaintSharp.Core.Services;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaintSharp.Tests.Services
{
    public class ChangeLayerVisibilityServiceTests
    {
        private BaseLayerViewModel _layer;

        public ChangeLayerVisibilityServiceTests()
        {
            _layer = new LayerViewModel();
            _layer.IsVisible = true;
        }

        [Fact]
        public void ChangeLayerVisibility_WithVisibleLayer_ShouldChangeIsVisibleToFalse()
        {
            var changeLayerVisibilityService = new ChangeLayerVisibilityService();

            changeLayerVisibilityService.ChangeLayerVisibility(_layer);

            Assert.True(!_layer.IsVisible);

            _layer.IsVisible = true;
        }

        [Fact]
        public void ChangeLayerVisibility_WithNotVisibleLayer_ShouldChangeIsVisibleToTrue()
        {
            var changeLayerVisibilityService = new ChangeLayerVisibilityService();
            _layer.IsVisible = false;

            changeLayerVisibilityService.ChangeLayerVisibility(_layer);

            Assert.True(_layer.IsVisible);

            _layer.IsVisible = true;
        }

        [Fact]
        public void ChangeLayerVisibility_WithNullLayer_ShouldThrowAnException()
        {
            var changeLayerVisibilityService = new ChangeLayerVisibilityService();

            Assert.Throws<ArgumentNullException>("layer", () => changeLayerVisibilityService.ChangeLayerVisibility(null));
        }
    }
}
