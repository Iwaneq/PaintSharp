using Autofac.Extras.Moq;
using Moq;
using PaintSharp.Core.Services;
using PaintSharp.Core.Services.Interfaces;
using PaintSharp.Core.State;
using PaintSharp.Core.State.ToolStateHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xunit;

namespace PaintSharp.Tests.Services
{
    public class ToolStateChangerServiceTests
    {
        private readonly IToolStateChangerService _toolStateChangerService;

        #region Colors
        public static IEnumerable<object[]> Colors => new List<object[]>
        {
            new object[] { System.Windows.Media.Colors.Red },
            new object[] { System.Windows.Media.Colors.Green },
            new object[] { System.Windows.Media.Colors.Blue }
        };
        #endregion

        public ToolStateChangerServiceTests()
        {
            using(var mock = AutoMock.GetLoose())
            {
                _toolStateChangerService = mock.Create<ToolStateChangerService>();
            }
        }

        [Theory]
        [MemberData(nameof(Colors))]
        public void ChangeBrushColor_WithValidData_ShouldWork(Color color)
        {
            _toolStateChangerService.ChangeBrushColor(color);

            Assert.Equal(color, ToolState.BrushColor);
        }

        [Fact]
        public void ChangeToolSize_WithValidData_ShouldWork()
        {
            _toolStateChangerService.ChangeToolSize(100, 150);

            Assert.Equal(100, ToolState.BrushSize.Width);
            Assert.Equal(150, ToolState.BrushSize.Height);
        }

        [Theory]
        [InlineData(0, 100, "width")]
        [InlineData(-100, -100, "width")]
        [InlineData(100, 0, "height")]
        [InlineData(100, -100, "height")]
        public void ChangeToolSize_WithInvalidSize_ShouldThrowException(int width, int height, string paramName)
        {
            Assert.Throws<ArgumentOutOfRangeException>(paramName, () => _toolStateChangerService.ChangeToolSize(width, height));
        }

        [Fact]
        public void ChangeToolRadius_WithValidRadius_ShouldWork()
        {
            _toolStateChangerService.ChangeToolRadius(10);

            Assert.Equal(10, ToolState.BrushRadius);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void ChangeToolRadius_WithInvalidRadius_ShouldThrowException(int radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>("radius", () => _toolStateChangerService.ChangeToolRadius(radius));
        }

        [Theory]
        [InlineData(ToolType.Eraser)]
        [InlineData(ToolType.Pen)]
        [InlineData(ToolType.Fill)]
        [InlineData(ToolType.Spray)]
        public void ChangeToolType_WithValidData_ShouldWork(ToolType toolType)
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IToolStateChangerHelper>()
                    .Setup(x => x.ChangeTool(toolType))
                    .Verifiable();

                var toolStateChangerService = mock.Create<ToolStateChangerService>();

                toolStateChangerService.ChangeToolType(toolType);

                mock.Mock<IToolStateChangerHelper>()
                    .Verify(x => x.ChangeTool(toolType), Times.Once);
            }
        }

        [Theory]
        [InlineData(ToolShape.Circle, ToolType.Fill)]
        [InlineData(ToolShape.Circle, ToolType.Eraser)]
        [InlineData(ToolShape.Rect, ToolType.Pen)]
        [InlineData(ToolShape.Rect, ToolType.Spray)]
        public void ChangeToolShape_WithValidData_ShouldWork(ToolShape shape, ToolType type)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IToolStateChangerHelper>()
                    .Setup(x => x.ChangeTool(type))
                    .Verifiable();

                var toolStateChangerService = mock.Create<ToolStateChangerService>();

                toolStateChangerService.ChangeToolShape(shape, type);

                mock.Mock<IToolStateChangerHelper>()
                    .Verify(x => x.ChangeTool(type), Times.Once);

                Assert.Equal(shape, ToolState.ToolShape);
            }
        }
    }
}
