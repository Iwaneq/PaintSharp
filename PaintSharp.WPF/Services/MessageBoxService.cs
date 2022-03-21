using Ookii.Dialogs.Wpf;
using PaintSharp.Core.Exceptions;
using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaintSharp.WPF.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public string GetSavingPath(string startDirectory)
        {
            if (!Directory.Exists(startDirectory))
            {
                Directory.CreateDirectory(startDirectory);
            }

            VistaSaveFileDialog saveDialog = SetupSaveDialog();
            saveDialog.InitialDirectory = startDirectory;

            if (saveDialog.ShowDialog() == true)
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

            if (saveDialog.ShowDialog() == true)
            {
                return saveDialog.FileName;
            }
            else
            {
                throw new GetPathFailedException("Failed to get saving path");
            }
        }

        public string GetFilePath()
        {
            VistaOpenFileDialog openDialog = SetupOpenFileDialog();

            if(openDialog.ShowDialog() == true)
            {
                return openDialog.FileName;
            }
            else
            {
                throw new GetPathFailedException("Failed to open a file");
            }
        }

        private VistaSaveFileDialog SetupSaveDialog()
        {
            VistaSaveFileDialog saveDialog = new VistaSaveFileDialog();
            saveDialog.DefaultExt = ".png";
            return saveDialog;
        }

        private VistaOpenFileDialog SetupOpenFileDialog()
        {
            VistaOpenFileDialog openDialog = new VistaOpenFileDialog();
            openDialog.DefaultExt = ".png";
            openDialog.CheckFileExists = true;
            openDialog.CheckPathExists = true;
            openDialog.Multiselect = false;
            openDialog.Title = "Open a file";

            return openDialog;
        }

       
    }
}
