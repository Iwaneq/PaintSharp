using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.Services
{
    public class ToolStateChangerService : IToolStateChangerService
    {
        public void ChangeBrushColor(Color color)
        {
            ToolState.BrushColor = new SolidColorBrush(color);
        }
    }
}
