using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.ViewModels.Tools
{
    public abstract class BaseToolOptionsViewModel : BaseViewModel
    {
        #region Properties describing Options of given tool
        public ToolType ToolType { get; set; }

        public bool HasSizeProperty { get; set; } = false;
        public bool HasRadiusProperty { get; set; } = false;
        public bool HasTypeProperty { get; set; } = false;
        public bool HasFillProperty { get; set; } = false;
        public bool HasBorderThicknessProperty { get; set; } = false;

        #endregion

        private readonly IToolStateChangerService _toolStateChanger;
        public int ToolWidth
        {
            get { return ((int)ToolState.BrushSize.Width); }
            set
            {
                _toolStateChanger.ChangeToolSize(value, ToolHeight);
                OnPropertyChanged(nameof(ToolWidth));
            }
        }

        public int ToolHeight
        {
            get { return ((int)ToolState.BrushSize.Height); }
            set
            {
                _toolStateChanger.ChangeToolSize(ToolWidth, value);
                OnPropertyChanged(nameof(ToolHeight));
            }
        }

        public int ToolRadius
        {
            get { return ToolState.BrushRadius; }
            set
            {
                _toolStateChanger.ChangeToolRadius(value);
                OnPropertyChanged(nameof(ToolRadius));
            }
        }

        #region Constructor / Setup

        public BaseToolOptionsViewModel(IToolStateChangerService toolStateChanger)
        {
            _toolStateChanger = toolStateChanger;
        }

        #endregion
    }
}
