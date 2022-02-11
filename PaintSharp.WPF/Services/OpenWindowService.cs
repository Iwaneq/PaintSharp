using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaintSharp.WPF.Services
{
    public class OpenWindowService : IOpenWindowService
    {
        public void OpenWindow(string title, BaseViewModel viewModel)
        {
            Window window = new Window();
            window.Title = title;
            window.Content = viewModel;
            window.Show();
        }

        public void OpenWindow(string title, BaseViewModel viewModel, int windowHeight, int windowWidth)
        {
            Window window = new Window();
            window.Title = title;
            window.Content = viewModel;
            window.Show();

            window.Height = windowHeight;
            window.Width = windowWidth;
        }
    }
}
