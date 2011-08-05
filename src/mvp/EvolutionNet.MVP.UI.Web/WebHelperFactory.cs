using System;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebHelperFactory : IHelperFactory
	{
		public virtual IPathHelper PathHelper
		{
			get { return WebPathHelper.Instance; }
		}

		public virtual IControlHelper GetControlHelper(IControlView view)
		{
			return WebControlHelper.CreateInstance(view);
		}

		public virtual IMessageHelper MessageHelper
		{
			get { return WebMessageHelper.Instance; }
		}

		public virtual IRedirectHelper RedirectHelper
		{
			get { return WebRedirectHelper.Instance; }
		}

		//TODO: Implementar
		public virtual IMenuHelper MenuHelper
		{
			get { throw new NotImplementedException(); }
		}

		//TODO: Implementar
		public IBackgroundWorkerHelper BackgroundWorkerHelper
		{
			get { throw new NotImplementedException(); }
		}

		//TODO: Implementar
//		public IBackgroundWorkerHelper GetBackgroundWorkerHelper(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
//		{
//			throw new NotImplementedException();
//		}
	}
}