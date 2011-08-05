using System;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;

namespace EvolutionNet.Sample.Presenter
{
	public class MainPresenter : BasePresenter<IMainView, IMainContract>
	{
		public MainPresenter(IMainView view) : base(view)
		{
			try
			{
				if (view is IWinControl)
				{
					InitWinMenu(view);
				}
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Could not initialize correctly", ex);
			}
		}

		private void InitWinMenu(IMainView view)
		{
			var menuHelper = HelperFactory.MenuHelper;
			var menuStrip = menuHelper.FindMenuStrip(view);

			var mnuFile = menuHelper.AddMenuItem("&File", "mnuFile", menuStrip);
			menuHelper.AddMenuItem("&Remove tab", "mnuFileRemoveTab", mnuFile, mnuFileRemoveTab);
			menuHelper.AddMenuItem("-", "", mnuFile);
			menuHelper.AddMenuItem("E&xit", "mnuFileExit", mnuFile, mnuFileExitClick);

			var mnuCategory = menuHelper.AddMenuItem("&Category", "mnuCategory", menuStrip);
			menuHelper.AddMenuItem("&Add tab", "mnuCategoryAddTab", mnuCategory, mnuCategoryAddTabClick);
			menuHelper.AddMenuItem("&Show dialog...", "mnuCategoryShowDialog", mnuCategory, mnuCategoryShowDialogClick);
		}

		protected void mnuFileRemoveTab(object sender, EventArgs e)
		{
			try
			{
				View.DeleteTabPage();
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Could not delete the tab", ex);
			}
		}

		protected void mnuCategoryAddTabClick(object sender, EventArgs e)
		{
			try
			{
				IControlHelper controlHelper = View.HelperFactory.GetControlHelper(View);
				View.AddTabPageView("Category Tab", controlHelper.CreateControlView<ICategoryCrudView>());
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Could not add tab", ex);
			}
		}

		protected void mnuCategoryShowDialogClick(object sender, EventArgs e)
		{
			try
			{
				ICategoryCrudView view = View.HelperFactory.RedirectHelper.CreateModalDialogView<ICategoryCrudView>(View);
				View.HelperFactory.RedirectHelper.ShowModalDialogView(view, View);
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Could not show the Category CRUD dialog", ex);
			}
		}

		protected void mnuFileExitClick(object sender, EventArgs e)
		{
			try
			{
				((IWinControl)View).Close();
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Could not close the app", ex);
			}
		}

	}
}