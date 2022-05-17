using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.State.ToolStateHelpers.ChangeToolTypeHelpers
{
    public class ChangeToSprayHelper : IChangeToolTypeHelper
    {
        private readonly IDrawDelegatesHelper _drawDelegatesHelper;

        #region Constructor / Setup

        public ChangeToSprayHelper(IDrawDelegatesHelper drawDelegatesHelper)
        {
            _drawDelegatesHelper = drawDelegatesHelper;
        }

        #endregion

        #region Change Method

        public void ChangeClickBooleans()
        {
            ToolState.IsToolOneClickType = false;
        }

        public void ChangeToCircle()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleSpray);
        }

        public void ChangeToDefault()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleSpray);
        }

        public void ChangeToRect()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.RectSpray);
        }

        #endregion
    }
}
