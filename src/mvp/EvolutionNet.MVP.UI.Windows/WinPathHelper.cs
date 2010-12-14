using System.IO;
using System.Reflection;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Windows
{
    public class WinPathHelper : BaseSingleton<WinPathHelper>, IPathHelper
	{
		public string GetPhysicalPath(string virtualPath)
		{
			return Path.Combine(Assembly.GetExecutingAssembly().Location, virtualPath);
		}

		public string GetAbsolutePath(string virtualPath)
        {
            return Path.Combine(Assembly.GetExecutingAssembly().Location, virtualPath).Replace(
                Assembly.GetExecutingAssembly().Location, "");
		}

	}
}