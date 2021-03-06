using System;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	public sealed class WebHelperFactory : IHelperFactory
	{
//		private WebBackgroundWorkerHelper backgroundWorkerHelper;
		private WebBackgroundWorkerHelper2 backgroundWorkerHelper;

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

		// TODO: Implementar
		public IMenuHelper MenuHelper
		{
			get { throw new NotImplementedException(); }
		}

		public IBackgroundWorkerHelper GetBackgroundWorkerHelper()
		{
//			return backgroundWorkerHelper ?? (backgroundWorkerHelper = new WebBackgroundWorkerHelper());
			return backgroundWorkerHelper ?? (backgroundWorkerHelper = new WebBackgroundWorkerHelper2());
		}

	}
}