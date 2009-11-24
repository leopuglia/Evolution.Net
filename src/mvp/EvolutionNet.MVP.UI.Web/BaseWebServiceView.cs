using System.Web.Services;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseWebServiceView : WebService, IView
	{
		public IPathHelper PathHelper
		{
			get { return WebPathHelper.Instance; }
		}

		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{
		}

	}
}