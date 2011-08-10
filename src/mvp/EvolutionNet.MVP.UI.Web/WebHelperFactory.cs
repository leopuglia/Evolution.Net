using System;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	public sealed class WebHelperFactory : IHelperFactory
	{
		public IPathHelper PathHelper
		{
			get { return WebPathHelper.Instance; }
		}

		public IControlHelper GetControlHelper(IControlView view)
		{
			return WebControlHelper.CreateInstance(view);
		}

		public IMessageHelper MessageHelper
		{
			get { return WebMessageHelper.Instance; }
		}

		public IRedirectHelper RedirectHelper
		{
			get { return WebRedirectHelper.Instance; }
		}

		//TODO: Implementar
		public IMenuHelper MenuHelper
		{
			get { throw new NotImplementedException(); }
		}

		//TODO: Implementar
		public IBackgroundWorkerHelper GetBackgroundWorkerHelper()
		{
			throw new NotImplementedException();
		}

	}
}