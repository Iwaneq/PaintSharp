using Autofac.Extras.Moq;
using Iwaneq.FileSystem.Systems.Interfaces;
using Moq;
using PaintSharp.Core.Services;
using PaintSharp.Core.Services.ServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xunit;

namespace PaintSharp.Tests.Services
{
    public class CreateBitmapSourceFromFileServiceTests
    {
        private BitmapImage _bitmapImage;
        public CreateBitmapSourceFromFileServiceTests()
        {
            var path = Path.Combine(Environment.CurrentDirectory, @"Utils\", "bitmap.bmp");
            Uri uri = new Uri(path);
            _bitmapImage = new BitmapImage(uri);
        }

        [Fact]
        public void CreateBitmapSource_WithValidData_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var createBitmapSourceService = mock.Create<CreateBitmapSourceFromFileService>();
                var source = mock.Mock<BitmapSource>().Object;

                mock.Mock<IFile>()
                    .Setup(x => x.Exists("filePath"))
                    .Returns(true);

                mock.Mock<IBitmapImageCreatorHelper>()
                    .Setup(x => x.CreateBitmapImage("filePath", UriKind.Absolute))
                    .Returns(_bitmapImage);

                var bitmapSource = createBitmapSourceService.CreateBitmapSource("filePath"); 

                Assert.NotNull(bitmapSource);
                Assert.Equal(_bitmapImage.PixelWidth, bitmapSource.PixelWidth);
                Assert.Equal(_bitmapImage.PixelHeight, bitmapSource.PixelHeight);
                Assert.Equal(96, bitmapSource.DpiX);
                Assert.Equal(96, bitmapSource.DpiY);
                Assert.Equal(PixelFormats.Bgra32, bitmapSource.Format);
            }
        }

        [Fact]
        public void CreateBitmapSource_WithEmptyFilePath_ShouldThrowException()
        {
            using(var mock = AutoMock.GetLoose())
            {
                var createBitmapSourceService = mock.Create<CreateBitmapSourceFromFileService>();

                Assert.Throws<ArgumentNullException>("filePath", () => createBitmapSourceService.CreateBitmapSource(""));
            }
        }

        [Fact]
        public void CreateBitmapSource_WithInvalidFilePath_ShouldThrowException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var createBitmapSourceService = mock.Create<CreateBitmapSourceFromFileService>();

                mock.Mock<IFile>()
                    .Setup(x => x.Exists("invalidFilePath"))
                    .Returns(false);

                Assert.Throws<FileNotFoundException>(() => createBitmapSourceService.CreateBitmapSource("invalidFilePath"));
            }
        }
    }
}
