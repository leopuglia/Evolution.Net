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
		private const string TypeNameDest = "{0}Frm";

		public void RedirectToView<T>(object senderView, params object[] args)
		{
			Form frm = (Form) IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T), 
				TypeNameDest, "", senderView.GetType(), args);
			frm.Show(((UserControl) senderView).ParentForm);
		}

		public bool RedirectToViewModal<T>(object senderView, params object[] args)
		{
			Form frm = (Form)IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T),
				TypeNameDest, "", senderView.GetType(), args);
			switch (frm.ShowDialog(((UserControl)senderView).ParentForm))
			{
				case DialogResult.OK:
					return true;
				default:
					return false;
			}
		}
	}
}