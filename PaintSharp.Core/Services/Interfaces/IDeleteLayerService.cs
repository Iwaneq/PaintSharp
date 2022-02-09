using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface IDeleteLayerService
    {
        void DeleteLayer(LayerTabViewModel layerTab);
    }
}
