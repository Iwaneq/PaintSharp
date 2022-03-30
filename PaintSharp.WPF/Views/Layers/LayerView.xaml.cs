using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy LayerControl.xaml
    /// </summary>
    public partial class LayerView : UserControl
    {
        public int LayerIndex { get; set; }

        #region Dependency Properties for Drawing Commands

        public ICommand LayerLeftButtonDownCommand
        {
            get { return (ICommand)GetValue(LeftButtonDownCommandProperty); }
            set { SetValue(LeftButtonDownCommandProperty, value); }
        }
        public static readonly DependencyProperty LeftButtonDownCommandProperty =
            DependencyProperty.Register("LayerLeftButtonDownCommand", typeof(ICommand), typeof(LayerView), new PropertyMetadata(default(ICommand)));


        public ICommand LayerLeftButtonUpCommand
        {
            get { return (ICommand)GetValue(LeftButtonUpCommandProperty); }
            set { SetValue(LeftButtonUpCommandProperty, value); }
        }
        public static readonly DependencyProperty LeftButtonUpCommandProperty =
            DependencyProperty.Register("LayerLeftButtonUpCommand", typeof(ICommand), typeof(LayerView), new PropertyMetadata(default(ICommand)));


        public ICommand LayerMouseDrawCommand
        {
            get { return (ICommand)GetValue(MouseDrawCommandProperty); }
            set { SetValue(MouseDrawCommandProperty, value); }
        }
        public static readonly DependencyProperty MouseDrawCommandProperty =
            DependencyProperty.Register("LayerMouseDrawCommand", typeof(ICommand), typeof(LayerView), new PropertyMetadata(default(ICommand)));

        #endregion

        #region Constructor / Setup

        public LayerView()
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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //If Tool is "OneClick" (Like fill bucket), it'll Draw on MouseLeftButtonDown
            if (ToolState.IsToolOneClickType && LayerMouseDrawCommand != null)
            {
                Draw(sender, e);
            }
            else if(LayerLeftButtonDownCommand != null)
            {
                LayerLeftButtonDownCommand.Execute(null);
            }
        }
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(LayerLeftButtonUpCommand != null)
            {
                LayerLeftButtonUpCommand.Execute(null);
            }
        }
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToolState.IsLeftButtonPressed && !ToolState.IsToolOneClickType && LayerMouseDrawCommand != null)
            {
                Draw(sender, e);
            }
        }

        private void Draw(object sender, MouseEventArgs e)
        {
            UIElement element = (UIElement)sender;
            Point pt = e.GetPosition(element);

            LayerMouseDrawCommand.Execute(pt);
        }

        #endregion

    }
}
