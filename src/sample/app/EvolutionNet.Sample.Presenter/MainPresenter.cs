using System;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;
using log4net.Config;

namespace EvolutionNet.Sample.Presenter
{
	public class MainPresenter : BasePresenter<IMainView, IMainContract>
	{
		public MainPresenter(IMainView view) : base(view)
		{
			if (view is IWinControl)
			{
				var mnuFile = view.AddMenuItem("&File", "mnuFile");
				view.AddMenuItem("&Categories", "mnuFileCategories", mnuFile, mnuFileCategoriesClick);
				view.AddMenuItem("-", "mnuFileSeparator", mnuFile);
				view.AddMenuItem("E&xit", "mnuFileExit", mnuFile, mnuFileExitClick);
			}
		}

		private void mnuFileExitClick(object sender, EventArgs eventArgs)
		{
			((IWinControl)View).Close();
		}

		private void mnuFileCategoriesClick(object sender, EventArgs eventArgs)
		{
			View.RedirectHelper.RedirectToViewModal<ICategoriesCrudView>(View);
		}
	}
}