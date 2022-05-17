using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Services
{
    public class ChangeLayerVisibilityService : IChangeLayerVisibilityService
    {
        public void ChangeLayerVisibility(BaseLayerViewModel layer)
        {
            if(layer == null)
            {
                throw new ArgumentNullException("layer");
            }

            if (layer.IsVisible)
            {
                layer.IsVisible = false;
            }
            else
            {
                layer.IsVisible = true;
            }
        }
    }
}
