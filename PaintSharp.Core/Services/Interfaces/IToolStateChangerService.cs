using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface IToolStateChangerService
    {
        void ChangeBrushColor(Color color);
        void ChangeToolSize(int width, int height);
        void ChangeToolType(ToolType toolType);
    }
}
