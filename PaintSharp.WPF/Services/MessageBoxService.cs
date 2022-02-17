using Ookii.Dialogs.Wpf;
using PaintSharp.Core.Exceptions;
using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.WPF.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public string GetSavingPath(string startDirectory)
        {
            if (!Directory.Exists(startDirectory))
            {
                Directory.CreateDirectory(startDirectory);
            }

            VistaSaveFileDialog saveDialog = SetupSaveDialog();
            saveDialog.InitialDirectory = startDirectory;

            if(saveDialog.ShowDialog() == true)
            {
                return saveDialog.FileName;
            }
            else
            {
                throw new GetPathFailedException("Failed to get saving path");
            }
        }

        public string GetSavingPath()
        {
            VistaSaveFileDialog saveDialog = SetupSaveDialog();
            
            if(saveDialog.ShowDialog() == true)
            {
                return saveDialog.FileName;
            }
            else
            {
                throw new GetPathFailedException("Failed to get saving path");
            }
        }

        private VistaSaveFileDialog SetupSaveDialog()
        {
            VistaSaveFileDialog saveDialog = new VistaSaveFileDialog();
            saveDialog.DefaultExt = ".png";
            return saveDialog;
        }
    }
}
