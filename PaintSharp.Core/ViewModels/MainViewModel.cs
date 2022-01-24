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

        #region Constructor / Setup

        public MainViewModel()
        {
            ToolBarViewModel = new ToolBarViewModel();
        }

        #endregion
    }
}
