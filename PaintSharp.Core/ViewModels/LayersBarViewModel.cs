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
        private IDeleteLayerService _deleteLayerService;

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


        public AddLayerCommand AddLayerCommand { get; set; }
        public DeleteLayerCommand DeleteLayerCommand { get; set; }

        #region Constructor / Setup

        public LayersBarViewModel(IAddLayerService addLayerService, IDeleteLayerService deleteLayerService)
        {
            _addLayerService = addLayerService;
            _deleteLayerService = deleteLayerService;

            SetupCommands();
        }

        private void SetupCommands()
        {
            AddLayerCommand = new AddLayerCommand(_addLayerService);
            DeleteLayerCommand = new DeleteLayerCommand(_deleteLayerService);
        }

        #endregion
    }
}
