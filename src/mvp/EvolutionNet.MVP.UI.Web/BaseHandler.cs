using System.Web;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public abstract class BaseHandler : IHttpHandler, IView
	{
		public abstract void ProcessRequest(HttpContext context);
		public abstract bool IsReusable { get; }

		public virtual void Initialize()
		{
		}

		public virtual string MapPath(string relFileName)
		{
			return HttpContext.Current.Server.MapPath(relFileName);
		}

		public virtual string ResolveClientUrl(string relPath)
		{
			return VirtualPathUtility.ToAbsolute(relPath);
		}

	}
}