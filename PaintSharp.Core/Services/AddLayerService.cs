using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PaintSharp.Core.Services
{
    public class AddLayerService : IAddLayerService
    {
        public void AddLayer(string name, Size size, Color background)
        {
            //Create Layer of given size and with given background
            LayerViewModel layer = new LayerViewModel(background);
            LayerState.Layers.Add(layer);

            //Create LayerTab and wire it to Layer
            LayerTabViewModel layerTab = new LayerTabViewModel() 
            {
                Name = name, 
                Layer = layer 
            };
            LayerState.LayerTabs.Insert(0, layerTab);
        }
    }
}
