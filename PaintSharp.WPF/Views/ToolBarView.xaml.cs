using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaintSharp.WPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ToolBarView.xaml
    /// </summary>
    public partial class ToolBarView : UserControl
    {
        private bool isAttached = true;
        public Grid MainGrid { get; set; }
        public Grid DetachedGrid { get; set; }
        public Window DetachedWindow { get; set; }

        public ToolBarView()
        {
            InitializeComponent();
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!isAttached)
            {
                AttachControl();
            }
            else
            {
                MainGrid = (Grid)this.Parent;
                DeattachControl();
            }
        }

        private void AttachControl()
        {
            DetachedGrid.Children.Remove(this);

            MainGrid.Children.Add(this);

            DetachedWindow.Close();
            isAttached = true;
        }

        private void DeattachControl()
        {
            DetachedWindow = new Window();
            DetachedWindow.Width = ActualWidth;
            DetachedGrid = new Grid();
            DetachedWindow.Content = DetachedGrid;
            MainGrid.Children.Remove(this);

            DetachedGrid.Children.Add(this);

            DetachedWindow.Topmost = true;
            DetachedWindow.Show();
            isAttached = false;
        }
    }
}
