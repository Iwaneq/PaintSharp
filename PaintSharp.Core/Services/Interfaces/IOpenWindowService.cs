using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface IOpenWindowService
    {
        void OpenWindow(string title, BaseViewModel viewModel);
        void OpenWindow(string title, BaseViewModel viewModel, int windowHeight, int windowWidth);
    }
}
