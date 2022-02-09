using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PaintSharp.WPF.Converters
{
    public class HideLayerButtonIconConverter : IValueConverter
    {
        public PathGeometry HideIcon { get; set; }
        public PathGeometry ShowIcon { get; set; }

        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isVisible = (bool)value;
            if (isVisible)
            {
                return ShowIcon;
            }
            else
            {
                return HideIcon;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        } 

        #endregion
    }
}
