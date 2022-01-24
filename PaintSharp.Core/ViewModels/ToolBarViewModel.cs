using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.ViewModels
{
    public class ToolBarViewModel : BaseViewModel
    {
        private Color _toolBrush;
        public Color ToolBrush
        {
            get { return _toolBrush; }
            set 
            {
                _toolBrush = value; 
                OnPropertyChanged(nameof(ToolBrush));
            }
        }

        public ToolBarViewModel()
        {
            ToolBrush = Colors.Blue;
        }
    }
}
