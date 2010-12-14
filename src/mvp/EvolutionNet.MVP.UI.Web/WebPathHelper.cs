using System.Web;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebPathHelper : BaseSingleton<WebPathHelper>, IPathHelper
	{
		public string GetPhysicalPath(string virtualPath)
		{
			return HttpContext.Current.Server.MapPath(virtualPath);
		}

        public string GetAbsolutePath(string virtualPath)
		{
            return VirtualPathUtility.ToAbsolute(virtualPath);
		}

	}
}