using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using EvolutionNet.Util.Imaging;

namespace EvolutionNet.Sample.Data.Definition
{
	public partial class Category
	{
		public virtual Image PictureImage
		{
			get
			{
				if (Picture == null)
					return null;
				try
				{
					return Image.FromStream(new MemoryStream(Picture));
				}
				catch (Exception)
				{
					return Image.FromStream(new MemoryStream(Picture, 78, Picture.Length - 78));
//					throw;
				}
			}
			set
			{
				if (value == null)
					Picture = null;
				else
				{
					using (MemoryStream ms = new MemoryStream())
					{
//						JpegProcessing.Instance.Save(ms, (Bitmap)value);
						value.Save(ms, ImageFormat.Jpeg);
						Picture = ms.ToArray();
					}
				}
			}
		}
	}
}