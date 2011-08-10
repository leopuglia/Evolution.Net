using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinHelperFactory : IHelperFactory
	{
		public virtual IPathHelper PathHelper
		{
			get { return WinPathHelper.Instance; }
		}

		public virtual IControlHelper GetControlHelper(IControlView view)
		{
			return new WinControlHelper(view);
		}

		public virtual IMessageHelper MessageHelper
		{
			get { return WinMessageHelper.Instance; }
		}

		public virtual IRedirectHelper RedirectHelper
		{
			get { return WinRedirectHelper.Instance; }
		}

		public virtual IMenuHelper MenuHelper
		{
			get { return WinMenuHelper.Instance; }
		}

//		public IBackgroundWorkerHelper BackgroundWorkerHelper
//		{
//			get { return WinBackgroundWorkerHelper.CreateInstance(); }
//		}

		public IBackgroundWorkerHelper GetBackgroundWorkerHelper()
		{
//			return WinBackgroundWorkerHelper.CreateInstance();
			return new WinBackgroundWorkerHelper();
		}
	}
}