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

		//TODO: Não sei se o BackgroundWorker deve ficar relacionado aqui, pois não sei se o comportamente dele é de um singleton. 
		// Teoricamente cada view deve ter o seu backgroundworker separadamente, para execução de tarefas em paralelo.
		// No meu caso eu não tenho utilizado, pois os meus forms executam tarefas um de cada vez
		// Uma outra coisa é que o trabalho a ser executado deve ser definido por um métodos na View
		// Assim sendo, meus métodos virtuais do worker deveriam ser definidos na view e passados ao Worker via delegate, ou então definidos como eventos...

		// Pensando melhor, eu uso o worker apenas pra realizar as tarefas em segundo plano, de modo a poder exibir o progresso
		// Assim sendo, eu só vou ter um BackgroundWorker rodando de cada vez...
//		IBackgroundWorkerHelper BackgroundWorkerHelper { get; }
		IBackgroundWorkerHelper GetBackgroundWorkerHelper();
	}
}