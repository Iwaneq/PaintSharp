using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.Services.ServiceHelpers.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services
{
    public class AddLayerService : IAddLayerService
    {
        private readonly IChangeLayerVisibilityService _changeLayerVisibilityService;
        private readonly ILayerCreatorHelper _layerCreatorHelper;

        #region Constructor / Setup

        public AddLayerService(IChangeLayerVisibilityService changeLayerVisibilityService, ILayerCreatorHelper layerCreatorHelper)
        {
            _changeLayerVisibilityService = changeLayerVisibilityService;
            _layerCreatorHelper = layerCreatorHelper;
        }

        #endregion

        public void AddLayer(string name, Color background, bool isLayerTransparent)
        {
            //Create Layer of given size and with given background
            //If Layer is Transparent, background color will be Transparent
            LayerViewModel layer;
            if (isLayerTransparent)
            {
                layer = _layerCreatorHelper.CreateLayer();
            }
            else
            {
                layer = _layerCreatorHelper.CreateLayer(background); 
            }

            layer.Opacity = 100;
            LayerState.Layers.Add(layer);

            //Create LayerTab and wire it to Layer
            LayerTabViewModel layerTab = new LayerTabViewModel(_changeLayerVisibilityService) 
            {
                Name = name, 
                Layer = layer 
            };
            LayerState.LayerTabs.Insert(0, layerTab);
        }

        public void AddLayer(string name, Color background, bool isLayerTransparent, float opacity)
        {
            //Create Layer of given size and with given background
            //If Layer is Transparent, background color will be Transparent
            LayerViewModel layer;
            if (isLayerTransparent)
            {
                layer = _layerCreatorHelper.CreateLayer();
            }
            else
            {
                layer = _layerCreatorHelper.CreateLayer(background);
            }

            if(opacity < 0 || opacity > 100)
            {
                throw new ArgumentOutOfRangeException("opacity");
            }

            layer.Opacity = opacity;
            LayerState.Layers.Add(layer);

            //Create LayerTab and wire it to Layer
            LayerTabViewModel layerTab = new LayerTabViewModel(_changeLayerVisibilityService)
            {
                Name = name,
                Layer = layer
            };
            LayerState.LayerTabs.Insert(0, layerTab);
        }

        public void AddImageLayer(string name, BitmapSource background, float opacity, bool autoScale)
        {
            //Create ImageLayer of given size and with given background, and scale it if autoScale is true
            ImageLayerViewModel layer = _layerCreatorHelper.CreateImageLayer(background, autoScale);

            if (opacity < 0 || opacity > 100)
            {
                throw new ArgumentOutOfRangeException("opacity");
            }

            layer.Opacity = opacity;

            LayerState.Layers.Add(layer);

            //Create LayerTab and wire it to Layer
            LayerTabViewModel layerTab = new LayerTabViewModel(_changeLayerVisibilityService)
            {
                Name = name,
                Layer = layer
            };
            LayerState.LayerTabs.Insert(0, layerTab);
        }
    }
}
