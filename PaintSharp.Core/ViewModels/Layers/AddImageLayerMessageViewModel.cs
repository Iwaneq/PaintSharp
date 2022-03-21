using PaintSharp.Core.Commands;
using PaintSharp.Core.Commands.Utils;
using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintSharp.Core.ViewModels.Layers
{
    public class AddImageLayerMessageViewModel : BaseViewModel
    {
        private string _layerName = string.Empty;
        public string LayerName
        {
            get { return _layerName; }
            set
            {
                _layerName = value;
                OnPropertyChanged(nameof(LayerName));
            }
        }

        private int _layerOpacity = 100;
        public int LayerOpacity
        {
            get { return _layerOpacity; }
            set
            {
                _layerOpacity = value;
                OnPropertyChanged(nameof(LayerOpacity));
            }
        }

        private string _backgroundFilePath = string.Empty;
        public string BackgroundFilePath
        {
            get { return _backgroundFilePath; }
            set
            {
                _backgroundFilePath = value;
                OnPropertyChanged(nameof(BackgroundFilePath));
            }
        }

        private bool _autoScaleImage = false;
        public bool AutoScaleImage
        {
            get { return _autoScaleImage; }
            set
            {
                _autoScaleImage = value;
                OnPropertyChanged(nameof(AutoScaleImage));
            }
        }


        public GetImagePathCommand GetImagePathCommand { get; set; }
        public AddImageLayerCommand AddImageLayerCommand { get; set; }

        #region Constructor / Setup

        public AddImageLayerMessageViewModel(IAddLayerService addLayerService, ICreateBitmapSourceFromFileService createBitmapSourceFromFileService, IMessageBoxService messageBoxService)
        {
            AddImageLayerCommand = new AddImageLayerCommand(addLayerService, createBitmapSourceFromFileService, messageBoxService);
            GetImagePathCommand = new GetImagePathCommand(messageBoxService, this);
        }

        #endregion

        public void ResetViewModel()
        {
            LayerName = string.Empty;
            LayerOpacity = 100;
            BackgroundFilePath = string.Empty;
            AutoScaleImage = false;
        }
    }
}
