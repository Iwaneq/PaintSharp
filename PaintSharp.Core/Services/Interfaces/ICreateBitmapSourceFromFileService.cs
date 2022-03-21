using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface ICreateBitmapSourceFromFileService
    {
        BitmapSource CreateBitmapSource(string filePath);
    }
}
