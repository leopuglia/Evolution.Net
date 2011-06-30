using System.Drawing;
using System.IO;

namespace EvolutionNet.Sample.Data.Definition
{
	public partial class Employee
	{
		public virtual Image PhotoImage
		{
			get { return Bitmap.FromStream(new MemoryStream(Photo), true); }
		}
	}
}