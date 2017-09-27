using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace eTemplate
{
	public static class ImageHelper
	{
		public static string ImageToBase64(this Image image)
		{
			using (MemoryStream m = new MemoryStream())
			{
				image.Save(m, ImageFormat.Bmp);
				byte[] imageBytes = m.ToArray();
				string base64String = Convert.ToBase64String(imageBytes);
				return base64String;
			}
		}
	}
}