using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Navigation.Interfaces
{
    public interface IToolOptionsNavigator
    {
        void Navigate(ToolType toolType, ToolBarViewModel toolBar);
    }
}
