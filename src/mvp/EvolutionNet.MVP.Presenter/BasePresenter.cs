using System;
using EvolutionNet.MVP.Core.Business;
using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.Presenter;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.View;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenter<TO, T, IdT> : IPresenter<TO, T, IdT>
		where TO : ITo<T, IdT>
		where T : IModel<IdT>

	{
		#region Variáveis Privadas

		private IView<TO, T, IdT> view;
		private IFacade<TO, T, IdT> facade;

		#endregion

		#region Variáveis Protegidas

		protected double progress;
		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Construtores

//		public BasePresenter()
//		{
////			Initialize((IView<TO, T, IdT>) IoCHelper.InstantiateObj("{0}Presenter", GetType(), "{0}View", typeof (BaseView<TO, T, IdT>)));
//		}

		protected BasePresenter(IView<TO, T, IdT> view)
		{
			InitializeView(view);
		}

		#endregion

		#region Propriedades Protegidas

		protected IFacade<TO, T, IdT> Facade
 		{
			get { return facade; }
		}

		#endregion

		#region Métodos Protegidos

		protected FacadeT GetFacade<FacadeT>() where FacadeT : IFacade<TO, T, IdT>
		{
			return (FacadeT)facade;
		}

		#endregion

		#region IPresenter Members

		public ViewT GetView<ViewT>() where ViewT : IView<TO, T, IdT>
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

		public void FindAll()
		{
			facade.FindAll();
		}

		#endregion

		#region Initialize

//		public virtual void InitializeView()
//		{
//			view.To = Facade.CreateTO();
//		}

		public virtual void Initialize()
		{
			if (!isInitialized)
			{
				try
				{
					FacadeAbstractFactory.Instance.Initialize();

					//Criando o facade por IoC
					facade = FacadeAbstractFactory.Instance.GetFacade(this);
//					facade.Initialize();

					facade.ProgressReported += facade_ProgressReported;

					isInitialized = true;
				}
				catch (Exception ex)
				{
					throw new ApplicationException("Não foi possível instanciar o Facade no Presenter.", ex);
				}
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

		#region Métodos Auxiliares

		//TODO: Eu vivo mudando essa propriedade entre pública ou não. Decidir se devo inicializar o presenter direto no construtor ou nesse método
		private void InitializeView(IView<TO, T, IdT> view)
		{
			Initialize();

			//TODO: VERIFICAR, EXCLUIR A REFERÊNCIA A BASEVIEW
			//Associando o TO, que é criado por IoC no Facade
			((BaseView<TO, T, IdT>)view).To = facade.To;

			//Associando a view
			this.view = view;
		}

		#endregion

	}
}
