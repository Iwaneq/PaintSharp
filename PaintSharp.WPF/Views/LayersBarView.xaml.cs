using PaintSharp.WPF.Services;
using PaintSharp.WPF.Services.Interfaces;
using PaintSharp.WPF.Views.Layers;
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
    /// Logika interakcji dla klasy LayersBarView.xaml
    /// </summary>
    public partial class LayersBarView : UserControl
    {
        private IDetachViewService _detachViewService;

        #region Constructor / Setup

        public LayersBarView()
        {
            InitializeComponent();

            _detachViewService = new DetachViewService(this);
        }

        #endregion

        #region Detach View 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _detachViewService.DetachOrAttachView(((int)ActualHeight), ((int)ActualWidth), (Grid)this.Parent);
        }

        #endregion

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBox = (ListBox)sender;

            listBox.UnselectAll();
        }
    }
}
