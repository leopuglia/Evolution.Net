using System.Web.UI;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	public abstract class BaseMessageConfirmUC : UserControl, IWebControl
	{
		public abstract bool ShowMessageConfirm(string caption, string msg);
		public abstract MessageConfirmCancel ShowMessageConfirmCancel(string caption, string msg);
	}
}