using Autofac.Extras.Moq;
using Moq;
using PaintSharp.Core.Commands;
using PaintSharp.Core.Exceptions;
using PaintSharp.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaintSharp.Tests.Command
{
    public class GetImagePathCommandTests
    {
        [Fact]
        public void Execute_WithValidData_ShouldWork()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var command = mock.Create<GetImagePathCommand>();

                mock.Mock<IMessageBoxService>()
                    .Setup(x => x.GetFilePath())
                    .Returns("Valid File Path");

                command.Execute(null);

                mock.Mock<IMessageBoxService>()
                    .Verify(x => x.ShowError(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            }
        }

        [Fact]
        public void Execute_WhenUserClosesMessageBox_ShouldNotThrowException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var command = mock.Create<GetImagePathCommand>();

                mock.Mock<IMessageBoxService>()
                    .Setup(x => x.GetFilePath())
                    .Throws<GetPathFailedException>();

                command.Execute(null);

                mock.Mock<IMessageBoxService>()
                    .Verify(x => x.ShowError(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            }
        }

        [Fact]
        public void Execute_WhenGettingFilePathOtherExceptionWasThrown_ShouldThrowException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var command = mock.Create<GetImagePathCommand>();

                mock.Mock<IMessageBoxService>()
                    .Setup(x => x.GetFilePath())
                    .Throws<Exception>();

                command.Execute(null);

                mock.Mock<IMessageBoxService>()
                    .Verify(x => x.ShowError(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            }
        }
    }
}
