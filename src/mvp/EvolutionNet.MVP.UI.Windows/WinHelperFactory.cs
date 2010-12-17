using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinHelperFactory : IHelperFactory
	{
		public virtual IPathHelper PathHelper
		{
			get { return WinPathHelper.Instance; }
		}

		public IControlHelper GetControlHelper(IControlView view)
		{
			return WinControlHelper.CreateInstance(view);
		}

		public virtual IMessageHelper MessageHelper
		{
			get { return WinMessageHelper.Instance; }
		}

		public virtual IRedirectHelper RedirectHelper
		{
			get { return WinRedirectHelper.Instance; }
		}

		public IMenuHelper MenuHelper
		{
			get { return WinMenuHelper.Instance; }
		}
	}
}