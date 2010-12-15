using System;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;

namespace EvolutionNet.Sample.Presenter
{
	public class MainPresenter : BasePresenter<IMainView, IMainContract>
	{
		public MainPresenter(IMainView view) : base(view)
		{
//			if (view is IWinControl)
//			{
				var mnuCategory = view.AddMenuItem("&Category", "mnuCategory");
				view.AddMenuItem("&Show Dialog", "mnuCategoryShowDialog", mnuCategory, mnuCategoryShowDialogClick);
				view.AddMenuItem("E&xit", "mnuExit", mnuExitClick);
//			}
		}

		private void mnuCategoryShowDialogClick(object sender, EventArgs eventArgs)
		{
			ICategoryCrudView view = View.RedirectHelper.CreateModalDialogView<ICategoryCrudView>(View);
			View.RedirectHelper.ShowModalDialogView(view, View);
		}

		private void mnuExitClick(object sender, EventArgs eventArgs)
		{
			((IWinControl)View).Close();
		}

	}
}