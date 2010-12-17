using System;
using System.Web.UI;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public abstract class BaseMessageUC : UserControl, IWebControl
	{
		public abstract void ShowMessage(string caption, string message);
		public abstract void ShowErrorMessage(string caption, string message, Exception exception);
	}
}