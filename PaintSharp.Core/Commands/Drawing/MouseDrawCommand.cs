using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PaintSharp.Core.Commands.Drawing
{
    public class MouseDrawCommand : ICommand
    {
        private readonly LayerViewModel _layer;

        public event EventHandler? CanExecuteChanged;

        #region Constructor / Setup

        public MouseDrawCommand(LayerViewModel layer)
        {
            _layer = layer;
        } 

        #endregion

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter == null) return;

            Point pt = (Point)parameter;

            ToolState.DrawDelegate(pt, _layer.WriteableBitmap);
        }
    }
}
