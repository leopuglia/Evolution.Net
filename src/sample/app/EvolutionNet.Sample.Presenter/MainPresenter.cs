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
			if (view is IWinControl)
			{
				var mnuFile = view.AddMenuItem("&File", "mnuFile");
				view.AddMenuItem("&Remove tab", "mnuFileRemoveTab", mnuFile, mnuFileRemoveTab);
				view.AddMenuItem("-", "", mnuFile);
				view.AddMenuItem("E&xit", "mnuFileExit", mnuFile, mnuFileExitClick);

				var mnuCategory = view.AddMenuItem("&Category", "mnuCategory");
				view.AddMenuItem("&Add tab", "mnuCategoryAddTab", mnuCategory, mnuCategoryAddTabClick);
				view.AddMenuItem("&Show dialog...", "mnuCategoryShowDialog", mnuCategory, mnuCategoryShowDialogClick);
			}
		}

		private void mnuFileRemoveTab(object sender, EventArgs e)
		{
			View.DeleteTabItem();
		}

		private void mnuCategoryShowDialogClick(object sender, EventArgs eventArgs)
		{
			ICategoryCrudView view = View.RedirectHelper.CreateModalDialogView<ICategoryCrudView>(View);
			View.RedirectHelper.ShowModalDialogView(view, View);
		}

		private void mnuCategoryAddTabClick(object sender, EventArgs eventArgs)
		{
			View.AddTabItemView("Category Tab", View.ControlHelper.CreateControlView<ICategoryCrudView>());
		}

		private void mnuFileExitClick(object sender, EventArgs eventArgs)
		{
			((IWinControl)View).Close();
		}

	}
}