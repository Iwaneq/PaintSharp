using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.ViewModels
{
    public class LayersBarViewModel : BaseViewModel
    {
        private IAddLayerService _addLayerService;

        public ObservableCollection<LayerTabViewModel> Layers
        {
            get { return LayerState.LayerTabs; }
            set 
            {
                LayerState.LayerTabs = value;
                OnPropertyChanged(nameof(Layers));
            }
        }

        public AddLayerCommand AddLayerCommand { get; set; }

        #region Constructor / Setup

        public LayersBarViewModel(IAddLayerService addLayerService)
        {
            _addLayerService = addLayerService;

            SetupCommands();
        }

        private void SetupCommands()
        {
            AddLayerCommand = new AddLayerCommand(_addLayerService);
        }

        #endregion
    }
}
