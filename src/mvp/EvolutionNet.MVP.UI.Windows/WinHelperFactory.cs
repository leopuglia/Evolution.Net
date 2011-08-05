using System;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.ProgressReporting;

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

		public virtual IMenuHelper MenuHelper
		{
			get { return WinMenuHelper.Instance; }
		}

		//TODO: Implementar
		public IProgressReportHelper ProgressHelper
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
//			return WinBackgroundWorkerHelper.CreateInstance(view, workerEnabledOnLoad, showProgressDlgFrm);
//		}
	}
}