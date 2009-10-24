using System;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Contract;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenter<TO, T, IdT> : IContract
		where TO : TO<T, IdT>
		where T : Model<IdT>

	{
		#region Variáveis Privadas

		private readonly IView view;
		private readonly IContract facade;

		#endregion

		#region Variáveis Protegidas

//		protected double progress;
		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Construtores

		protected BasePresenter(IView view)
		{
			facade = FacadeAbstractFactory.Instance.GetFacade(this);
			facade.ProgressReported += facade_ProgressReported;

			this.view = view;
			view.Initialize();
		}

		#endregion

		#region Propriedades Protegidas

//		protected BaseFacade<TO, T, IdT> Facade
// 		{
//			get { return (BaseFacade<TO, T, IdT>) facade; }
//		}

		protected TO To
		{
			get { return ((BaseFacade<TO, T, IdT>)facade).To; }
		}

		#endregion

		#region Métodos Protegidos

		protected FacadeT GetFacade<FacadeT>() where FacadeT : IContract
		{
			return (FacadeT) facade;
		}

		#endregion

		#region IPresenter Members

		public ViewT GetView<ViewT>() where ViewT : IView
		{
			return (ViewT)view;
		}

		#endregion

		#region IContract Members

		#region Eventos Públicos

		public event EventHandler<ProgressEventArgs> ProgressReported;

		#endregion

		#region Métodos Públicos

		#region Métodos de Dados

		public virtual void Find()
		{
			facade.Find();
		}

		public virtual void Save()
		{
			facade.Save();
		}

		public virtual void Delete()
		{
			facade.Delete();
		}

		#endregion

		#region Initialize

/*
		public virtual void Initialize()
		{
			if (!isInitialized)
			{
				try
				{
//					FacadeAbstractFactory.Instance.Initialize();

					//Criando o facade por IoC
					facade = FacadeAbstractFactory.Instance.GetFacade(this);
//					facade.Initialize();

					isInitialized = true;
				}
				catch (Exception ex)
				{
					throw new ApplicationException("Não foi possível instanciar o Facade no Presenter.", ex);
				}
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
					facade.Dispose();

					FacadeAbstractFactory.Instance.Dispose();

					isDisposed = true;
				}
				catch (Exception ex)
				{
					throw new ApplicationException("Não foi possível destruir o Facade no Presenter.", ex);
				}
			}
		}
*/

		#endregion

		#endregion

		#endregion

		#region Métodos de Eventos

/*
		protected virtual void ReportProgressStep(double step)
		{
			progress += step;

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}

		protected virtual void ReportProgressSet(double progress)
		{
			double step = progress - this.progress;
			this.progress = progress;

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}
*/

		#endregion

		#region Métodos de Chamada de Eventos

		private void facade_ProgressReported(object sender, ProgressEventArgs e)
		{
			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(e.Step, e.Progress));
		}

		#endregion

	}
}
