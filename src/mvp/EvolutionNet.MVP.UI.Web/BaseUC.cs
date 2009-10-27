using System;
using System.Web.UI;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseUC : UserControl, IUCView
	{
		protected BaseMessageUC messageUC;

/*
		/// <summary>
		/// Presenter, contém a referência ao presenter da funcionalidade atual.
		/// </summary>
		protected PresenterT GetPresenter<PresenterT, ContractT, TO, T, IdT>()
			where PresenterT : BasePresenter<ContractT, TO, T, IdT>
			where ContractT : IContract<TO, T, IdT>
			where TO : TO<T, IdT>
			where T : class, IModel<IdT>
		{
			try
			{
				return (PresenterT)PresenterAbstractFactory.Instance.GetPresenter<TO, T, IdT>((IView)this);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Não foi possível instanciar o Presenter.", ex);
			}
		}
*/

/*
		public PresenterT GetPresenter<PresenterT>() where PresenterT : IPresenter
		{
			return (PresenterT)Activator.CreateInstance(typeof(PresenterT), new object[] {this});
		}

*/

		public virtual void Initialize()
		{
		}

		public object CreateControl(string name)
		{
			return LoadControl(name);
		}

		public object CreateControl(Type t, params object[] args)
		{
			return LoadControl(t, args);
		}

		public void ShowMessage(string message)
		{
			messageUC.ShowMessage(message);
		}

		public void ShowMessage(string message, bool isPostBack)
		{
			messageUC.ShowMessage(message, isPostBack);
		}

		public void ShowErrorMessage(string message, Exception ex)
		{
			messageUC.ShowErrorMessage(message, ex, false);
		}

		public void ShowErrorMessage(string message, Exception ex, bool isPostBack)
		{
			messageUC.ShowErrorMessage(message, ex, isPostBack);
		}

	}
}
