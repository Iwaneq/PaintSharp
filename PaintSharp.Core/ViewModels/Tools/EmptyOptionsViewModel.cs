using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.ViewModels.Tools
{
    /// <summary>
    /// ToolOptionsViewModel class for Tools which don't any have options
    /// </summary>
    public class EmptyOptionsViewModel : BaseToolOptionsViewModel
    {
        public EmptyOptionsViewModel(IToolStateChangerService toolStateChanger) : base(toolStateChanger)
        {
            ToolType = ToolType.Fill;
            IsEmpty = true;
        }
    }
}
