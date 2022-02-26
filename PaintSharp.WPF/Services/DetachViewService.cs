using PaintSharp.WPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PaintSharp.WPF.Services
{
    public class DetachViewService : IDetachViewService
    {
        private UIElement View;
        private Grid MainGrid;
        private Grid DetachedGrid;
        private Window DetachedWindow;
        private bool IsAttached = true;

        #region Constructor / Setup

        public DetachViewService(UIElement view)
        {
            View = view;
            DetachedGrid = new Grid();
        } 

        #endregion

        public void AttachView()
        {
            IsAttached = true;
            DetachedGrid.Children.Remove(View);
            if (DetachedWindow.IsVisible)
            {
                DetachedWindow.Close();
            }

            MainGrid.Children.Add(View);
        }

        public void DetachOrAttachView(int windowHeight, int windowWidth, Grid mainGrid)
        {
            if(MainGrid == null)
            {
                MainGrid = mainGrid;
            }

            if (!IsAttached)
            {
                AttachView();
            }
            else
            {
                DetachView(windowHeight, windowWidth);
            }
        }

        public void DetachView(int windowHeight, int windowWidth)
        {
            DetachedWindow = new Window();
            DetachedWindow.Width = windowWidth;
            DetachedWindow.Height = windowHeight;

            DetachedWindow.Content = DetachedGrid;

            MainGrid.Children.Remove(View);
            DetachedGrid.Children.Add(View);

            DetachedWindow.Closed += DetachedWindow_Closed;
            DetachedWindow.Topmost = true;
            DetachedWindow.Show();
            IsAttached = false;
        }

        private void DetachedWindow_Closed(object? sender, EventArgs e)
        {
            if (!IsAttached)
            {
                AttachView();
            }
        }
    }
}
