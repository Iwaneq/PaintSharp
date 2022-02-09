using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Services
{
    public class DeleteLayerService : IDeleteLayerService
    {
        public void DeleteLayer(LayerTabViewModel layerTab)
        {
            //Delete LayerTab from List
            LayerState.LayerTabs.Remove(layerTab);

            //Delete Layer from List
            LayerState.Layers.Remove(layerTab.Layer);
        }
    }
}
