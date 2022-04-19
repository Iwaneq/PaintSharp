using System.Windows;
using System.Windows.Media.Imaging;

namespace PaintSharp.Core.State.ToolStateHelpers
{
    public interface IDrawDelegatesHelper
    {
        void DrawCircle(Point pt, WriteableBitmap writeableBitmap);
        void DrawRect(Point pt, WriteableBitmap writeableBitmap);
        void CircleErase(Point pt, WriteableBitmap writeableBitmap);
        void RectErase(Point pt, WriteableBitmap writeableBitmap);
        void CircleSpray(Point pt, WriteableBitmap writeableBitmap);
        void RectSpray(Point pt, WriteableBitmap writeableBitmap);
        void FloodFill(Point pt, WriteableBitmap writeableBitmap);
    }
}