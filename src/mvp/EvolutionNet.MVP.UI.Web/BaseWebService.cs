using System.Web;
using System.Web.Services;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseWebService : WebService, IView
	{
		public virtual void Initialize()
		{
		}

		public virtual string MapPath(string relFileName)
		{
			return Server.MapPath(relFileName);
		}

		public virtual string ResolveClientUrl(string relPath)
		{
			return VirtualPathUtility.ToAbsolute(relPath);
		}

	}
}