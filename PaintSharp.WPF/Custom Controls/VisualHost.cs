using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PaintSharp.WPF.Custom_Controls
{
    public class VisualHost : FrameworkElement
    {
        private VisualCollection _visuals;

        private Brush FillBrush { get; set; }
        private Point Position { get; set; }
        private Size SpaceSize { get; set; }

        #region Constructor / Setup

        public VisualHost()
        {
            SetUpVisualCollection();

            SetUpEvents();
        } 

        private void SetUpEvents()
        {
            MouseLeftButtonDown += VisualHost_MouseLeftButtonDown;
            MouseLeftButtonUp += VisualHost_MouseLeftButtonUp;
            MouseMove += VisualHost_MouseMove;
        }

        private void SetUpVisualCollection()
        {
            _visuals = new VisualCollection(this);
            _visuals.Add(ClearVisualSpace());
        }

        #endregion

        #region Drawing Events

        void VisualHost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToolState.IsLeftButtonPressed = true;

        }

        void VisualHost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ToolState.IsLeftButtonPressed = false;
        }

        void VisualHost_MouseMove(object sender, MouseEventArgs e)
        {
            if (ToolState.IsLeftButtonPressed)
            {
                UIElement element = (UIElement)sender;
                Point pt = e.GetPosition(element);

                if (IsMouseInBounds(e))
                {
                    DrawPoint(pt);
                }
            }
        }

        private void DrawPoint(Point pt)
        {
            var drawingVisual = new DrawingVisual();
            using(DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(pt, ToolState.BrushSize);
                drawingContext.DrawRoundedRectangle(ToolState.BrushColor, null, rect, ToolState.BrushSize.Width, ToolState.BrushSize.Height);
            }

            _visuals.Add(drawingVisual);
        }

        private bool IsMouseInBounds(MouseEventArgs e)
        {
            var client = (FrameworkElement)this;
            Rect bounds = new Rect(0, 0, client.ActualWidth - ToolState.BrushSize.Width, client.ActualHeight - ToolState.BrushSize.Height);
            return bounds.Contains(e.GetPosition(this));
        }

        #endregion

        #region Methods for editing VisualSpace

        private DrawingVisual CreateDrawingVisualSpace(Brush borderBrush, Brush backgroundBrush, Point position, Size size)
        {
            FillBrush = backgroundBrush;
            Position = position;
            SpaceSize = size;

            DrawingVisual drawingVisual = new DrawingVisual();
            using(DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(Position, SpaceSize);
                Pen pen = new Pen(borderBrush, 1);

                drawingContext.DrawRectangle(FillBrush, pen, rect);
            }

            return drawingVisual;
        }

        private DrawingVisual ClearVisualSpace()
        {
            return CreateDrawingVisualSpace(Brushes.Silver, Brushes.Transparent, new Point(0, 0), new Size(300, 300));
        }

        #endregion

        #region Necessary for this UIElement

        protected override int VisualChildrenCount
        {
            get { return _visuals.Count; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if(index < 0 || index >= _visuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _visuals[index];
        }

        #endregion
    }
}
