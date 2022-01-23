using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PaintSharp.WPF.Control_Extensions
{
    public class SvgButtonExtension
    {
        public static readonly DependencyProperty SvgPathProperty = DependencyProperty.RegisterAttached("SvgPath", typeof(object), typeof(SvgButtonExtension));
        public static void SetSvgPath(UIElement element, object value)
        {
            element.SetValue(SvgPathProperty, value);
        }
        public static object GetSvgPath(UIElement element)
        {
            return (object)element.GetValue(SvgPathProperty);
        }
    }
}
