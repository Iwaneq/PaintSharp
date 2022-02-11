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
        public ObservableCollection<LayerTabViewModel> Layers
        {
            get { return LayerState.LayerTabs; }
            set 
            {
                LayerState.LayerTabs = value;
                OnPropertyChanged(nameof(Layers));
            }
        }

        private LayerTabViewModel _selectedLayer;
        public LayerTabViewModel SelectedLayer
        {
            get { return _selectedLayer; }
            set 
            {
                _selectedLayer = value; 
                OnPropertyChanged(nameof(SelectedLayer));
            }
        }


        public OpenAddLayerMessageViewCommand OpenAddLayerMessageViewCommand { get; set; }
        public DeleteLayerCommand DeleteLayerCommand { get; set; }

        #region Constructor / Setup

        public LayersBarViewModel(IAddLayerService addLayerService,
            IDeleteLayerService deleteLayerService, 
            IOpenWindowService openWindowService,
            AddLayerMessageViewModel addLayerMessageViewModel)
        {
            OpenAddLayerMessageViewCommand = new OpenAddLayerMessageViewCommand(openWindowService, addLayerMessageViewModel);
            DeleteLayerCommand = new DeleteLayerCommand(deleteLayerService);
        }

        #endregion
    }
}
