using System;
using System.Data;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Presenter;
using log4net;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Data.Access;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Classe base para os Facade's, responsáveis pela implementação das regras de negócios.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
	/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
	/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
	public abstract class BaseCrudFacade<TO, T, IdT> : IContract<TO, T, IdT>
		where TO : TO<T, IdT> 
		where T : class, IModel<IdT>
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseCrudFacade<TO, T, IdT>));

		private readonly TO to;
		private readonly IPresenter presenter;
		protected double progress;
		protected bool isInitialized;
		protected bool isDisposed;

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

		public IPresenter Presenter
		{
			get { return presenter; }
		}

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

		protected BaseCrudFacade(IPresenter presenter)
		{

			try
			{
				this.presenter = presenter;

				// Instancia o TO. Aqui é chamado o método construtor do TO, no caso o BaseTO, que é quem inicializa também o Dao
				to = Activator.CreateInstance<TO>();
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error("Não foi possível instanciar o TO no Facade.", ex);

				throw new FrameworkException("Não foi possível instanciar o TO no Facade.", ex);
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
		/// Executa o delegate em um ambiente transacional
		/// </summary>
		/// <param name="doAction">Delegate para uma função implementada pelo usuário</param>
		public void Execute(ActionDelegate doAction)
		{
			// Start Transaction
			TransactionScope transaction = new TransactionScope(TransactionMode.Inherits, IsolationLevel.ReadCommitted, OnDispose.Rollback);

			try
			{
				doAction();

				// Save Transaction
				transaction.VoteCommit();
			}
			catch
			{
				// RollBack Transaction
				transaction.VoteRollBack();

				if (log.IsErrorEnabled)
					log.Error("A transação foi cancelada por um erro.");

				throw;
			}
			finally
			{
				transaction.Flush();
				transaction.Dispose();
			}
		}

		/// <summary>
		/// Busca os dados do MainModel a partir de um ID fornecido no mesmo
		/// </summary>
		public void Find()
		{
			DoFind();
		}

		/// <summary>
		/// Salva o MainModel atual
		/// </summary>
		public void Save()
		{
			Execute(DoSave);
		}

		/// <summary>
		/// Deleta o MainModel atual, mesmo a partir de um ID
		/// </summary>
		public void Delete()
		{
			Execute(DoDelete);
		}

	    #endregion

		#region Initialize

/*
		/// <summary>
		/// Realiza toda a inicialização necessária.
		/// </summary>
		public void Initialize()
		{
			DoInitialize();
		}
*/

		#endregion

		#region Dispose

/*
		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
		///</summary>
		public void Dispose()
		{
			DoDispose();
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
				throw new FrameworkException("The maximum progress allowed is 100%");

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
				throw new FrameworkException("The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}


		#endregion

		#region Hooks Protegidos

		protected virtual void DoFind()
		{
			To.MainModel = Dao<T, IdT>.FindByPrimaryKey(to.ID);
		}

		/// <summary>
		/// Realmente salva o MainModel. Pode ser sobrescrito.
		/// </summary>
		protected virtual void DoSave()
		{
			Dao<T, IdT>.Save(to.MainModel);
		}

		protected virtual void DoDelete()
		{
			Dao<T, IdT>.Delete(to.MainModel);
		}

/*
		protected virtual void DoInitialize()
		{
			AbstractIoCFactory<IBaseFacadeFactory>.Instance.Initialize();
		}

		protected virtual void DoDispose()
		{
			AbstractIoCFactory<IBaseFacadeFactory>.Instance.Dispose();
		}
*/

		#endregion

	}
}
