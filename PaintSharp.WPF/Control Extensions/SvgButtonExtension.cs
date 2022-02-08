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


        public static readonly DependencyProperty PaddingProperty = DependencyProperty.RegisterAttached("Padding", typeof(Thickness), typeof(SvgButtonExtension));
        public static void SetPadding(UIElement element, Thickness value)
        {
            element.SetValue(PaddingProperty, value);
        }
        public static Thickness GetPadding(UIElement element, Thickness value)
        {
            return (Thickness)element.GetValue(PaddingProperty);
        }
    }
}
