using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels;
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

namespace PaintSharp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISaveCanvasService _saveCanvasService;
        public MainViewModel ViewModel 
        {
            get
            {
                return (MainViewModel)DataContext;
            }
        }

        #region Constructor / Setup

        public MainWindow(ISaveCanvasService saveCanvasService)
        {
            InitializeComponent();

            _saveCanvasService = saveCanvasService;
        } 

        #endregion

        #region Chrome Buttons Events

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        } 

        #endregion

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel.OnCanvasSave += ViewModel_OnCanvasSave;
        }

        private void ViewModel_OnCanvasSave()
        {
            _saveCanvasService.SaveCanvas(MainCanvas);
        }

        ~MainWindow()
        {
            ViewModel.OnCanvasSave -= ViewModel_OnCanvasSave;
        }
    }
}
