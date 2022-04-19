using PaintSharp.Core.Services.Interfaces;
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
        private readonly IToolStateChangerHelper _drawDelegatesHelper;

        #region Constructor / Setup

        public ToolStateChangerService(IToolStateChangerHelper drawDelegatesHelper)
        {
            _drawDelegatesHelper = drawDelegatesHelper;
        }

        #endregion

        public void ChangeBrushColor(Color color)
        {
            ToolState.BrushColor = color;
        }

        public void ChangeToolSize(int width, int height)
        {
            if(width <= 0)
            {
                throw new ArgumentOutOfRangeException("width");
            }
            if(height <= 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            ToolState.BrushSize = new Size(width, height);
        }

        public void ChangeToolRadius(int radius)
        {
            if(radius <= 0)
            {
                throw new ArgumentOutOfRangeException("radius");
            }

            ToolState.BrushRadius = radius;
        }

        public void ChangeToolType(ToolType toolType)
        {
            _drawDelegatesHelper.ChangeTool(toolType);
        }

        public void ChangeToolShape(ToolShape toolShape, ToolType toolType)
        {
            ToolState.ToolShape = toolShape;
            _drawDelegatesHelper.ChangeTool(toolType);
        }
    }
}
