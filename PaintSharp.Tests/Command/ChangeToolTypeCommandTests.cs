using Autofac.Extras.Moq;
using Moq;
using PaintSharp.Core.Commands;
using PaintSharp.Core.Navigation.Interfaces;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaintSharp.Tests.Command
{
    public class ChangeToolTypeCommandTests
    {
        [Theory]
        [InlineData(ToolType.Eraser)]
        [InlineData(ToolType.Pen)]
        [InlineData(ToolType.Spray)]
        [InlineData(ToolType.Fill)]
        public void Execute_WithValidData_ShouldWork(ToolType type)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var toolBar = mock.Create<ToolBarViewModel>();
                var command = mock.Create<ChangeToolTypeCommand>();

                command.Execute(type);

                mock.Mock<IToolStateChangerService>()
                    .Verify(x => x.ChangeToolType(type), Times.Once);
                mock.Mock<IToolOptionsNavigator>()
                    .Verify(x => x.Navigate(type, toolBar), Times.Once);
            }
        }

        [Fact]
        public void Execute_WithNullParameter_ShouldReturn()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var toolBar = mock.Create<ToolBarViewModel>();
                var command = mock.Create<ChangeToolTypeCommand>();

                command.Execute(null);

                mock.Mock<IToolStateChangerService>()
                    .Verify(x => x.ChangeToolType(It.IsAny<ToolType>()), Times.Never);
                mock.Mock<IToolOptionsNavigator>()
                    .Verify(x => x.Navigate(It.IsAny<ToolType>(), toolBar), Times.Never);
            }
        }
    }
}
