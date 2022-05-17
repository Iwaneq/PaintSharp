using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.State.ToolStateHelpers.ChangeToolTypeHelpers
{
    public class ChangeToEraserHelper : IChangeToolTypeHelper
    {
        private readonly IDrawDelegatesHelper _drawDelegatesHelper;

        #region Constructor / Setup

        public ChangeToEraserHelper(IDrawDelegatesHelper drawDelegatesHelper)
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
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleErase);
        }

        public void ChangeToDefault()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.CircleErase);
        }

        public void ChangeToRect()
        {
            ToolState.DrawDelegate = new DrawDelegate(_drawDelegatesHelper.RectErase);
        }

        #endregion
    }
}
