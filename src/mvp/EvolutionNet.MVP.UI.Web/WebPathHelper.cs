using System.Web;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebPathHelper : IPathHelper
	{
		#region Thread Safe Singleton

		private WebPathHelper()
		{}

		public static WebPathHelper Instance
		{
			get { return Nested.instance; }
		}

		private class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly WebPathHelper instance = new WebPathHelper();
		}

		#endregion

		public string GetAbsolutePath(string path)
		{
			return HttpContext.Current.Server.MapPath(path);
		}

		public string GetRelativePath(string path)
		{
			return VirtualPathUtility.ToAbsolute(path);
		}

	}
}