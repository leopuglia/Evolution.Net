using System;
using System.Data;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Business.ProgressReporting;
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
	public abstract class BaseBO<TO> : BaseProgressReport, IContract where TO : class, ITO
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseBO<TO>));

		#region Local Attributes

		private readonly TO to;
		private readonly IPresenter presenter;

		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Public Properties

		/// <summary>
		/// Contains the reference to the current Presenter, created via PresenterFactory
		/// </summary>
		public IPresenter Presenter
		{
			get { return presenter; }
		}

		/// <summary>
		/// Contains the reference to the current Transfer Object, created (automatically) on the facade
		/// </summary>
		public virtual TO To
		{
			get { return to; }
		}

		#endregion

		#region Constructor

		protected BaseBO(IPresenter presenter)
		{
			// Sets the local reference to the Presenter
			this.presenter = presenter;

			// Initializes the ActiveRecord/NHibernate Session Scope
			DaoInitializer.Instance.InitializeSessionScope();

			try
			{
				// Create the TO Instance. The BaseTO constructor is called, creating the Dao instance
				to = Activator.CreateInstance<TO>();
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error(MVPCommonMessages.BaseFacade_Error001, ex);

				throw new MVPIoCException(MVPCommonMessages.BaseFacade_Error001, ex);
			}

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

		#endregion

	}
}