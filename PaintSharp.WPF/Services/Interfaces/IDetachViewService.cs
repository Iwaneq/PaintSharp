using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PaintSharp.WPF.Services.Interfaces
{
    public interface IDetachViewService
    {
        void DetachOrAttachView(int windowHeight, int windowWidth, Grid mainGrid);
        void AttachView();
        void DetachView(int windowHeight, int windowWidth);
    }
}
