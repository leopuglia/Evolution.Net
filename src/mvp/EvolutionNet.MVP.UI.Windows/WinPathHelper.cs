using System.IO;
using System.Reflection;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinPathHelper : IPathHelper
	{
		#region Thread-safe Singleton

		private WinPathHelper()
		{
		}

		public static WinPathHelper Instance
		{
			get
			{
				return Nested.instance;
			}
		}
		
		class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly WinPathHelper instance = new WinPathHelper();
		}

		#endregion

		public string GetPhysicalPath(string virtualPath)
		{
			return Path.Combine(Assembly.GetExecutingAssembly().Location, GetRelativeFromVirtualPath(virtualPath));
		}

		public string GetAbsolutePath(string virtualPath)
		{
			return Path.Combine(Assembly.GetExecutingAssembly().Location, GetRelativeFromVirtualPath(virtualPath)).Replace(
				Assembly.GetExecutingAssembly().Location, "");
		}

		private string GetRelativeFromVirtualPath(string webPath)
		{
			webPath = webPath.Replace("~/", "");
			return webPath.Replace('/', '\\');
		}
	}
}