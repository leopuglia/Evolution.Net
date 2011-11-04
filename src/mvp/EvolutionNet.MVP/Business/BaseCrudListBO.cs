using System.Collections.Generic;
using Castle.Components.Validator;
using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;
using log4net;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Base class for CRUD BOs, responsable to create basic business rules. (Deprecated, use BaseCrudBO)
	/// </summary>
	/// <typeparam name="TO">Tranfer Object: used to transfer values between the layers</typeparam>
	/// <typeparam name="T">MainModel: used for the main entity of data (model)</typeparam>
	/// <typeparam name="IdT">Identity: ID type of the main entity</typeparam>
	public abstract class BaseCrudListBO<TO, T, IdT> : BaseListBO<TO, T, IdT>, ICrudListContract<TO, T, IdT>
		where TO : CrudListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseCrudListBO<TO, T, IdT>));
		private IList<ValidationError> errorList = new List<ValidationError>();

		#region Protected Properties

		// TODO: Colocar em um arquivo de configuração, sendo o padrão true
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

		protected BaseCrudListBO(IPresenter presenter) : base(presenter)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Validates, then Saves the current MainModel
		/// </summary>
		public void Save()
		{
			if (ValidateCurrentModel(ThrowExceptionOnValidation))
				Execute(DoSave, true);
		}

		public void SaveList()
		{
			if (ValidateCurrentModel(ThrowExceptionOnValidation))
				Execute(DoSaveList, true);
		}

		/// <summary>
		/// Deletes the current MainModel, using the object
		/// </summary>
		public void Delete()
		{
			Execute(DoDelete, true);
		}

		/// <summary>
		/// Deletes the current MainModel, using the object
		/// </summary>
		public void DeleteList()
		{
			Execute(DoDeleteList, true);
		}

		/// <summary>
		/// Deletes the current MainModel, using the To.ID
		/// </summary>
		public void DeleteByID()
		{
			Execute(DoDeleteByID, true);
		}

		public void DeleteListByIDs()
		{
			Execute(DoDeleteListByIDs, true);
		}

		/// <summary>
		/// Validates the current MainModel
		/// </summary>
		/// <param name="throwException">Determine if it should fire a MVPValidationException on validation error</param>
		/// <returns>True if sucessfully validated</returns>
		public bool ValidateCurrentModel(bool throwException)
		{
			return Validate(To.CurrentModel, throwException);
		}

		public bool ValidateList(IList<T> list, bool throwException)
		{
			var isValid = true;
			foreach (var model in list)
			{
				if (!Validate(model, throwException))
					isValid = false;
			}

			return isValid;
		}

		public bool Validate(T model, bool throwException)
		{
			return DoValidate(model, throwException);
		}

		#endregion

		#region Protected Virtual Methods

		// This methods do the actual work and are the ones that should be overriden on child classes

		/// <summary>
		/// Saves the current MainModel
		/// </summary>
		protected virtual void DoSave()
		{
			// TODO: Aqui eu poderia já buscar o objeto no BD e popular com os
			Dao<T, IdT>.Save(To.CurrentModel);
		}

		protected virtual void DoSaveList()
		{
			var originalModel = To.CurrentModel;
			foreach (var current in To.CurrentList)
			{
				To.CurrentModel = current;
				DoSave();
//				Dao<T, IdT>.Save(current);
			}
			To.CurrentModel = originalModel;
		}

		/// <summary>
		/// Deletes the current MainModel, using the MainModel instance
		/// </summary>
		protected virtual void DoDelete()
		{
			Dao<T, IdT>.Delete(To.CurrentModel);
		}

		/// <summary>
		/// Deletes the current MainModel, using the MainModel instance
		/// </summary>
		protected virtual void DoDeleteList()
		{
			var originalModel = To.CurrentModel;
			foreach (var current in To.CurrentList)
			{
				To.CurrentModel = current;
				DoDelete();
			}
			To.CurrentModel = originalModel;

//			foreach (var current in To.CurrentList)
//			{
//				Dao<T, IdT>.Delete(current);
//			}
		}

		/// <summary>
		/// Deletes the current MainModel by it's ID
		/// </summary>
		protected virtual void DoDeleteByID()
		{
			To.CurrentModel = Dao<T, IdT>.FindByPrimaryKey(To.CurrentModel.ID);
			Dao<T, IdT>.Delete(To.CurrentModel);
		}

		protected virtual void DoDeleteListByIDs()
		{
//			var originalID = To.CurrentID;
			var originalModel = To.CurrentModel;
			foreach (var current in To.CurrentList)
			{
//				To.CurrentID = current.ID;
				To.CurrentModel.ID = current.ID;
				DoDeleteByID();
			}
//			To.CurrentID = originalID;
			To.CurrentModel = originalModel;
		}

		/// <summary>
		/// Validates the current MainModel
		/// </summary>
		/// <param name="model"></param>
		/// <param name="throwException">Determine if it should fire a MVPValidationException on validation error</param>
		/// <returns>True if sucessfully validated</returns>
		protected virtual bool DoValidate(T model, bool throwException)
		{
#if FRAMEWORK_3
			IValidatorRunner runner = new ValidatorRunner(new CachedValidationRegistry());
			if (runner.IsValid(model))
				return true;

			ErrorSummary errors = runner.GetErrorSummary(model);

			for (int i = 0; i < errors.ErrorsCount; i++)
			{
				ErrorList.Add(new ValidationError(errors.InvalidProperties[i], errors.ErrorMessages[i]));
			}

			if (throwException)
			{
				// TODO: Colocar a string em um resource
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
