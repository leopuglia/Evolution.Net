using System.Web.Services;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseWebServiceView : WebService, IView
	{
		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

/*
		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{
		}
*/

	}
}