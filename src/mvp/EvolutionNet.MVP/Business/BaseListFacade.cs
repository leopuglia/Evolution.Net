using System;
using EvolutionNet.MVP.Contract;
using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using log4net;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseListFacade<TO, T, IdT> : IListContract
		where TO : ListTO<T, IdT> 
		where T : Model<IdT>
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseListFacade<TO, T, IdT>));

        #region Variáveis Privadas

		private readonly TO to;

		#endregion

		#region Variáveis Protegidas

		protected double progress;
		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Propriedades Protegidas

		/// <summary>
		/// Calcula o progresso restante ao método sendo utilizado.
		/// </summary>
		protected double RemainingProgress
		{
			get { return 100d - progress; }
		}

		#endregion

		#region Propriedades Públicas

		/// <summary>
		/// Transfer Object, contém a referência ao to, definido na View.
		/// </summary>
		public TO To
		{
			get
			{
				return to;
			}
		}

		#endregion

		#region Constructor

		protected BaseListFacade()
		{
//			DoInitialize();
			try
			{
				// Instancia o TO. Aqui é chamado o método construtor do TO, no caso o BaseTO, que é quem inicializa também o Dao
				to = (TO)Activator.CreateInstance(typeof(TO));
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error("Não foi possível instanciar o TO no Facade.", ex);

				throw new ApplicationException("Não foi possível instanciar o TO no Facade.", ex);
			}

		}

		#endregion

		#region IContract Members

		#region Eventos Públicos

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		public event EventHandler<ProgressEventArgs> ProgressReported;

		#endregion

		#region Métodos Públicos

		#region Métodos de Dados

		/// <summary>
		/// Lista todos os elementos do model
		/// </summary>
		public void FindAll()
		{
			DoFindAll();
		}

	    #endregion

		#region Initialize

/*
		/// <summary>
		/// Realiza toda a inicialização necessária.
		/// </summary>
		public virtual void Initialize()
		{
			if (!isInitialized)
			{
				try
				{
					ModelAbstractFactory.Instance.Initialize();
				}
				catch (Exception ex)
				{
                    if (log.IsErrorEnabled)
						log.Error("Não foi possível inicializar a ModelAbstractFactory.", ex);

					throw new ApplicationException("Não foi possível inicializar a ModelAbstractFactory.", ex);
				}

				isInitialized = true;
			}
		}
*/

		#endregion

		#region Dispose

/*
		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
		///</summary>
		public virtual void Dispose()
		{
			if (! isDisposed)
			{
				try
				{
					ModelAbstractFactory.Instance.Dispose();
				}
				catch (Exception ex)
				{
                    if (log.IsErrorEnabled)
						log.Error("Não foi possível destruir a ModelAbstractFactory.", ex);

					throw new ApplicationException("Não foi possível destruir a ModelAbstractFactory.", ex);
				}

				isDisposed = true;
			}
		}
*/

		#endregion

		#endregion

		#endregion

		#region Métodos de Eventos

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="step">O tamanho do passo atual realizado (porcentagem).</param>
		protected virtual void ReportProgressStep(double step)
		{
			progress += step;

			if (progress > 100)
				throw new ApplicationException("The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="progress">O progresso total realizado (porcentagem).</param>
		protected virtual void ReportProgressSet(double progress)
		{
			double step = progress - this.progress;
			this.progress = progress;

			if (progress > 100)
				throw new ApplicationException("The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}


		#endregion

		#region Hooks Protegidos

		protected virtual void DoFindAll()
		{
			Dao<T, IdT>.FindAll();
		}

		#endregion

		#region Métodos Auxiliares

/*
		private void DoInitialize()
		{
			Initialize();
		}
*/

		#endregion

	}
}
