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

		private const int QUALITY = 75;

		#region Jpeg

		public static void SaveJpegOnStream(Stream stream, Bitmap img, long quality)
		{
			// Encoder parameter for image quality
			EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);

			// Jpeg image codec
			ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

			if (jpegCodec == null)
				return;

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;

			img.Save(stream, jpegCodec, encoderParams);
		}

		public static void SaveJpeg(string path, Bitmap img, long quality)
		{
			// Encoder parameter for image quality
			EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);

			// Jpeg image codec
			ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Jpeg);

			if (jpegCodec == null)
				return;

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;

			img.Save(path, jpegCodec, encoderParams);
		}

		public static ImageCodecInfo GetEncoderInfo(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

			foreach (ImageCodecInfo codec in codecs)
			{
				if (codec.FormatID == format.Guid)
					return codec;
			}
			return null;
		}

		public static ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			// Get image codecs for all image formats
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

			// Find the correct image codec
			foreach (ImageCodecInfo codec in codecs)
				if (codec.MimeType == mimeType)
					return codec;
			return null;
		}

		#endregion

		#region Crop

		public static void CropOnStream(string fileName, Rectangle cropArea, Stream stream)
		{
			Bitmap imgCrop = Crop(fileName, cropArea);
			SaveJpegOnStream(stream, imgCrop, QUALITY);
			imgCrop.Dispose();
		}

		public static Bitmap Crop(string fileName, Rectangle cropArea)
		{
			Bitmap img = new Bitmap(fileName);
			Bitmap imgCrop = Crop(img, cropArea);
			img.Dispose();
			return imgCrop;
		}

		public static Bitmap Crop(Bitmap img, Rectangle cropArea)
		{
			Bitmap imgCrop = img.Clone(cropArea, img.PixelFormat);
			img.Dispose();
			return imgCrop;
		}

		#endregion

		#region Resize

		public static void ResizeOnStream(Stream streamRead, Size newSize, Stream streamWrite)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = Resize(img, newSize);
			img.Dispose();
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void ResizeOnStream(string fileName, Size newSize, Stream streamWrite)
		{
			Bitmap imgResized = Resize(fileName, newSize);
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void ResizeOnStream(Bitmap img, Size newSize, Stream streamWrite)
		{
			Bitmap imgResized = Resize(img, newSize);
			imgResized.Save(streamWrite, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static void ResizeAndSaveJpeg(Stream streamRead, string newFileName, Size newSize)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = Resize(img, newSize);
			img.Dispose();
			SaveJpeg(newFileName, imgResized, QUALITY);
			imgResized.Dispose();
		}

		public static void ResizeAndSaveJpeg(string fileName, string newFileName, Size newSize)
		{
			Bitmap imgResized = Resize(fileName, newSize);
			SaveJpeg(newFileName, imgResized, QUALITY);
			imgResized.Dispose();
		}

		public static void ResizeAndSaveJpeg(Bitmap img, string newFileName, Size newSize)
		{
			Bitmap imgResized = Resize(img, newSize);
			img.Dispose();
			SaveJpeg(newFileName, imgResized, QUALITY);
			imgResized.Dispose();
		}

		public static Bitmap Resize(Stream streamRead, Size newSize)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = Resize(img, newSize);
			img.Dispose();
			return imgResized;
		}

		public static Bitmap Resize(string fileName, Size newSize)
		{
			Bitmap img = new Bitmap(fileName);
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

		#region ResizeFixedSize

		public static void ResizeFixedSizeOnStream(string fileName, Size newSize, Color paddingColor, Stream stream)
		{
			Bitmap imgResized = ResizeFixedSize(fileName, newSize, paddingColor);
			imgResized.Save(stream, ImageFormat.Jpeg);
			imgResized.Dispose();
		}

		public static Bitmap ResizeFixedSize(string fileName, Size newSize, Color paddingColor)
		{
			Bitmap img = new Bitmap(fileName);
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

	}
}