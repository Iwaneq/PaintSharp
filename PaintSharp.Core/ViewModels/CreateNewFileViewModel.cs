using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.ViewModels
{
    public class CreateNewFileViewModel : BaseViewModel
    {
        private int _canvasWidth;
        public int CanvasWidth
        {
            get { return _canvasWidth; }
            set 
            {
                _canvasWidth = value; 
                OnPropertyChanged(nameof(CanvasWidth));
            }
        }

        private int _canvasHeight;
        public int CanvasHeight
        {
            get { return _canvasHeight; }
            set 
            {
                _canvasHeight = value; 
                OnPropertyChanged(nameof(CanvasHeight));
            }
        }

        private bool _isCanvasTransparent = false;
        public bool IsCanvasTransparent
        {
            get { return _isCanvasTransparent; }
            set 
            {
                _isCanvasTransparent = value; 
                OnPropertyChanged(nameof(IsCanvasTransparent));
            }
        }

        private Color _canvasBackground = Colors.White;
        public Color CanvasBackground
        {
            get { return _canvasBackground; }
            set { _canvasBackground = value; }
        }

        public CreateNewFileCommand CreateNewFileCommand { get; set; }

        #region Constructor / Setup

        public CreateNewFileViewModel(ICanvasStateChangerService canvasStateChangerService, IAddLayerService addLayerService)
        {
            CreateNewFileCommand = new CreateNewFileCommand(canvasStateChangerService, this, addLayerService);
        }

        #endregion
    }
}
