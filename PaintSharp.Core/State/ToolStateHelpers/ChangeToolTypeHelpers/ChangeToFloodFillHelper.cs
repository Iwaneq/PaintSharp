using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.State.ToolStateHelpers.ChangeToolTypeHelpers
{
    public class ChangeToFloodFillHelper : IChangeToolTypeHelper
    {
        private readonly IDrawDelegatesHelper _drawDelegatesHelper;

        #region Constructor / Setup

        public ChangeToFloodFillHelper(IDrawDelegatesHelper drawDelegatesHelper)
        {
            _drawDelegatesHelper = drawDelegatesHelper;
        }

        #endregion

        #region Change Method

        public void ChangeClickBooleans()
        {
            ToolState.IsToolOneClickType = true;
        }

        public void ChangeToCircle()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.FloodFill);
        }

        public void ChangeToDefault()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.FloodFill);
        }

        public void ChangeToRect()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.FloodFill);
        }

        #endregion
    }
}
