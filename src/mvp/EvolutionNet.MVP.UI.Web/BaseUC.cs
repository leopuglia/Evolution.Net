using System;
using System.Web.UI;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseUC : UserControl
	{
		/// <summary>
		/// Presenter, contém a referência ao presenter da funcionalidade atual.
		/// </summary>
		protected PresenterT GetPresenter<PresenterT, TO, T, IdT>()
			where PresenterT : BasePresenter<TO, T, IdT>
			where TO : TO<T, IdT>
			where T : Model<IdT>
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

	}
}
