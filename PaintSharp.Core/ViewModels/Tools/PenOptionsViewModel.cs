using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PaintSharp.Core.ViewModels.Tools
{
    public class PenOptionsViewModel : BaseToolOptionsViewModel
    {
        private readonly IToolStateChangerService _toolStateChanger;

        private int _penWidth = 10;
        public int PenWidth
        {
            get { return _penWidth; }
            set 
            {
                _penWidth = value;
                OnPropertyChanged(nameof(PenWidth));
                _toolStateChanger.ChangeToolSize(PenWidth, PenHeight);
            }
        }

        private int _penHeight = 10;
        public int PenHeight
        {
            get { return _penHeight; }
            set 
            {
                _penHeight = value;
                OnPropertyChanged(nameof(PenHeight));
                _toolStateChanger.ChangeToolSize(PenWidth, PenHeight);
            }
        }

        public ChangeToolTypeCommand ChangeToolTypeCommand { get; set; }


        #region Constructor / Setup

        public PenOptionsViewModel(IToolStateChangerService toolStateChanger)
        {
            _toolStateChanger = toolStateChanger;
            ChangeToolTypeCommand = new ChangeToolTypeCommand(toolStateChanger);

            ChangeToolTypeCommand.Execute(ToolType.CirclePen);

            SetupHasOptionProperties();

            _toolStateChanger.ChangeToolSize(PenWidth, PenHeight);
        }

        private void SetupHasOptionProperties()
        {
            HasSizeProperty = true;
            HasTypeProperty = true;
        }

        #endregion
    }
}
