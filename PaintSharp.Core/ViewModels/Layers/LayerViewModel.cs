using PaintSharp.Core.Commands.Drawing;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.ViewModels.Layers
{
    public class LayerViewModel : BaseViewModel
    {
        private WriteableBitmap _writeableBitmap;
        public WriteableBitmap WriteableBitmap
        {
            get { return _writeableBitmap; }
            set 
            {
                _writeableBitmap = value; 
                OnPropertyChanged(nameof(WriteableBitmap));
            }
        }

        #region Constructor / Setup

        public LayerViewModel()
        {
            SetupWriteableBitmap();
            SetupCommands();
        }

        private void SetupCommands()
        {
            LeftButtonDownCommand = new LeftButtonDownCommand();
            LeftButtonUpCommand = new LeftButtonUpCommand();
            MouseDrawCommand = new MouseDrawCommand(this);
        }

        private void SetupWriteableBitmap()
        {
            //If layer is creating without background image, it'll create blank, white WriteableBitmap as large as Canvas
            WriteableBitmap = BitmapFactory.New(((int)CanvasState.CanvasWidth), ((int)CanvasState.CanvasHeight));
        }

        #endregion

        #region Drawing Commands

        public LeftButtonDownCommand LeftButtonDownCommand { get; set; }
        public LeftButtonUpCommand LeftButtonUpCommand { get; set; }
        public MouseDrawCommand MouseDrawCommand { get; set; }

        #endregion
    }
}
