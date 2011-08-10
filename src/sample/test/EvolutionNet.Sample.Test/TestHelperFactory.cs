using System;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.Sample.Test
{
	public class TestHelperFactory : IHelperFactory
	{
		private readonly IHelperFactory winHelperFactory;

		private IPathHelper pathHelper;
		private IMessageHelper messageHelper;
		private IRedirectHelper redirectHelper;
		private IMenuHelper menuHelper;
//		private IBackgroundWorkerHelper backgroundWorkerHelper;

		public TestHelperFactory()
		{
			winHelperFactory = new WinHelperFactory();

			messageHelper = new TestMessageHelper();
//			redirectHelper = winHelperFactory.RedirectHelper;
			redirectHelper = new TestRedirectHelper();
			pathHelper = winHelperFactory.PathHelper;
		}

		public IPathHelper PathHelper
		{
			get { return pathHelper; }
			set { pathHelper = value; }
		}

		public IControlHelper GetControlHelper(IControlView view)
		{
			throw new NotImplementedException();
		}

		public IMessageHelper MessageHelper
		{
			get { return messageHelper; }
			set { messageHelper = value; }
		}

		public IRedirectHelper RedirectHelper
		{
			get { return redirectHelper; }
			set { redirectHelper = value; }
		}

		public IMenuHelper MenuHelper
		{
			get { return menuHelper; }
			set { menuHelper = value; }
		}

		public IBackgroundWorkerHelper GetBackgroundWorkerHelper()
		{
			throw new NotImplementedException();
//			return backgroundWorkerHelper;
		}

	}
}