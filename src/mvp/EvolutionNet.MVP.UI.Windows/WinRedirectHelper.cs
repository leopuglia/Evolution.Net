using System;
using System.Windows.Forms;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinRedirectHelper : BaseSingleton<WinRedirectHelper>, IRedirectHelper
	{
		private const string TypeNameSource = "I{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDestForm = "{0}Frm";
		private const string TypeNameDestDialog = "{0}Dlg";

		public void RedirectToView<T>(object senderView, params object[] args) where T : IControlView
		{
			Form frm = (Form) IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T), 
				TypeNameDestForm, "", senderView.GetType(), args);
			frm.Show(((UserControl) senderView).ParentForm);
		}

		public T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView
		{
			Form frm = (Form)IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T),
				TypeNameDestDialog, "", senderView.GetType(), args);

			return WinControlHelper.FindControl<T>(frm);
		}

		public bool ShowModalDialogView(IControlView destView, object senderView)
		{
			if (destView as UserControl == null || (destView as UserControl).ParentForm == null)
				throw new ArgumentOutOfRangeException("destView", destView, "The destView should be a Control");

			switch ((destView as UserControl).ParentForm.ShowDialog(((UserControl)senderView).ParentForm))
			{
				case DialogResult.OK:
					return true;
				default:
					return false;
			}
		}
	}
}