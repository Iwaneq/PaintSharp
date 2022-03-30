using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.State
{
    public static class LayerState
    {
        public static int LayersCount { get; set; }

        private static ObservableCollection<BaseLayerViewModel> _layers = new ObservableCollection<BaseLayerViewModel>();
        public static ObservableCollection<BaseLayerViewModel> Layers
        {
            get { return _layers; }
            set 
            {
                _layers = value;
            }
        }

        private static ObservableCollection<LayerTabViewModel> _layerTabs = new ObservableCollection<LayerTabViewModel>();
        public static ObservableCollection<LayerTabViewModel> LayerTabs
        {
            get { return _layerTabs; }
            set
            {
                _layerTabs = value;
            }
        }

        public static void ClearLayers()
        {
            Layers.Clear();
            LayerTabs.Clear();
        }
    }
}
