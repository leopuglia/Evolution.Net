using System;
using System.Reflection;
using EvolutionNet.MVP.Core.Business;
using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Access;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.Util;
using log4net;

namespace EvolutionNet.MVP.Business
{
	public class BaseListFacade<TO, T, IdT> : IListFacade<TO, T, IdT>
		where TO : IListTo<T, IdT>
		where T : IModel<IdT>
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseListFacade<TO, T, IdT>));

        #region Vari�veis Privadas

		private TO to;

		#endregion

		#region Vari�veis Protegidas

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

		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao to, definido na View.
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
			DoInitialize();
		}

		#endregion

		#region IContract Members

		#region Eventos P�blicos

		/// <summary>
		/// Reporta o progresso da requisi��o atual.
		/// </summary>
		public event EventHandler<ProgressEventArgs> ProgressReported;

		#endregion

		#region M�todos P�blicos

		#region M�todos de Dados

		/// <summary>
		/// Lista todos os elementos do model
		/// </summary>
		public void FindAll()
		{
			DoFindAll();
		}

	    #endregion

		#region Initialize

		/// <summary>
		/// Realiza toda a inicializa��o necess�ria.
		/// </summary>
		public virtual void Initialize()
		{
			if (!isInitialized)
			{
				try
				{
					DaoAbstractFactory.Instance.Initialize();
				}
				catch (Exception ex)
				{
                    if (log.IsErrorEnabled)
                        log.Error("N�o foi poss�vel inicializar a DaoAbstractFactory.", ex);

					throw new ApplicationException("N�o foi poss�vel inicializar a DaoAbstractFactory.", ex);
				}

				try
				{
					// Instancia o TO. Aqui � chamado o m�todo construtor do TO, no caso o BaseTO, que � quem inicializa tamb�m o Dao
					to = (TO)Activator.CreateInstance(typeof(TO));
				}
				catch (Exception ex)
				{
                    if (log.IsErrorEnabled)
                        log.Error("N�o foi poss�vel instanciar o TO no Facade.", ex);

                    throw new ApplicationException("N�o foi poss�vel instanciar o TO no Facade.", ex);
				}

				isInitialized = true;
			}
		}

		#endregion

		#region Dispose

		///<summary>
		/// Realiza a libera��o de recursos alocados pelo objeto.
		///</summary>
		public virtual void Dispose()
		{
			if (! isDisposed)
			{
				try
				{
					DaoAbstractFactory.Instance.Dispose();
				}
				catch (Exception ex)
				{
                    if (log.IsErrorEnabled)
                        log.Error("N�o foi poss�vel destruir a DaoAbstractFactory.", ex);

                    throw new ApplicationException("N�o foi poss�vel destruir a DaoAbstractFactory.", ex);
				}

				isDisposed = true;
			}
		}

		#endregion

		#endregion

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
				throw new ApplicationException("The maximum progress allowed is 100%");

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
				throw new ApplicationException("The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}


		#endregion

		#region Hooks Protegidos

		protected virtual void DoFindAll()
		{
			T dao = DaoAbstractFactory.Instance.GetDao<T, IdT>();
			Type type = dao.GetType();

			to.List = new SortableBindingList<T>(
				(T[])type.InvokeMember(
					"FindAll",
					BindingFlags.InvokeMethod | BindingFlags.Public |
					BindingFlags.Static | BindingFlags.FlattenHierarchy,
					null,
					null,
					null));
		}

		#endregion

		#region M�todos Auxiliares

		private void DoInitialize()
		{
			Initialize();
		}

		#endregion

	}
}
