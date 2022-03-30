using PaintSharp.Core.Commands.Drawing;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.ViewModels.Layers
{
    public class LayerViewModel : BaseLayerViewModel
    {
        #region Constructor / Setup

        public LayerViewModel() : base() { }
        public LayerViewModel(Color background) : base(background) { }

        #endregion
    }
}
