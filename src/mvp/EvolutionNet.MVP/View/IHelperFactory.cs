using EvolutionNet.Util.IoC;
using EvolutionNet.Util.ProgressReporting;

namespace EvolutionNet.MVP.View
{
	public interface IHelperFactory : IFactory
	{
		IPathHelper PathHelper { get; }
		IControlHelper GetControlHelper(IControlView view);
		IMessageHelper MessageHelper { get; }
		IRedirectHelper RedirectHelper { get; }
		IMenuHelper MenuHelper { get; }
		IProgressReportHelper ProgressHelper { get; }
//		IBackgroundWorkerHelper GetBackgroundWorkerHelper(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm);
		IBackgroundWorkerHelper BackgroundWorkerHelper { get; }
	}
}