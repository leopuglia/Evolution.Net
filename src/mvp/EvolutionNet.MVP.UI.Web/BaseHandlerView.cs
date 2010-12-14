using System.Web;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public abstract class BaseHandlerView : IHttpHandler, IView
	{
		public abstract void ProcessRequest(HttpContext context);
		public abstract bool IsReusable { get; }

		public IPathHelper PathHelper
		{
			get { return WebPathHelper.Instance; }
		}

	}
}