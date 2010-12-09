using System;
using System.Collections.Generic;
using System.Data;
using Castle.ActiveRecord;
using Castle.Components.Validator;
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
	public abstract class BaseCrudFacade<TO, T, IdT> : BaseFacade<TO>, ICrudContract<TO, T, IdT>
		where TO : CrudTO<T, IdT> 
		where T : class, IModel<IdT>
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseCrudFacade<TO, T, IdT>));

        #region Variáveis Privadas

        private IList<ValidationError> errorList = new List<ValidationError>();

		#endregion

		#region Propriedades Protegidas

        //TODO: Colocar em um arquivo de configuração, sendo o padrão true
        protected abstract bool ThrowException { get; }

        #endregion

		#region Propriedades Públicas

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

		#region Métodos Públicos (de Dados)

		/// <summary>
		/// Executa o delegate em um ambiente transacional
		/// </summary>
		/// <param name="doAction">Delegate para uma função implementada pelo usuário</param>
		/// <param name="insideTransaction"></param>
		public void Execute(ActionDelegate doAction, bool insideTransaction)
		{
            if (insideTransaction)
            {
                // Start Transaction
                TransactionScope transaction =
                    new TransactionScope(TransactionMode.Inherits, IsolationLevel.ReadCommitted, OnDispose.Rollback);

                try
                {
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
                        log.Error("A transação foi cancelada por um erro.");

                    throw new MVPDataAccessException("A transação foi cancelada por um erro.", ex);
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
                        log.Error("A execução foi cancelada por um erro.");

                    throw new MVPDataAccessException("A transação foi cancelada por um erro.", ex);
                }
            }
		}

		/// <summary>
		/// Busca os dados do MainModel a partir de um ID fornecido no mesmo
		/// </summary>
		public void Find()
		{
            Execute(DoFind, false);
		}

        /// <summary>
        /// Lista todos os elementos do model
        /// </summary>
        public void FindAll()
        {
            Execute(DoFindAll, false);
        }

        /// <summary>
		/// Salva o MainModel atual
		/// </summary>
		public void Save()
		{
            HookSave();
		}

		/// <summary>
		/// Deleta o MainModel atual, mesmo a partir de um ID
		/// </summary>
		public void Delete()
		{
		    HookDelete();
		}

        public void DeleteByID()
        {
            HookDeleteByID();
        }

        public bool Validate(bool throwException)
        {
            return DoValidate(throwException);
        }

        #endregion

		#region Hooks Protegidos

		protected virtual void DoFind()
		{
			To.MainModel = Dao<T, IdT>.FindByPrimaryKey(To.ID);
		}

        protected virtual void DoFindAll()
        {
            To.List = Dao<T, IdT>.FindAll();
        }

        /// <summary>
		/// Realmente salva o MainModel. Pode ser sobrescrito.
		/// </summary>
		protected virtual void HookSave()
		{
            if (Validate(ThrowException))
                Execute(DoSave, true);
        }

        protected virtual void DoSave()
        {
            Dao<T, IdT>.Save(To.MainModel);
        }

        protected virtual void HookDelete()
		{
            Execute(DoDelete, true);
        }

        protected virtual void DoDelete()
        {
            Dao<T, IdT>.Delete(To.MainModel);
        }

        protected virtual void HookDeleteByID()
        {
            Execute(DoDeleteByID, true);
        }

        protected virtual void DoDeleteByID()
        {
            To.MainModel = Dao<T, IdT>.FindByPrimaryKey(To.ID);
            Dao<T, IdT>.Delete(To.MainModel);
        }

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
