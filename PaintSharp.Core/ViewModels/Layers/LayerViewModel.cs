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

        private bool _isVisible = true;
        public bool IsVisible
        {
            get { return _isVisible; }
            set 
            {
                _isVisible = value; 
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private float _opacity;
        public float Opacity
        {
            get { return _opacity; }
            set 
            {
                _opacity = value; 
                OnPropertyChanged(nameof(Opacity));
            }
        }


        #region Constructor / Setup

        public LayerViewModel()
        {
            SetupWriteableBitmap();
            SetupCommands();
        }

        public LayerViewModel(Color background)
        {
            SetupWriteableBitmap();
            WriteableBitmap.Clear(background);

            SetupCommands();
        }

        public LayerViewModel(BitmapSource background, bool autoScale)
        {
            if (autoScale)
            {
                var layer = new WriteableBitmap(background);
                ScaleImageLayer(layer);
            }
            else
            {
                WriteableBitmap = new WriteableBitmap(background);
            }

            SetupCommands();
        }

        private void ScaleImageLayer(WriteableBitmap layer)
        {

            float width = layer.PixelWidth;
            float height = layer.PixelHeight;

            var widthOffset = width - CanvasState.CanvasWidth;
            var scalePrecentage = ((float)(widthOffset / width));

            width = width - (width * scalePrecentage);
            height = height - (height * scalePrecentage);

            if (height > CanvasState.CanvasHeight)
            {
                var heightOffset = height - CanvasState.CanvasHeight;
                scalePrecentage = ((float)(heightOffset / height));

                width = width - (width * scalePrecentage);
                height = height - (height * scalePrecentage);
            }

            WriteableBitmap = layer.Resize(((int)width), ((int)height), WriteableBitmapExtensions.Interpolation.Bilinear);
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
            WriteableBitmap = BitmapFactory.ConvertToPbgra32Format(WriteableBitmap);
        }

        #endregion

        #region Drawing Commands

        public LeftButtonDownCommand LeftButtonDownCommand { get; set; }
        public LeftButtonUpCommand LeftButtonUpCommand { get; set; }
        public MouseDrawCommand MouseDrawCommand { get; set; }

        #endregion
    }
}
