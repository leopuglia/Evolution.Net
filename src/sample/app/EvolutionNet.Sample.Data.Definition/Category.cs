using System;
using System.Drawing;
using System.IO;

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
						value.Save(ms, value.RawFormat);
						Picture = ms.ToArray();
					}
				}
			}
		}
	}
}