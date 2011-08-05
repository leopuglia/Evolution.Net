using System.Web;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Web
{
	public abstract class BaseHandlerView : IHttpHandler, IView
	{
		public abstract void ProcessRequest(HttpContext context);
		public abstract bool IsReusable { get; }

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

	}
}