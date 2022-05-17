using Autofac.Extras.Moq;
using Moq;
using PaintSharp.Core.Commands;
using PaintSharp.Core.Navigation.Interfaces;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaintSharp.Tests.Command
{
    public class ChangeToolShapeCommandTests
    {
        [Theory]
        [InlineData(ToolShape.Circle, ToolType.Eraser)]
        [InlineData(ToolShape.Circle, ToolType.Pen)]
        [InlineData(ToolShape.Circle, ToolType.Spray)]
        [InlineData(ToolShape.Circle, ToolType.Fill)]
        [InlineData(ToolShape.Rect, ToolType.Eraser)]
        [InlineData(ToolShape.Rect, ToolType.Pen)]
        [InlineData(ToolShape.Rect, ToolType.Spray)]
        [InlineData(ToolShape.Rect, ToolType.Fill)]
        public void Execute_WithValidData_ShouldWork(ToolShape shape, ToolType type)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var toolStateChanger = mock.Mock<IToolStateChangerService>().Object;
                var command = new ChangeToolShapeCommand(toolStateChanger, type);

                command.Execute(shape);

                mock.Mock<IToolStateChangerService>()
                    .Verify(x => x.ChangeToolShape(shape, type), Times.Once);
            }
        }

        [Fact]
        public void Execute_WithNullParameter_ShouldReturn()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var toolStateChanger = mock.Mock<IToolStateChangerService>().Object;
                var command = new ChangeToolShapeCommand(toolStateChanger, ToolType.Pen);

                command.Execute(null);

                mock.Mock<IToolStateChangerService>()
                    .Verify(x => x.ChangeToolShape(It.IsAny<ToolShape>(), It.IsAny<ToolType>()), Times.Never);
            }
        }
    }
}
