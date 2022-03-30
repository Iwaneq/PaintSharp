using PaintSharp.Core.Exceptions;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaintSharp.Core.Commands
{
    public class GetImagePathCommand : ICommand
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly AddImageLayerMessageViewModel _addImageLayerMessageViewModel;

        #region Constructor / Setup

        public GetImagePathCommand(IMessageBoxService messageBoxService, AddImageLayerMessageViewModel addImageLayerMessageViewModel)
        {
            _messageBoxService = messageBoxService;
            _addImageLayerMessageViewModel = addImageLayerMessageViewModel;
        }

        #endregion

        #region Command

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string filePath = string.Empty;

            try
            {
                filePath = _messageBoxService.GetFilePath();
            }
            catch (Exception ex) 
            {
                //MessageBoxService throws GetPathFailedException only when User closes MessageBox, so he dosen't need information about Error
                if(ex is not GetPathFailedException)
                {
                    _messageBoxService.ShowError(ex.GetType().ToString(), ex.Message);
                }
            }
            finally
            {
                _addImageLayerMessageViewModel.BackgroundFilePath = filePath;
            }
        } 

        #endregion
    }
}
