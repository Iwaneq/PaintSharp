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

        public bool HasSizeProperty { get; set; } = false;
        public bool HasTypeProperty { get; set; } = false;
        public bool HasFillProperty { get; set; } = false;
        public bool HasBorderThicknessProperty { get; set; } = false;

        #endregion
    }
}
