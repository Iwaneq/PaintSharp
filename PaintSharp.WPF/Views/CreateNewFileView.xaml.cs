using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy CreateNewFileView.xaml
    /// </summary>
    public partial class CreateNewFileView : UserControl
    {
        #region Dependency Properties

        public ICommand CreateNewFileCommand
        {
            get { return (ICommand)GetValue(CreateNewFileCommandProperty); }
            set { SetValue(CreateNewFileCommandProperty, value); }
        }
        public static readonly DependencyProperty CreateNewFileCommandProperty = DependencyProperty.Register("CreateNewFileCommand", typeof(ICommand), typeof(CreateNewFileView), new PropertyMetadata(default(ICommand)));

        #endregion

        #region Constructor / Setup

        public CreateNewFileView()
        {
            InitializeComponent();
        } 

        #endregion

        private void CheckIfNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CreateNewFileCommand != null)
            {
                CreateNewFileCommand.Execute(null);

                var parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
        }
    }
}
