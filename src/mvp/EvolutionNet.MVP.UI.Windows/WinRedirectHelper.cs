using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinRedirectHelper : IRedirectHelper
	{
		private const string TypeNameSource = "I{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDestForm = "{0}Frm";
		private const string TypeNameDestDialog = "{0}Dlg";

		#region Thread-safe Singleton

		private WinRedirectHelper()
		{
		}

		public static WinRedirectHelper Instance
		{
			get
			{
				return Nested.instance;
			}
		}
	    
		class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly WinRedirectHelper instance = new WinRedirectHelper();
		}

		#endregion

		public void RedirectToView<T>(object senderView) where T : IControlView
		{
			RedirectToView<T>(senderView, null);
		}

		public void RedirectToView<T>(object senderView, IDictionary<string, string> args) where T : IControlView
		{
			Form frm = (Form) IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T), 
				TypeNameDestForm, "", senderView.GetType(), args == null ? null : args.Values);
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