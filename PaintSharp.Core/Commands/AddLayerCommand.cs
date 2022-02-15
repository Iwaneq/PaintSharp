﻿using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintSharp.Core.Commands
{
    public class AddLayerCommand : ICommand
    {
        private readonly IAddLayerService _addLayerService;

        #region Constructor / Setup

        public AddLayerCommand(IAddLayerService addLayerService)
        {
            _addLayerService = addLayerService;
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
            if (parameter == null) return;

            var viewModel = (AddLayerMessageViewModel)parameter;
            _addLayerService.AddLayer(viewModel.LayerName, new Size(1, 1), viewModel.LayerBackground, ((float)viewModel.LayerOpacity)/100);
        } 

        #endregion
    }
}
