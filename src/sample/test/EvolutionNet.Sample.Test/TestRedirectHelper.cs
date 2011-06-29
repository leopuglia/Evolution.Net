using System;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.IoC;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.Sample.Test
{
	public class TestRedirectHelper : BaseSingleton<TestRedirectHelper>, IRedirectHelper
	{
//		private const string TypeNameSource = "{0}View";
//		private const string TypeNameSourceExclude = "View";
//		private const string TypeNameDest = "{0}.aspx";

		private const string TypeNameSource = "I{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDestForm = "{0}Frm";
		private const string TypeNameDestDialog = "{0}Dlg";

		public void RedirectToView<T>(object senderView, params object[] args) where T : IControlView
		{
			if (senderView is IWinControl)
			{
				Form frm = (Form) IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof (T),
				                                           TypeNameDestForm, "", senderView.GetType(), args);
				//frm.Show(((UserControl) senderView).ParentForm);
				frm.Visible = true;
			}
		}

		public T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView
		{
			if (senderView is IWinControl)
			{
				Form frm = (Form) IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof (T),
				                                           TypeNameDestDialog, "", senderView.GetType(), args);

				return WinControlHelper.FindControl<T>(frm);
			}

			throw new NotImplementedException();
		}

		public bool ShowModalDialogView(IControlView destView, object senderView)
		{
			if (senderView is IWinControl)
			{
				if (destView as UserControl == null || (destView as UserControl).ParentForm == null)
					throw new ArgumentOutOfRangeException("destView", destView, "The destView should be a Control");

				return true;
			}

			throw new NotImplementedException();
		}
	}
}