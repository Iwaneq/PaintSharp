using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Factories
{
    public class ToolOptionsViewModelFactory
    {
        private readonly PenOptionsViewModel _penOptions;
        private readonly EraserOptionsViewModel _eraserOptions;

        #region Constructor / Setup

        public ToolOptionsViewModelFactory(PenOptionsViewModel penOptionsViewModel, EraserOptionsViewModel eraserOptions)
        {
            _penOptions = penOptionsViewModel;
            _eraserOptions = eraserOptions;
        }

        #endregion

        public BaseToolOptionsViewModel GetOptionsViewModel(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.Pen:
                    return _penOptions;
                case ToolType.Eraser:
                    return _eraserOptions;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
