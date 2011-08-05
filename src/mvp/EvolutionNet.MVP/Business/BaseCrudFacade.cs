using System;
using System.Collections.Generic;
using System.Data;
using Castle.ActiveRecord;
using Castle.Components.Validator;
using EvolutionNet.MVP.Presenter;
using log4net;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Data.Access;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Base class for CRUD Facades, responsable to create basic business rules. (Deprecated, use BaseCrudBO)
	/// </summary>
	/// <typeparam name="TO">Tranfer Object: used to transfer values between the layers</typeparam>
	/// <typeparam name="ModelT">MainModel: used for the main entity of data (model)</typeparam>
	/// <typeparam name="IdT">Identity: ID type of the main entity</typeparam>
	[Obsolete]
	public abstract class BaseCrudFacade<TO, ModelT, IdT> : BaseFacade<TO>, ICrudContract<TO, ModelT, IdT>
		where TO : CrudTO<ModelT, IdT>
		where ModelT : class, IModel<IdT>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseCrudFacade<TO, ModelT, IdT>));
		private IList<ValidationError> errorList = new List<ValidationError>();

		#region Protected Properties

		//TODO: Colocar em um arquivo de configuração, sendo o padrão true
		protected abstract bool ThrowExceptionOnValidation { get; }

		#endregion

		#region Public Properties

		public IList<ValidationError> ErrorList
		{
			get { return errorList; }
			set { errorList = value; }
		}

		#endregion

		#region Constructor

		protected BaseCrudFacade(IPresenter presenter) : base(presenter)
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
						log.Error(CommonMessages.BaseCrudFacade_Error002);

					throw new MVPDataAccessException(CommonMessages.BaseCrudFacade_Error002, ex);
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
						log.Error(CommonMessages.BaseCrudFacade_Error001);

					throw new MVPDataAccessException(CommonMessages.BaseCrudFacade_Error001, ex);
				}
			}
		}

		/// <summary>
		/// Fetch the data of the MainModel from it's ID
		/// </summary>
		public void Find()
		{
			Execute(DoFind, false);
		}

		/// <summary>
		/// List all MainModel's to the List
		/// </summary>
		public void FindAll()
		{
			Execute(DoFindAll, false);
		}

		/// <summary>
		/// Validates, then Saves the current MainModel
		/// </summary>
		public void Save()
		{
			if (Validate(ThrowExceptionOnValidation))
				Execute(DoSave, true);
		}

		/// <summary>
		/// Deletes the current MainModel, using the object or it's ID
		/// </summary>
		public void Delete()
		{
			Execute(DoDelete, true);
		}

		/// <summary>
		/// Deletes the current MainModel, it's ID
		/// </summary>
		public void DeleteByID()
		{
			Execute(DoDeleteByID, true);
		}

		/// <summary>
		/// Validates the current MainModel
		/// </summary>
		/// <param name="throwException">Determine if it should fire a MVPValidationException on validation error</param>
		/// <returns>True if sucessfully validated</returns>
		public bool Validate(bool throwException)
		{
			return DoValidate(throwException);
		}

		#endregion

		#region Protected Virtual Methods

		// This methods do the actual work and are the ones that should be overriden on child classes

		/// <summary>
		/// Fetch the data of the MainModel from it's ID
		/// </summary>
		protected virtual void DoFind()
		{
			To.MainModel = Dao<ModelT, IdT>.FindByPrimaryKey(To.ID);
		}

		/// <summary>
		/// List all MainModel's to the List
		/// </summary>
		protected virtual void DoFindAll()
		{
			To.List = Dao<ModelT, IdT>.FindAll();
		}

		/// <summary>
		/// Validates, then Saves, the current MainModel
		/// </summary>
		protected virtual void DoSave()
		{
			Dao<ModelT, IdT>.Save(To.MainModel);
		}

		/// <summary>
		/// Deletes the current MainModel, using the object or it's ID
		/// </summary>
		protected virtual void DoDelete()
		{
			Dao<ModelT, IdT>.Delete(To.MainModel);
		}

		/// <summary>
		/// Deletes the current MainModel, it's ID
		/// </summary>
		protected virtual void DoDeleteByID()
		{
			To.MainModel = Dao<ModelT, IdT>.FindByPrimaryKey(To.ID);
			Dao<ModelT, IdT>.Delete(To.MainModel);
		}

		/// <summary>
		/// Validates the current MainModel
		/// </summary>
		/// <param name="throwException">Determine if it should fire a MVPValidationException on validation error</param>
		/// <returns>True if sucessfully validated</returns>
		protected virtual bool DoValidate(bool throwException)
		{
#if FRAMEWORK_3
			IValidatorRunner runner = new ValidatorRunner(new CachedValidationRegistry());
			if (runner.IsValid(To.MainModel))
				return true;

			ErrorSummary errors = runner.GetErrorSummary(To.MainModel);

			for (int i = 0; i < errors.ErrorsCount; i++)
			{
				ErrorList.Add(new ValidationError(errors.InvalidProperties[i], errors.ErrorMessages[i]));
			}

			if (throwException)
			{
				//TODO: Colocar a string em um resource
				throw new MVPValidationException(
					string.Format("Validation has failed with {0} errors. See inner exceptions for details.",
								  errors.ErrorsCount),
					ErrorList);
			}

#endif
			return false;
		}

		#endregion

	}
}
