/*
 * Based on Lev Danielyan's article at http://www.codeproject.com/KB/graphics/exiftagcol.aspx.
 * His article is based on Asim Goheer's article at http://www.codeproject.com/KB/graphics/exifextractor.aspx
 */

namespace EvolutionNet.Util.Imaging
{
	public sealed class ExifTag
	{
		private readonly int id;
		private readonly string description;
		private readonly string fieldName;
		private string value;

		public int Id
		{
			get
			{
				return id;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}
		}

		public string FieldName
		{
			get
			{
				return fieldName;
			}
		}

		public string Value
		{
			get { return value; }
			set { this.value = value; }
		}

		public ExifTag(int id, string fieldName, string description)
		{
			this.id = id;
			this.description = description;
			this.fieldName = fieldName;
		}

		public override string ToString()
		{
			return string.Format("{0} ({1}) = {2}", Description, FieldName, Value);
		}

	}
}
