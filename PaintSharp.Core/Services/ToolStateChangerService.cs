﻿using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.State.ToolStateHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PaintSharp.Core.Services
{
    public class ToolStateChangerService : IToolStateChangerService
    {
        private readonly IDrawDelegatesHelper _drawDelegatesHelper;

        #region Constructor / Setup

        public ToolStateChangerService(IDrawDelegatesHelper drawDelegatesHelper)
        {
            _drawDelegatesHelper = drawDelegatesHelper;
        }

        #endregion

        public void ChangeBrushColor(Color color)
        {
            ToolState.BrushColor = new SolidColorBrush(color);
        }

        public void ChangeToolSize(int width, int height)
        {
            ToolState.BrushSize = new Size(width, height);
        }

        public void ChangeToolType(ToolType toolType)
        {
            _drawDelegatesHelper.ChangeDrawDelegate(toolType);
        }
    }
}
