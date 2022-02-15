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
    /// Logika interakcji dla klasy AddLayerMessageView.xaml
    /// </summary>
    public partial class AddLayerMessageView : UserControl
    {
        #region Dependency Properties 

        public ICommand AddLayerCommand
        {
            get { return (ICommand)GetValue(AddLayerCommandProperty); }
            set { SetValue(AddLayerCommandProperty, value); }
        }
        public static readonly DependencyProperty AddLayerCommandProperty =
            DependencyProperty.Register("AddLayerCommand", typeof(ICommand), typeof(AddLayerMessageView), new PropertyMetadata(default(ICommand)));

        #endregion

        #region Constructor / Setup

        public AddLayerMessageView()
        {
            InitializeComponent();
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AddLayerCommand != null)
            {
                AddLayerCommand.Execute(DataContext);

                var parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
        }
    }
}
