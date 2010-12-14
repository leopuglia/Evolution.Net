using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using log4net;

namespace EvolutionNet.Util.Imaging
{
	public static class ImageProcessing
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ImageProcessing));

		#region DoCrop

		private static Bitmap DoCrop(Bitmap img, Rectangle cropArea)
		{
			Bitmap imgCrop = img.Clone(cropArea, img.PixelFormat);
			img.Dispose();
			return imgCrop;
		}

		#endregion

		#region Crop Overloads

		public static Bitmap Crop(Bitmap img, Rectangle cropArea)
		{
			return DoCrop(img, cropArea);
		}

		public static Bitmap Crop(Stream streamRead, Rectangle cropArea)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = DoCrop(img, cropArea);
			img.Dispose();
			return imgResized;
		}

		public static Bitmap Crop(string fileName, Rectangle cropArea)
		{
			Bitmap img = new Bitmap(fileName);
			Bitmap imgCrop = DoCrop(img, cropArea);
			img.Dispose();
			return imgCrop;
		}

		public static void Crop(Stream streamRead, Rectangle cropArea, Stream streamWrite)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = DoCrop(img, cropArea);
			img.Dispose();
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void Crop(string fileName, Rectangle cropArea, Stream streamWrite)
		{
			Bitmap imgCrop = Crop(fileName, cropArea);
			imgCrop.Save(streamWrite, ImageFormat.Jpeg);
			imgCrop.Dispose();
		}

		public static void Crop(Bitmap img, Rectangle cropArea, Stream streamWrite)
		{
			Bitmap imgResized = DoCrop(img, cropArea);
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		#endregion

		#region DoResize

		private static Bitmap DoResize(Bitmap img, Size newSize)
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

//			ResizeBicubic resizeBicubic = new ResizeBicubic(destWidth, destHeight);
//			Bitmap imgResized = resizeBicubic.Apply(img);

			Bitmap imgResized = GetNewBitmap(img, destWidth, destHeight);

			Graphics g = Graphics.FromImage(imgResized);
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;

			g.DrawImage(img, 0, 0, destWidth, destHeight);

			g.Dispose();
			img.Dispose();

			return imgResized;
		}

		#endregion

		#region Resize Overloads

		public static Bitmap Resize(Bitmap img, Size newSize)
		{
			return DoResize(img, newSize);
		}

		public static Bitmap Resize(Stream streamRead, Size newSize)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = DoResize(img, newSize);
			img.Dispose();
			return imgResized;
		}

		public static Bitmap Resize(string fileName, Size newSize)
		{
			Bitmap img = new Bitmap(fileName);
			Bitmap imgResized = DoResize(img, newSize);
			img.Dispose();
			return imgResized;
		}

		public static void Resize(Stream streamRead, Size newSize, Stream streamWrite)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = DoResize(img, newSize);
			img.Dispose();
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void Resize(string fileName, Size newSize, Stream streamWrite)
		{
			Bitmap imgResized = Resize(fileName, newSize);
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void Resize(Bitmap img, Size newSize, Stream streamWrite)
		{
			Bitmap imgResized = DoResize(img, newSize);
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		#endregion

		#region DoResizeFixedSize

		private static Bitmap DoResizeFixedSize(Bitmap img, Size newSize, Color paddingColor)
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

			Bitmap imgResized = GetNewBitmap(img, newSizeWidth, newSizeHeight);

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

		#endregion

		#region Resize (FixedSize) Overloads

		public static Bitmap Resize(Bitmap img, Size newSize, Color paddingColor)
		{
			return DoResizeFixedSize(img, newSize, paddingColor);
		}

		public static Bitmap Resize(Stream streamRead, Size newSize, Color paddingColor)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = DoResizeFixedSize(img, newSize, paddingColor);
			img.Dispose();
			return imgResized;
		}

		public static Bitmap Resize(string fileName, Size newSize, Color paddingColor)
		{
			Bitmap img = new Bitmap(fileName);
			Bitmap imgResized = DoResizeFixedSize(img, newSize, paddingColor);
			img.Dispose();
			return imgResized;
		}

		public static void Resize(Stream streamRead, Size newSize, Color paddingColor, Stream streamWrite)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = DoResizeFixedSize(img, newSize, paddingColor);
			img.Dispose();
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void Resize(string fileName, Size newSize, Color paddingColor, Stream streamWrite)
		{
			Bitmap imgResized = Resize(fileName, newSize, paddingColor);
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void Resize(Bitmap img, Size newSize, Color paddingColor, Stream streamWrite)
		{
			Bitmap imgResized = DoResizeFixedSize(img, newSize, paddingColor);
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		#endregion

		#region Auxiliary Methods

		private static Bitmap GetNewBitmap(Image img, int destWidth, int destHeight)
		{
			log.DebugFormat("Creating a new bitmap with {0} width and {1} height", destWidth, destHeight);

			Bitmap imgResized = new Bitmap(destWidth, destHeight,
										   PixelFormat.Format24bppRgb);
			foreach (ExifTag exifTag in new ExifTagCollection(img))
			{
				log.DebugFormat("Adding propertyitem {0}: {1}", exifTag.Description, exifTag.Value);
				imgResized.SetPropertyItem(img.GetPropertyItem(exifTag.Id));
			}
			imgResized.SetResolution(img.HorizontalResolution,
									 img.VerticalResolution);
			return imgResized;
		}

		#endregion

	}
}