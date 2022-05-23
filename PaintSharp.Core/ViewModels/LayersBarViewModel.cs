using PaintSharp.Core.Commands;
using PaintSharp.Core.Commands.OpenView;
using PaintSharp.Core.Commands.Utils;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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

        public LayerTabViewModel SelectedLayer
        {
            get { return LayerState.CurrentLayerTab; }
            set 
            {
                LayerState.CurrentLayerTab = value; 
                OnPropertyChanged(nameof(SelectedLayer));
            }
        }

        public OpenAddLayerMessageViewCommand OpenAddLayerMessageViewCommand { get; set; }
        public OpenAddImageLayerMessageViewCommand OpenAddImageLayerMessageViewCommand { get; set; }
        public DeleteLayerCommand DeleteLayerCommand { get; set; }
        public ICommand RequestCanvasSaveCommand { get; set; } 
        public OpenCreateNewFileViewCommand OpenCreateNewFileViewCommand { get; set; }

        public event Action OnCanvasSaveRequested;

        #region Constructor / Setup

        public LayersBarViewModel(IAddLayerService addLayerService,
            IDeleteLayerService deleteLayerService,
            IOpenWindowService openWindowService,
            AddLayerMessageViewModel addLayerMessageViewModel,
            AddImageLayerMessageViewModel addImageLayerMessageViewModel,
            CreateNewFileViewModel createNewFileViewModel)
        {
            OpenAddLayerMessageViewCommand = new OpenAddLayerMessageViewCommand(openWindowService, addLayerMessageViewModel);
            OpenAddImageLayerMessageViewCommand = new OpenAddImageLayerMessageViewCommand(openWindowService, addImageLayerMessageViewModel);
            DeleteLayerCommand = new DeleteLayerCommand(deleteLayerService);
            RequestCanvasSaveCommand = new RelayCommand(() => OnCanvasSaveRequested?.Invoke());
            OpenCreateNewFileViewCommand = new OpenCreateNewFileViewCommand(openWindowService, createNewFileViewModel);
        }

        #endregion
    }
}
