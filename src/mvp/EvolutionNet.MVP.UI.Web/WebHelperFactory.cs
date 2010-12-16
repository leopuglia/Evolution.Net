using System;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebHelperFactory : IHelperFactory
	{
		public virtual IPathHelper PathHelper
		{
			get { return WebPathHelper.Instance; }
		}

		public IControlHelper GetControlHelper(IControlView view)
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

		public IMenuHelper MenuHelper
		{
			get { throw new NotImplementedException(); }
		}
	}
}