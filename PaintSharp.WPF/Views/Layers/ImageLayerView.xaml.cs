using PaintSharp.Core.State;
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
    /// Logika interakcji dla klasy ImageLayerView.xaml
    /// </summary>
    public partial class ImageLayerView : UserControl
    {
        //Click Position for LayerMove Events
        private Point clickPosition;

        public int LayerIndex { get; set; }

        #region Dependency Properties for Drawing Commands

        public ICommand ImageLayerLeftButtonDownCommand
        {
            get { return (ICommand)GetValue(LeftButtonDownCommandProperty); }
            set { SetValue(LeftButtonDownCommandProperty, value); }
        }
        public static readonly DependencyProperty LeftButtonDownCommandProperty =
            DependencyProperty.Register("ImageLayerLeftButtonDownCommand", typeof(ICommand), typeof(ImageLayerView), new PropertyMetadata(default(ICommand)));


        public ICommand ImageLayerLeftButtonUpCommand
        {
            get { return (ICommand)GetValue(LeftButtonUpCommandProperty); }
            set { SetValue(LeftButtonUpCommandProperty, value); }
        }
        public static readonly DependencyProperty LeftButtonUpCommandProperty =
            DependencyProperty.Register("ImageLayerLeftButtonUpCommand", typeof(ICommand), typeof(ImageLayerView), new PropertyMetadata(default(ICommand)));


        public ICommand ImageLayerMouseDrawCommand
        {
            get { return (ICommand)GetValue(MouseDrawCommandProperty); }
            set { SetValue(MouseDrawCommandProperty, value); }
        }
        public static readonly DependencyProperty MouseDrawCommandProperty =
            DependencyProperty.Register("ImageLayerMouseDrawCommand", typeof(ICommand), typeof(ImageLayerView), new PropertyMetadata(default(ICommand)));

        #endregion

        #region Constructor / Setup

        public ImageLayerView()
        {
            InitializeComponent();

            SetUpZIndex();
        }

        private void SetUpZIndex()
        {
            LayerIndex = ++LayerState.LayersCount;
            Panel.SetZIndex(this, LayerIndex);
        }

        #endregion

        #region Drawing Events

        protected void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //If Tool is "OneClick" (Like fill bucket), it'll Draw on MouseLeftButtonDown
            if (ToolState.IsToolOneClickType && ImageLayerMouseDrawCommand != null)
            {
                Draw(sender, e);
            }
            else if (ImageLayerLeftButtonDownCommand != null)
            {
                ImageLayerLeftButtonDownCommand.Execute(null);
            }
        }
        protected void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ImageLayerLeftButtonUpCommand != null)
            {
                ImageLayerLeftButtonUpCommand.Execute(null);
            }
        }
        protected void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToolState.IsLeftButtonPressed && !ToolState.IsToolOneClickType && ImageLayerMouseDrawCommand != null)
            {
                Draw(sender, e);
            }
        }

        protected void Draw(object sender, MouseEventArgs e)
        {
            UIElement element = (UIElement)sender;
            Point pt = e.GetPosition(element);

            ImageLayerMouseDrawCommand.Execute(pt);
        }

        #endregion

        #region LayerMove Events

        private void UserControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(LayerState.CurrentLayerTab != null)
            {
                LayerMoveState.IsRightButtonPressed = true;
                clickPosition = e.GetPosition(this);
                CaptureMouse();
            }
        }

        private void UserControl_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (LayerState.CurrentLayerTab != null)
            {
                LayerMoveState.IsRightButtonPressed = false;
                ReleaseMouseCapture();
            }
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            var layer = (UserControl)sender;

            if (LayerMoveState.IsRightButtonPressed)
            {
                Point currentPoint = e.GetPosition((UIElement)VisualParent);

                var transform = layer.RenderTransform as TranslateTransform;
                if (transform == null)
                {
                    transform = new TranslateTransform();
                    layer.RenderTransform = transform;
                }

                transform.X = currentPoint.X - clickPosition.X;
                transform.Y = currentPoint.Y - clickPosition.Y;
            }
        } 

        #endregion
    }
}
