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
				var menuHelper = view.HelperFactory.MenuHelper;

				var mnuFile = menuHelper.AddMenuItem("&File", "mnuFile");
				menuHelper.AddMenuItem("&Remove tab", "mnuFileRemoveTab", mnuFile, mnuFileRemoveTab);
				menuHelper.AddMenuItem("-", "", mnuFile);
				menuHelper.AddMenuItem("E&xit", "mnuFileExit", mnuFile, mnuFileExitClick);

				var mnuCategory = menuHelper.AddMenuItem("&Category", "mnuCategory");
				menuHelper.AddMenuItem("&Add tab", "mnuCategoryAddTab", mnuCategory, mnuCategoryAddTabClick);
				menuHelper.AddMenuItem("&Show dialog...", "mnuCategoryShowDialog", mnuCategory, mnuCategoryShowDialogClick);
			}
		}

		private void mnuFileRemoveTab(object sender, EventArgs e)
		{
			View.DeleteTabItem();
		}

		private void mnuCategoryShowDialogClick(object sender, EventArgs eventArgs)
		{
			ICategoryCrudView view = View.HelperFactory.RedirectHelper.CreateModalDialogView<ICategoryCrudView>(View);
			View.HelperFactory.RedirectHelper.ShowModalDialogView(view, View);
		}

		private void mnuCategoryAddTabClick(object sender, EventArgs eventArgs)
		{
			IControlHelper controlHelper = View.HelperFactory.GetControlHelper(View);
			View.AddTabItemView("Category Tab", controlHelper.CreateControlView<ICategoryCrudView>());
		}

		private void mnuFileExitClick(object sender, EventArgs eventArgs)
		{
			((IWinControl)View).Close();
		}

	}
}