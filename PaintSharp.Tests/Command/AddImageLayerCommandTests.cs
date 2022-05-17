using Autofac.Extras.Moq;
using Moq;
using PaintSharp.Core.Commands;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.ViewModels.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Xunit;

namespace PaintSharp.Tests.Command
{
    public class AddImageLayerCommandTests
    {
        [Fact]
        public void Execute_WithValidData_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<AddImageLayerMessageViewModel>();
                viewModel.BackgroundFilePath = "Valid Path";

                var command = mock.Create<AddImageLayerCommand>();

                command.Execute(viewModel);

                mock.Mock<IMessageBoxService>()
                    .Verify(x => x.ShowError(It.IsAny<string>(), It.IsAny<string>()), Times.Never);

                mock.Mock<ICreateBitmapSourceFromFileService>()
                    .Verify(x => x.CreateBitmapSource(viewModel.BackgroundFilePath), Times.Once);

                mock.Mock<IAddLayerService>()
                    .Verify(x => x.AddImageLayer(viewModel.LayerName, It.IsAny<BitmapSource>(), (float)viewModel.LayerOpacity / 100, viewModel.AutoScaleImage));
            }
        }

        [Fact]
        public void Execute__WithNullParameter_ShouldReturn()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var command = mock.Create<AddImageLayerCommand>();

                command.Execute(null);

                mock.Mock<IMessageBoxService>()
                    .Verify(x => x.ShowError(It.IsAny<string>(), It.IsAny<string>()), Times.Never);

                mock.Mock<ICreateBitmapSourceFromFileService>()
                   .Verify(x => x.CreateBitmapSource(It.IsAny<string>()), Times.Never);

                mock.Mock<IAddLayerService>()
                    .Verify(x => x.AddImageLayer(It.IsAny<string>(), It.IsAny<BitmapSource>(), It.IsAny<float>(), It.IsAny<bool>()), Times.Never);
            }
        }

        [Fact]
        public void Execute_WithNotValidFilePath_ShouldReturn()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<AddImageLayerMessageViewModel>();
                viewModel.BackgroundFilePath = "";
                var command = mock.Create<AddImageLayerCommand>();

                command.Execute(viewModel);

                mock.Mock<IMessageBoxService>()
                    .Verify(x => x.ShowError("Image path not valid", "Cannot create Image Layer without image. Make sure your Image Path is valid!"), Times.Once);

                mock.Mock<ICreateBitmapSourceFromFileService>()
                   .Verify(x => x.CreateBitmapSource(It.IsAny<string>()), Times.Never);

                mock.Mock<IAddLayerService>()
                    .Verify(x => x.AddImageLayer(It.IsAny<string>(), It.IsAny<BitmapSource>(), It.IsAny<float>(), It.IsAny<bool>()), Times.Never);
            }
        }
    }
}
