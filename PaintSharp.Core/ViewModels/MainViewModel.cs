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


        public ObservableCollection<LayerViewModel> Layers
        {
            get { return LayerState.Layers; }
            set 
            {
                LayerState.Layers = value;
                OnPropertyChanged(nameof(Layers));
            }
        }

        public event Action OnCanvasSave;

        #region Constructor / Setup

        public MainViewModel(ToolBarViewModel toolBarViewModel, LayersBarViewModel layersBarViewModel, IAddLayerService addLayerService)
        {
            ToolBarViewModel = toolBarViewModel;
            LayersBarViewModel = layersBarViewModel;
            LayersBarViewModel.OnCanvasSaveRequested += OnCanvasSaveRequested;

            addLayerService.AddLayer("Background", new Size(1,1), Colors.Red);
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
