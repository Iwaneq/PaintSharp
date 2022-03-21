using PaintSharp.Core.Exceptions;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PaintSharp.WPF.Services
{
    public class SaveCanvasService : ISaveCanvasService
    {
        private readonly IMessageBoxService _messageBoxService;

        #region Constructor / Setup

        public SaveCanvasService(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        } 

        #endregion

        public void SaveCanvas(ItemsControl canvas)
        {
            //Render Canvas
            RenderTargetBitmap renderTarget = RenderCanvas(canvas);

            //Setup PngEncoder
            PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            //Try to get Saving Path
            string savingPath = "";
            try
            {
                savingPath = _messageBoxService.GetSavingPath();
            }
            catch (GetPathFailedException)
            {
                //If user closed MessageBox, we don't want to save file.
                return;
            }

            using(Stream stream = File.Create(savingPath))
            {
                pngEncoder.Save(stream);
            }
        }

        private RenderTargetBitmap RenderCanvas(ItemsControl canvas)
        {
            Rect bounds = new Rect(0,0, CanvasState.CanvasWidth, CanvasState.CanvasHeight);
            double dpi = 96;

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, PixelFormats.Default);

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext context = drawingVisual.RenderOpen())
            {
                VisualBrush brush = new VisualBrush(canvas);
                context.DrawRectangle(brush, null, new Rect(new Point(), bounds.Size));
            }
            renderTarget.Render(drawingVisual);

            return renderTarget;
        }
    }
}
