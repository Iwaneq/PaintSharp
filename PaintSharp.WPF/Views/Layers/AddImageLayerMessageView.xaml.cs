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

namespace PaintSharp.WPF.Views.Layers
{
    /// <summary>
    /// Logika interakcji dla klasy AddImageLayerMessageView.xaml
    /// </summary>
    public partial class AddImageLayerMessageView : UserControl
    {
        #region DependencyProperties

        public ICommand AddImageLayerCommand
        {
            get { return (ICommand)GetValue(AddImageLayerCommandProperty); }
            set { SetValue(AddImageLayerCommandProperty, value); }
        }
        public static readonly DependencyProperty AddImageLayerCommandProperty =
            DependencyProperty.Register("AddImageLayerCommand", typeof(ICommand), typeof(AddImageLayerMessageView), new PropertyMetadata(default(ICommand)));

        #endregion

        #region Constructor / Setup

        public AddImageLayerMessageView()
        {
            InitializeComponent();
        } 

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AddImageLayerCommand != null)
            {
                AddImageLayerCommand.Execute(DataContext);

                var parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
        }
    }
}
