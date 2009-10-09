using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using AForge.Imaging.Filters;

namespace EvolutionNet.Util.Imaging
{
	public static class ImageProcessing
	{
		public static void ResizeOnStream(string imgPath, Size newSize, Stream stream)
		{
			Bitmap imgResized = Resize(imgPath, newSize);
			imgResized.Save(stream, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static Bitmap Resize(string fileName, Size newSize)
		{
			Bitmap img = (Bitmap)Image.FromFile(fileName);
			Bitmap imgResized = Resize(img, newSize);
			img.Dispose();
			return imgResized;
		}

		public static Bitmap Resize(Bitmap img, Size newSize)
		{
			int imgWidth = img.Width;
			int imgHeight = img.Height;
			int newSizeWidth = newSize.Width;
			int newSizeHeight = newSize.Height;

			float nPercentW = ((float)newSizeWidth / imgWidth);
			float nPercentH = ((float)newSizeHeight / imgHeight);
			float nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

			int destWidth = (int)(imgWidth * nPercent);
			int destHeight = (int)(imgHeight * nPercent);

			//			AForge.Imaging.Image.FormatImage(ref img);
			ResizeBicubic resizeBicubic = new ResizeBicubic(destWidth, destHeight);
			Bitmap imgResized = resizeBicubic.Apply(img);
			img.Dispose();

			return imgResized;
		}

		public static void ResizeFixedSizeOnStream(string imgPath, Size newSize, Color paddingColor, Stream stream)
		{
			Bitmap imgResized = ResizeFixedSize(imgPath, newSize, paddingColor);
			imgResized.Save(stream, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static Bitmap ResizeFixedSize(string fileName, Size newSize, Color paddingColor)
		{
			Bitmap img = (Bitmap)Image.FromFile(fileName);
			Bitmap imgResized = ResizeFixedSize(img, newSize, paddingColor);
			img.Dispose();
			return imgResized;
		}

		public static Bitmap ResizeFixedSize(Bitmap img, Size newSize, Color paddingColor)
		{
			int imgWidth = img.Width;
			int imgHeight = img.Height;
			int newSizeWidth = newSize.Width;
			int newSizeHeight = newSize.Height;

			float nPercentW = ((float)newSizeWidth / imgWidth);
			float nPercentH = ((float)newSizeHeight / imgHeight);
			float nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

			int destWidth = (int)(imgWidth * nPercent);
			int destHeight = (int)(imgHeight * nPercent);

			int destX = 0;
			int destY = 0;
			if (nPercentH < nPercentW)
			{
				nPercent = nPercentH;
				destX = (int)((newSize.Width - (img.Width * nPercent)) / 2);
			}
			else
			{
				nPercent = nPercentW;
				destY = (int)((newSize.Height - (img.Height * nPercent)) / 2);
			}

			Bitmap imgResized = new Bitmap(newSizeWidth, newSizeHeight,
			                            PixelFormat.Format24bppRgb);
			imgResized.SetResolution(img.HorizontalResolution,
			                         img.VerticalResolution);

			Graphics grPhoto = Graphics.FromImage(imgResized);
			grPhoto.Clear(paddingColor);
			grPhoto.InterpolationMode =
				InterpolationMode.HighQualityBicubic;

			grPhoto.DrawImage(img,
			                  new Rectangle(destX, destY, destWidth, destHeight),
			                  new Rectangle(0, 0, imgWidth, imgHeight),
			                  GraphicsUnit.Pixel);

			grPhoto.Dispose();
			img.Dispose();

			return imgResized;
		}

		public static string IntToHex(int number)
		{
			return string.Format("{0:x}", number);
		}

		public static int HexToInt(string hexString)
		{
			return int.Parse(hexString,
			                 System.Globalization.NumberStyles.HexNumber, null);
		}

		public static Color ColorFromHexadecimal(string hexa)
		{
			int red = HexToInt(hexa.Substring(1, 2));
			int green = HexToInt(hexa.Substring(3, 2));
			int blue = HexToInt(hexa.Substring(5, 2));

			return Color.FromArgb(red, green, blue);
		}

		public static int ArgbFromHexadecimal(string hexa)
		{
			int red = HexToInt(hexa.Substring(1, 2));
			int green = HexToInt(hexa.Substring(3, 2));
			int blue = HexToInt(hexa.Substring(5, 2));

			return Color.FromArgb(red, green, blue).ToArgb();
		}

	}
}