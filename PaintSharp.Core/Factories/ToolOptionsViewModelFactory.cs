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
        private readonly SprayOptionsViewModel _sprayOptions;
        private readonly EmptyOptionsViewModel _emptyOptions;

        #region Constructor / Setup

        public ToolOptionsViewModelFactory(PenOptionsViewModel penOptionsViewModel,
            EraserOptionsViewModel eraserOptions,
            SprayOptionsViewModel sprayOptions, EmptyOptionsViewModel emptyOptions)
        {
            _penOptions = penOptionsViewModel;
            _eraserOptions = eraserOptions;
            _sprayOptions = sprayOptions;
            _emptyOptions = emptyOptions;
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
                case ToolType.Spray:
                    return _sprayOptions;
                case ToolType.Fill:
                    return _emptyOptions;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
