using System;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;
using log4net;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseFacade<TO> : IContract
		where TO : class, ITO
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseFacade<TO>));

		#region Vari�veis Privadas e Protegidas

		private readonly TO to;
		private readonly IPresenter presenter;

		protected double progress;
		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Propriedades Protegidas

		/// <summary>
		/// Calcula o progresso restante ao m�todo sendo utilizado.
		/// </summary>
		protected double RemainingProgress
		{
			get { return 100d - progress; }
		}

		#endregion

		#region Propriedades P�blicas

		public IPresenter Presenter
		{
			get { return presenter; }
		}

		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao to, definido na View.
		/// </summary>
		public TO To
		{
			get { return to; }
		}

		#endregion

		#region Construtor

		protected BaseFacade(IPresenter presenter)
		{
			try
			{
				if (SessionScope.Current == null)
					new SessionScope(FlushAction.Never);
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error("N�o foi poss�vel iniciar uma sess�o no ActiveRecord/NHibernate.", ex);

				throw new MVPIoCException("N�o foi poss�vel iniciar uma sess�o no ActiveRecord/NHibernate.", ex);
			}

			try
			{
				this.presenter = presenter;

				// Instancia o TO. Aqui � chamado o m�todo construtor do TO, no caso o BaseTO, que � quem inicializa tamb�m o Dao
				to = Activator.CreateInstance<TO>();
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error("N�o foi poss�vel instanciar o TO no Facade.", ex);

				throw new MVPIoCException("N�o foi poss�vel instanciar o TO no Facade.", ex);
			}

		}

		#endregion

		#region Eventos P�blicos (IContract Members)

		/// <summary>
		/// Reporta o progresso da requisi��o atual.
		/// </summary>
		public virtual event EventHandler<ProgressEventArgs> ProgressReported;

		#endregion

		#region M�todos de Eventos

		/// <summary>
		/// Reporta o progresso da requisi��o atual.
		/// </summary>
		/// <param name="step">O tamanho do passo atual realizado (porcentagem).</param>
		protected virtual void ReportProgressStep(double step)
		{
			progress += step;

			if (progress > 100)
				throw new ArgumentOutOfRangeException("step", "The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}

		/// <summary>
		/// Reporta o progresso da requisi��o atual.
		/// </summary>
		/// <param name="progress">O progresso total realizado (porcentagem).</param>
		protected virtual void ReportProgressSet(double progress)
		{
			double step = progress - this.progress;
			this.progress = progress;

			if (progress > 100)
				throw new ArgumentOutOfRangeException("progress", "The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}


		#endregion

	}
}