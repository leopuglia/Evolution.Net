using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IHelperFactory : IFactory
	{
		IPathHelper PathHelper { get; }
		IControlHelper GetControlHelper(IControlView view);
		IMessageHelper MessageHelper { get; }
		IRedirectHelper RedirectHelper { get; }
		IMenuHelper MenuHelper { get; }
//		IBackgroundWorkerHelper GetBackgroundWorkerHelper(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm);

		//TODO: N�o sei se o BackgroundWorker deve ficar relacionado aqui, pois n�o sei se o comportamente dele � de um singleton. 
		// Teoricamente cada view deve ter o seu backgroundworker separadamente, para execu��o de tarefas em paralelo.
		// No meu caso eu n�o tenho utilizado, pois os meus forms executam tarefas um de cada vez
		// Uma outra coisa � que o trabalho a ser executado deve ser definido por um m�todos na View
		// Assim sendo, meus m�todos virtuais do worker deveriam ser definidos na view e passados ao Worker via delegate, ou ent�o definidos como eventos...

		// Pensando melhor, eu uso o worker apenas pra realizar as tarefas em segundo plano, de modo a poder exibir o progresso
		// Assim sendo, eu s� vou ter um BackgroundWorker rodando de cada vez...
//		IBackgroundWorkerHelper BackgroundWorkerHelper { get; }
		IBackgroundWorkerHelper GetBackgroundWorkerHelper();
	}
}