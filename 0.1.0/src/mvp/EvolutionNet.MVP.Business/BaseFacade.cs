using System;
using System.Reflection;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Core.Util;
using log4net;
using EvolutionNet.MVP.Core.Business;
using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Access;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Classe base para os Facade's, responsáveis pela implementação das regras de negócios.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
	/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
	/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
	public abstract class BaseFacade<TO, T, IdT> : IFacade<TO, T, IdT>
		where TO : ITo<T, IdT>
		where T : IModel<IdT>
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseFacade<TO, T, IdT>));

        #region Variáveis Privadas

		private TO to;

		#endregion

		#region Variáveis Protegidas

		protected double progress = 0;
		protected bool isInitialized = false;
		protected bool isDisposed = false;

		#endregion

		#region Propriedades Protegidas

		/// <summary>
		/// Data Access Object, contém a referência ao objeto de acesso a dados correspondente ao MainModel.
		/// </summary>
		protected IDao<IdT> Dao
		{
			get { return (IDao<IdT>)to.MainModel; }
			set { to.MainModel = (T)value; }
		}

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

		public BaseFacade()
		{
			DoInitialize();
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
		/// Busca os dados do MainModel a partir de um ID fornecido no mesmo
		/// </summary>
		public void Find()
		{
			DoFind();
		}

		/// <summary>
		/// Lista todos os elementos do model
		/// </summary>
		public void FindAll()
		{
			DoFindAll();
		}

		/// <summary>
		/// Salva o MainModel atual
		/// </summary>
		public void Save()
		{
			//TODO: Suponho que eu deveria iniciar/terminar a transação aki, ou então implementar o facade como
			//um objeto transacional, q inicia a transação qdo é criado e termina qdo é destruído
			//Um facade, para mim, é como uma "Unidade de Trabalho", então se a transação por alguma razão não 
			//for finalizada durante a execução do objeto, deveria ser executada na sua finalização.
			//Talvez eu tenha q criar métodos pra iniciar/terminar a transação, e um método Dispose,
			//de forma q eu possa usar o facade (ou até o ActiveRecord???) como um objeto disposable.
			//O problema é o tempo de vida do objeto, eu não sei qdo o facade vai ser destruído, nem qdo
			//o TO vai ser destruído, seria ao fechar um determinado form, mas eu devo ter q terminar a transação
			//ao realizar o commit
			
			//TODO: Talvez aki, eu possa verificar se já não existe a transação, se não existir crio, executo e termino.
			//O problema é q o idiota q for implementar, vai ter q ficar lembrando de abrir e fechar transação,
			//oq pode levar a problemas de esquecimento...
			//Uma possível solução é criar um método com um Hook q, este sim, pode ser sobrescrito!
			/* Seria algo do tipo:
			 * public sealed void Save()
			 * {
			 *   StartTransaction();
			 *   DoWork(); // ou Save(), qq coisa assim.
			 *   CommitTransaction();
			 * }
			 * 
			 * protected virtual void DoWork()
			 * {
			 *   Save();
			 * }
			 */
			//Outra coisa a lembrar é q provavelmente eu preciso fazer um tratamento de erros aki, mesmo q eu
			//jogue a excessão novamente, apenas pra garantir q chego no finally e, nele, finalizo a transação

			// Start Transaction
			TransactionScope transaction = new TransactionScope();
			
			try
			{
				DoSave();

				// Save Transaction
				transaction.VoteCommit();
				transaction.Flush();
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
				transaction.Dispose();
			}
		}

		/// <summary>
		/// Deleta o MainModel atual, mesmo a partir de um ID
		/// </summary>
		public void Delete()
		{
			// Start Transaction
			TransactionScope transaction = new TransactionScope();

			try
			{
				DoDelete();

				// Save Transaction
				transaction.VoteCommit();
				transaction.Flush();
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
				transaction.Dispose();
			}
		}

	    #endregion

		#region Initialize

		/// <summary>
		/// Realiza toda a inicialização necessária.
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
                        log.Error("Não foi possível inicializar a DaoAbstractFactory.", ex);

					throw new ApplicationException("Não foi possível inicializar a DaoAbstractFactory.", ex);
				}

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

				isInitialized = true;
			}
		}

		#endregion

		#region Dispose

		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
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
                        log.Error("Não foi possível destruir a DaoAbstractFactory.", ex);

                    throw new ApplicationException("Não foi possível destruir a DaoAbstractFactory.", ex);
				}

				isDisposed = true;
			}
		}

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
//#pragma warning disable ParameterHidesMember
		protected virtual void ReportProgressSet(double progress)
//#pragma warning restore ParameterHidesMember
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

		protected virtual void DoFind()
		{
			Type type = Dao.GetType();

			Dao = (IDao<IdT>)type.InvokeMember(
								"Find",
								BindingFlags.InvokeMethod | BindingFlags.Public |
								BindingFlags.Static | BindingFlags.FlattenHierarchy,
								null,
								null,
								new object[] { Dao.ID });
		}

		protected virtual void DoFindAll()
		{
			Type type = Dao.GetType();

			to.List = new SortableBindingList<T>(
				(T[])type.InvokeMember(
					"FindAll",
					BindingFlags.InvokeMethod | BindingFlags.Public |
					BindingFlags.Static | BindingFlags.FlattenHierarchy,
					null,
					null,
					null));
		}

		/// <summary>
		/// Realmente salva o MainModel. Pode ser sobrescrito.
		/// </summary>
		protected virtual void DoSave()
		{
			Dao.Save();
		}

		protected virtual void DoDelete()
		{
			Dao.Delete();
		}

		#endregion

		#region Métodos Auxiliares

		private void DoInitialize()
		{
			Initialize();
		}

		#endregion

	}
}
