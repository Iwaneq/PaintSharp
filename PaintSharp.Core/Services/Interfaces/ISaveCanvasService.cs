using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface ISaveCanvasService
    {
        void SaveCanvas(ItemsControl canvas);
    }
}
