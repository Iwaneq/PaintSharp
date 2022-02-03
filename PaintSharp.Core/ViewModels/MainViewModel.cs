using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<LayerViewModel> _layers = new List<LayerViewModel>();
        public List<LayerViewModel> Layers
        {
            get { return _layers; }
            set 
            {
                _layers = value; 
                OnPropertyChanged(nameof(Layers));
            }
        }


        #region Constructor / Setup

        public MainViewModel(ToolBarViewModel toolBarViewModel)
        {
            ToolBarViewModel = toolBarViewModel;

            AddLayer();
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
