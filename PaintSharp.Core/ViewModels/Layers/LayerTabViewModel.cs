using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.ViewModels.Layers
{
    public class LayerTabViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private LayerViewModel _layer;
        public LayerViewModel Layer
        {
            get { return _layer; }
            set 
            {
                _layer = value;
                OnPropertyChanged(nameof(Layer));
            }
        }

        public ChangeLayerVisibilityCommand ChangeLayerVisibilityCommand { get; set; }

        #region Constructor / Setup

        public LayerTabViewModel(IChangeLayerVisibilityService changeLayerVisibilityService)
        {
            ChangeLayerVisibilityCommand = new ChangeLayerVisibilityCommand(this, changeLayerVisibilityService);
        }

        #endregion

    }
}
