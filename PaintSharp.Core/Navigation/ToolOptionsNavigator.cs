using PaintSharp.Core.Factories;
using PaintSharp.Core.Navigation.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Navigation
{
    public class ToolOptionsNavigator : IToolOptionsNavigator
    {
        private readonly ToolOptionsViewModelFactory _factory;

        #region Constructor / Setup

        public ToolOptionsNavigator(ToolOptionsViewModelFactory factory)
        {
            _factory = factory;
        } 

        #endregion

        public void Navigate(ToolType toolType, ToolBarViewModel toolBar)
        {
            toolBar.ToolOptionsViewModel = _factory.GetOptionsViewModel(toolType);
        }
    }
}
