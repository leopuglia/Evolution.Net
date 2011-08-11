using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EvolutionNet.Util.Imaging
{
	// TODO: Fazer o singleton da maneira certa!
	public class JpegProcessing
	{
		#region Instance

		private readonly int quality;
		public int Quality
		{
			get { return quality; }
		}

		private JpegProcessing(int quality)
		{
			this.quality = quality;
		}

		#endregion

		#region Static Singleton

		private const int DEFAULT_QUALITY = 75;
		private static readonly JpegProcessing instance;

		static JpegProcessing()
		{
			instance = new JpegProcessing(DEFAULT_QUALITY);
		}

		public static JpegProcessing Instance
		{
			get { return instance; }
		}

		public static JpegProcessing GetInstance(int quality)
		{
			return new JpegProcessing(quality);
		}

		#endregion

		#region Instance Methods

		#region DoSave

		private void DoSave(string newFileName, Stream streamRead, Bitmap img)
		{
			// Encoder parameter for image quality
			EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);

			// Jpeg image codec
			ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Jpeg);

			if (jpegCodec == null)
				return;

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;

			if (streamRead == null)
				img.Save(newFileName, jpegCodec, encoderParams);
			else
				img.Save(streamRead, jpegCodec, encoderParams);
		}

		#endregion

		#region Save Overloads

		public void Save(string newFileName, Bitmap img)
		{
			DoSave(newFileName, null, img);
		}

		public void Save(Stream streamRead, Bitmap img)
		{
			DoSave(null, streamRead, img);
		}

		#endregion

		#region Resize Overloads

		public void ResizeAndSave(Stream streamRead, string newFileName, Size newSize)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = ImageProcessing.Resize(img, newSize);
			img.Dispose();
			Save(newFileName, imgResized);
			imgResized.Dispose();
		}

		public void ResizeAndSave(string fileName, string newFileName, Size newSize)
		{
			Bitmap imgResized = ImageProcessing.Resize(fileName, newSize);
			Save(newFileName, imgResized);
			imgResized.Dispose();
		}

		public void ResizeAndSave(Bitmap img, string newFileName, Size newSize)
		{
			Bitmap imgResized = ImageProcessing.Resize(img, newSize);
			img.Dispose();
			Save(newFileName, imgResized);
			imgResized.Dispose();
		}

		#endregion

		#region Resize (FixedSize) Overloads

		public void ResizeAndSave(Stream streamRead, string newFileName, Size newSize, Color backColor)
		{
			Bitmap img = new Bitmap(streamRead);
			Bitmap imgResized = ImageProcessing.Resize(img, newSize, backColor);
			img.Dispose();
			Save(newFileName, imgResized);
			imgResized.Dispose();
		}

		public void ResizeAndSave(string fileName, string newFileName, Size newSize, Color backColor)
		{
			Bitmap imgResized = ImageProcessing.Resize(fileName, newSize, backColor);
			Save(newFileName, imgResized);
			imgResized.Dispose();
		}

		public void ResizeAndSave(Bitmap img, string newFileName, Size newSize, Color backColor)
		{
			Bitmap imgResized = ImageProcessing.Resize(img, newSize, backColor);
			img.Dispose();
			Save(newFileName, imgResized);
			imgResized.Dispose();
		}

		#endregion

		#region Auxiliary GetEnconderInfo

		public ImageCodecInfo GetEncoderInfo(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

			foreach (ImageCodecInfo codec in codecs)
			{
				if (codec.FormatID == format.Guid)
					return codec;
			}
			return null;
		}

		public ImageCodecInfo GetEncoderInfo(string mimeType)
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

		#endregion

	}

}