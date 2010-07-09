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
	/// Classe base para os Facade's, respons�veis pela implementa��o das regras de neg�cios.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object, tipo do objeto de transfer�ncia de dados</typeparam>
	/// <typeparam name="T">MainModel, tipo da principal entidade (model) do m�dulo</typeparam>
	/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
	public abstract class BaseCrudFacade<TO, T, IdT> : ICrudContract<TO, T, IdT>
		where TO : CrudTO<T, IdT> 
		where T : class, IModel<IdT>
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseCrudFacade<TO, T, IdT>));

        #region Vari�veis Privadas

		private readonly TO to;
        private readonly IPresenter presenter;

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

		#region Constructor

		protected BaseCrudFacade(IPresenter presenter)
		{

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

				throw new MVPException("N�o foi poss�vel instanciar o TO no Facade.", ex);
			}

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
		/// Executa o delegate em um ambiente transacional
		/// </summary>
		/// <param name="doAction">Delegate para uma fun��o implementada pelo usu�rio</param>
		public void Execute(ActionDelegate doAction)
		{
			// Start Transaction
			TransactionScope transaction = new TransactionScope(TransactionMode.Inherits, IsolationLevel.ReadCommitted, OnDispose.Rollback);

			try
			{
				doAction();

				// Save Transaction
				transaction.VoteCommit();
                transaction.Flush();
            }
			catch
			{
				// RollBack Transaction
				transaction.VoteRollBack();

				if (log.IsErrorEnabled)
					log.Error("A transa��o foi cancelada por um erro.");

				throw;
			}
			finally
			{
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
				throw new MVPException("The maximum progress allowed is 100%");

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
				throw new MVPException("The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}


		#endregion

		#region Hooks Protegidos

		protected virtual void DoFind()
		{
			To.MainModel = Dao<T, IdT>.FindByPrimaryKey(to.ID);
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
            if (Validate(true))
                Execute(DoSave);
        }

        protected virtual void DoSave()
        {
            Dao<T, IdT>.Save(to.MainModel);
        }

        protected virtual void HookDelete()
		{
            Execute(DoDelete);
        }

        protected virtual void DoDelete()
        {
            Dao<T, IdT>.Delete(to.MainModel);
        }

        protected virtual void HookDeleteByID()
        {
            Execute(DoDeleteByID);
        }

        protected virtual void DoDeleteByID()
        {
            to.MainModel = Dao<T, IdT>.FindByPrimaryKey(To.ID);
            Dao<T, IdT>.Delete(to.MainModel);
        }

        protected virtual bool DoValidate(bool throwException)
        {
            IValidatorRunner runner =
                new ValidatorRunner(new CachedValidationRegistry());
            if (runner.IsValid(to.MainModel))
                return true;

            if (throwException)
            {
                ErrorSummary errors = runner.GetErrorSummary(to.MainModel);

/*
                var errorMessages = new List<string>(errors.ErrorMessages);
                for (int i = 0; i < errorMessages.Count; i++)
                {
                    errorMessages[i] = errors.InvalidProperties[i] + ": " + errorMessages[i];
                }

                throw new MVPValidationException(
                    string.Format("Validation has failed with {0} errors. See inner exceptions for details.",
                                  errors.ErrorsCount),
                    CreateValidationExceptions(errorMessages));
*/
                IList<ValidationError> errorList = new List<ValidationError>();
                for (int i = 0; i < errors.ErrorsCount; i++)
                {
                    errorList.Add(new ValidationError(errors.InvalidProperties[i], errors.ErrorMessages[i]));
                }

                throw new MVPValidationException(
                    string.Format("Validation has failed with {0} errors. See inner exceptions for details.",
                                  errors.ErrorsCount),
                    errorList);
            }

            return false;
        }

        #endregion

	    #region M�todos Auxiliares

/*
	    private MVPValidationException CreateValidationExceptions(IList<string> errorMessages)
	    {
	        if (errorMessages.Count == 1)
	            return new MVPValidationException(errorMessages[0]);

	        string message = errorMessages[0];
	        errorMessages.RemoveAt(0);
	        return new MVPValidationException(message, CreateValidationExceptions(errorMessages));
	    }
*/

	    #endregion

    }
}