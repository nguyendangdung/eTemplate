
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace Alx.Web.Tests
{
	[TestFixture]
	public class ScreenshotTests
    {
		[Test]
		public void GivenDevice_TakeScreenshot_ShouldReturnImageWithCorrectSize()
        {
            // Arrange
            const string url = "https://www.google.co.uk";
            const Devices device = Devices.TabletPortrait;

            // Act
            var image = Screenshot.Take(url, device);

            // Assert
            Assert.IsNotNull(image);
            Assert.AreEqual(600, image.Width);
            Assert.AreEqual(960, image.Height);
			image.Save(Path.Combine(Guid.NewGuid().ToString()));
        }

		[Test]
		public void GivenTabletPortrait_SaveScreenshot_ShouldReturnImageWithCorrectSize()
        {
            // Arrange
            const string url = "https://www.google.co.uk";
            const string path = @"D:\projects\eTemplate\Web.Screenshot-master\Alx.Web.Tests\bin\Debug\screenshot_TabletPortrait.png";
            var format = ImageFormat.Png;
            const Devices device = Devices.TabletPortrait;

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Act
            Screenshot.Save(url, path, format, device);

            // Assert
            Assert.IsTrue(File.Exists(path));
            var image = Image.FromFile(path);
            Assert.IsNotNull(image);
            Assert.AreEqual(600, image.Width);
            Assert.AreEqual(960, image.Height);
        }

		[Test]
		public void GivenDefault_SaveScreenshot_ShouldReturnImageWithCorrectSize()
        {
            // Arrange
            const string url = "https://www.google.co.uk";
            const string path = @"D:\projects\eTemplate\Web.Screenshot-master\Alx.Web.Tests\bin\Debug\screenshot_Desktop.png";
            var format = ImageFormat.Png;

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Act
            Screenshot.Save(url, path, format);

            // Assert
            Assert.IsTrue(File.Exists(path));
            var image = Image.FromFile(path);
            Assert.IsNotNull(image);
            Assert.AreEqual(1920, image.Width);
            Assert.AreEqual(1080, image.Height);
        }

		[Test]
		public void GivenSpecificSize_SaveScreenshot_ShouldReturnImageWithCorrectSize()
        {
            // Arrange
            const string url = "https://www.google.co.uk";
            const string path = @"D:\projects\eTemplate\Web.Screenshot-master\Alx.Web.Tests\bin\Debug\screenshot_1000x800.png";
            var format = ImageFormat.Png;
            var size = new Size(1000, 800);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Act
            Screenshot.Save(url, path, format, size);

            // Assert
            Assert.IsTrue(File.Exists(path));
            var image = Image.FromFile(path);
            Assert.IsNotNull(image);
            Assert.AreEqual(size.Width, image.Width);
            Assert.AreEqual(size.Height, image.Height);
        }
    }
}
