using System;
using System.Data;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;
using log4net;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Base class for all Business Objects. Implements the IContract interface.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object: used to transfer values between the layers</typeparam>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="IdT"></typeparam>
	public class BaseReadBO<TO, T, IdT> : BaseBO<TO>
		where TO : ReadTO<T, IdT>
		where T : class, IModel<IdT>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseReadBO<TO, T, IdT>));

		#region Constructor

		protected BaseReadBO(IPresenter presenter) : base(presenter)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Executes the informed methos (ActionDelegate) inside a transaction (or not). 
		/// All the other methods use this one to execute the data operations inside a transaction.
		/// </summary>
		/// <param name="doAction">Method to be executed</param>
		/// <param name="insideTransaction">Inform if it should be executed inside a transaction</param>
		public void Execute(ActionDelegate doAction, bool insideTransaction)
		{
			if (insideTransaction)
			{
				// Start Transaction
				TransactionScope transaction =
					new TransactionScope(TransactionMode.Inherits, IsolationLevel.ReadCommitted, OnDispose.Rollback);

				try
				{
					// Execute the method passed via ActionDelegate
					doAction();

					// Save Transaction
					transaction.VoteCommit();
					transaction.Flush();
				}
				catch (Exception ex)
				{
					// RollBack Transaction
					transaction.VoteRollBack();

					if (log.IsErrorEnabled)
						log.Error(MVPCommonMessages.BaseCrudBO_Error002);

					throw new MVPDataAccessException(MVPCommonMessages.BaseCrudBO_Error002, ex);
				}
				finally
				{
					transaction.Dispose();
				}
			}
			else
			{
				try
				{
					doAction();
				}
				catch (Exception ex)
				{
					if (log.IsErrorEnabled)
						log.Error(MVPCommonMessages.BaseCrudBO_Error001);

					throw new MVPDataAccessException(MVPCommonMessages.BaseCrudBO_Error001, ex);
				}
			}
		}

		/// <summary>
		/// Fetch the data of the MainModel from the To.ID
		/// </summary>
		public void Find()
		{
			Execute(DoFind, false);
		}

		#endregion

		#region Protected Virtual Methods

		/// <summary>
		/// Fetch the data of the MainModel from the To.ID
		/// </summary>
		protected virtual void DoFind()
		{
			To.MainModel = Dao<T, IdT>.FindByPrimaryKey(To.ID);
		}

		#endregion

	}
}