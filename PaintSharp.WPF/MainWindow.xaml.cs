using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
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
        private bool rightButtonClicked = false;
        private Point clickPosition;
        private ScaleTransform _mainGridScaleTransform;
        private TranslateTransform _mainGridTranslateTransform;
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

            var transformGroup = new TransformGroup();
            _mainGridScaleTransform = new ScaleTransform();
            _mainGridTranslateTransform = new TranslateTransform();

            transformGroup.Children.Add(_mainGridScaleTransform);
            transformGroup.Children.Add(_mainGridTranslateTransform);

            MainGrid.RenderTransform = transformGroup;

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

        /// <summary>
        /// Event for Scaling Canvas by Mouse Scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            

            if (e.Delta > 0)
            {
                _mainGridScaleTransform.ScaleX *= 1.2;
                _mainGridScaleTransform.ScaleY *= 1.2;
            }
            else
            {
                _mainGridScaleTransform.ScaleX /= 1.2;
                _mainGridScaleTransform.ScaleY /= 1.2;
            }
        }

        /// <summary>
        /// Event for enabling Canvas Move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainGrid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (LayerState.CurrentLayerTab == null)
            {
                rightButtonClicked = true;
                clickPosition = e.GetPosition((UIElement)MainGrid.Parent);
                MainGrid.CaptureMouse();
            }
        }

        /// <summary>
        /// Event for disabling Canvas Move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (LayerState.CurrentLayerTab == null)
            {
                rightButtonClicked = false;
                MainGrid.ReleaseMouseCapture();
            }
        }

        /// <summary>
        /// Event for Canvas Move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (rightButtonClicked)
            {
                var parent = MainGrid.Parent;
                Point currentPoint = e.GetPosition((UIElement)parent);

                _mainGridTranslateTransform.X = currentPoint.X - clickPosition.X;
                _mainGridTranslateTransform.Y = currentPoint.Y - clickPosition.Y;
            }
        }
    }
}
