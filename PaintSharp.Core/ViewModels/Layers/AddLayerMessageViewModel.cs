using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.ViewModels.Layers
{
    public class AddLayerMessageViewModel : BaseViewModel
    {
        private string _layerName;
        public string LayerName
        {
            get { return _layerName; }
            set 
            {
                _layerName = value;
                OnPropertyChanged(nameof(LayerName));
            }
        }

        private int _layerOpacity = 100;
        public int LayerOpacity
        {
            get { return _layerOpacity; }
            set 
            { 
                _layerOpacity = value;
                OnPropertyChanged(nameof(LayerOpacity));
            }
        }

        private Color _layerBackground = Colors.White;
        public Color LayerBackground
        {
            get { return _layerBackground; }
            set 
            {
                _layerBackground = value;
                OnPropertyChanged(nameof(LayerBackground));
            }
        }

        private bool _isLayerTransparent = true;
        public bool IsLayerTransparent
        {
            get { return _isLayerTransparent; }
            set 
            {
                _isLayerTransparent = value;
                OnPropertyChanged(nameof(IsLayerTransparent));
            }
        }


        public AddLayerCommand AddLayerCommand { get; set; }

        #region Constructor / Setup

        public AddLayerMessageViewModel(IAddLayerService addLayerService)
        {
            AddLayerCommand = new AddLayerCommand(addLayerService);
        }

        #endregion

        public void ResetViewModel()
        {
            LayerName = "";
            LayerOpacity = 100;
            LayerBackground = Colors.White;
            IsLayerTransparent = true;
        }
    }
}
