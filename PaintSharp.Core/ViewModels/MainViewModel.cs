using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PaintSharp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IOpenWindowService _openWindowService;

        private ToolBarViewModel _toolBarViewModel;
        public ToolBarViewModel ToolBarViewModel
        {
            get { return _toolBarViewModel; }
            set 
            {
                _toolBarViewModel = value; 
                OnPropertyChanged(nameof(ToolBarViewModel));
            }
        }

        private LayersBarViewModel _layersBarViewModel;
        public LayersBarViewModel LayersBarViewModel
        {
            get { return _layersBarViewModel; }
            set 
            {
                _layersBarViewModel = value;
                OnPropertyChanged(nameof(LayersBarViewModel));
            }
        }

        private CreateNewFileViewModel _createNewFileViewModel;
        public CreateNewFileViewModel CreateNewFileViewModel
        {
            get { return _createNewFileViewModel; }
            set 
            {
                _createNewFileViewModel = value;
                OnPropertyChanged(nameof(CreateNewFileViewModel));
            }
        }

        public ObservableCollection<BaseLayerViewModel> Layers
        {
            get { return LayerState.Layers; }
            set 
            {
                LayerState.Layers = value;
                OnPropertyChanged(nameof(Layers));
            }
        }

        public double CanvasWidth
        {
            get { return CanvasState.CanvasWidth; }
        }
        public double CanvasHeight
        {
            get { return CanvasState.CanvasHeight; }
        }
        public Color CanvasBackground
        {
            get { return CanvasState.CanvasBackground; }
        }

        public event Action OnCanvasSave;

        #region Constructor / Setup

        public MainViewModel(ToolBarViewModel toolBarViewModel, LayersBarViewModel layersBarViewModel, IAddLayerService addLayerService, CreateNewFileViewModel createNewFileViewModel, IOpenWindowService openWindowService)
        {
            ToolBarViewModel = toolBarViewModel;
            LayersBarViewModel = layersBarViewModel;
            LayersBarViewModel.OnCanvasSaveRequested += OnCanvasSaveRequested;
            CreateNewFileViewModel = createNewFileViewModel;
            _openWindowService = openWindowService;

            CanvasState.StateChanged += OnCanvasStateChanged;

            openWindowService.OpenWindow("Create new File", createNewFileViewModel, 350, 300);
        }

        private void OnCanvasStateChanged()
        {
            OnPropertyChanged(nameof(CanvasWidth));
            OnPropertyChanged(nameof(CanvasHeight));
            OnPropertyChanged(nameof(CanvasBackground));
        }

        private void OnCanvasSaveRequested()
        {
            OnCanvasSave?.Invoke();
        }

        #endregion

        #region Destructor

        ~MainViewModel()
        {
            LayersBarViewModel.OnCanvasSaveRequested -= OnCanvasSaveRequested;
            CanvasState.StateChanged -= OnCanvasStateChanged;
        }

        #endregion

        #region Layers Management

        public void AddLayer()
        {
            var layer = new LayerViewModel();
            Layers.Add(layer);
        }

        #endregion
    }
}
