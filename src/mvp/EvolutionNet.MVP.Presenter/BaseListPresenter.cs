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
	public class BaseListPresenter<TO, T, IdT> : IListPresenter<TO, T, IdT>
		where TO : IListTo<T, IdT>
		where T : IModel<IdT>
	{
		#region Vari�veis Privadas

		private IListView<TO, T, IdT> view;
		private IListFacade<TO, T, IdT> facade;

		#endregion

		#region Vari�veis Protegidas

		protected double progress;
		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Construtores

		protected BaseListPresenter(IListView<TO, T, IdT> view)
		{
			InitializeView(view);
		}

		#endregion

		#region Propriedades Protegidas

		protected IListFacade<TO, T, IdT> Facade
 		{
			get { return facade; }
		}

		#endregion

		#region M�todos Protegidos

		protected FacadeT GetFacade<FacadeT>() where FacadeT : IContract
		{
			return (FacadeT)facade;
		}

		#endregion

		#region IPresenter Members

		public ViewT GetView<ViewT>() where ViewT : IListView<TO, T, IdT>
		{
			return (ViewT)view;
		}

		#endregion

		#region IContract Members

		#region Eventos P�blicos

		public event EventHandler<ProgressEventArgs> ProgressReported;

		#endregion

		#region M�todos P�blicos

		#region M�todos de Dados

		public virtual void FindAll()
		{
			facade.FindAll();
		}

		#endregion

		#region Initialize

		public virtual void Initialize()
		{
			if (!isInitialized)
			{
				try
				{
					FacadeAbstractFactory.Instance.Initialize();

					//Criando o facade por IoC
					facade = FacadeAbstractFactory.Instance.GetListFacade(this);
//					facade.Initialize();

					facade.ProgressReported += facade_ProgressReported;

					isInitialized = true;
				}
				catch (Exception ex)
				{
					throw new ApplicationException("N�o foi poss�vel instanciar o Facade no Presenter.", ex);
				}
			}
		}

		#endregion

		#region Dispose

		///<summary>
		/// Realiza a libera��o de recursos alocados pelo objeto.
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
					throw new ApplicationException("N�o foi poss�vel destruir o Facade no Presenter.", ex);
				}
			}
		}

		#endregion

		#endregion

		#endregion

		#region M�todos de Eventos

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

		#region M�todos de Chamada de Eventos

		private void facade_ProgressReported(object sender, ProgressEventArgs e)
		{
			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(e.Step, e.Progress));
		}

		#endregion

		#region M�todos Auxiliares

		//TODO: Eu vivo mudando essa propriedade entre p�blica ou n�o. Decidir se devo inicializar o presenter direto no construtor ou nesse m�todo
		private void InitializeView(IListView<TO, T, IdT> view)
		{
			Initialize();

			//TODO: VERIFICAR, EXCLUIR A REFER�NCIA A BASEVIEW
			//Associando o TO, que � criado por IoC no Facade
			((BaseListView<TO, T, IdT>)view).To = facade.To;

			//Associando a view
			this.view = view;
		}

		#endregion

	}
}