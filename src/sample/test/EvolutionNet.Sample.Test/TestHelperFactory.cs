using System;
using EvolutionNet.MVP.UI.Web;
using EvolutionNet.MVP.View;

namespace EvolutionNet.Sample.Test
{
	public class TestHelperFactory : IHelperFactory
	{
		public virtual IPathHelper PathHelper
		{
			get { return TestPathHelper.Instance; }
		}

		public IControlHelper GetControlHelper(IControlView view)
		{
			return TestControlHelper.CreateInstance(view);
		}

		public virtual IMessageHelper MessageHelper
		{
			get { return TestMessageHelper.Instance; }
		}

		public virtual IRedirectHelper RedirectHelper
		{
			get { return TestRedirectHelper.Instance; }
		}

		public IMenuHelper MenuHelper
		{
			get { return TestMenuHelper.Instance; }
		}
	}
}