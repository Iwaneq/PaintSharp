using PaintSharp.Core.Commands;
using PaintSharp.Core.Navigation.Interfaces;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Tools;
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
        private readonly IToolStateChangerService _toolStateChanger;
        private readonly IToolOptionsNavigator _toolOptionsNavigator;

        private BaseToolOptionsViewModel _toolOptionsViewModel;
        public BaseToolOptionsViewModel ToolOptionsViewModel
        {
            get { return _toolOptionsViewModel; }
            set 
            {
                _toolOptionsViewModel = value; 
                OnPropertyChanged(nameof(ToolOptionsViewModel));
            }
        }


        private Color _toolBrush;
        public Color ToolBrush
        {
            get { return _toolBrush; }
            set 
            {
                _toolBrush = value; 
                OnPropertyChanged(nameof(ToolBrush));
                _toolStateChanger.ChangeBrushColor(ToolBrush);
            }
        }

        public ChangeToolTypeCommand ChangeToolCommand { get; set; }

        #region Constructor / Setup

        public ToolBarViewModel(IToolStateChangerService toolStateChanger, PenOptionsViewModel penOptionsViewModel, IToolOptionsNavigator toolOptionsNavigator)
        {
            _toolStateChanger = toolStateChanger;
            _toolOptionsViewModel = penOptionsViewModel;
            _toolOptionsNavigator = toolOptionsNavigator;

            ChangeToolCommand = new ChangeToolTypeCommand(toolStateChanger, toolOptionsNavigator, this);

            ToolBrush = Colors.Blue;
        }

        #endregion
    }
}
