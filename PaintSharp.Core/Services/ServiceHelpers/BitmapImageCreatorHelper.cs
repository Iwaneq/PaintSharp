using PaintSharp.Core.Services.ServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.Services.ServiceHelpers
{
    public class BitmapImageCreatorHelper : IBitmapImageCreatorHelper
    {
        public BitmapImage CreateBitmapImage(string filePath, UriKind uriKind)
        {
            return new BitmapImage(new Uri(filePath, uriKind));
        }
    }
}
