using System;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebMessageHelper : BaseSingleton<WebMessageHelper>, IMessageHelper
	{
		private BaseMessageUC messageUC;
		public BaseMessageUC MessageUC
		{
			get { return messageUC; }
			set { messageUC = value; }
		}

		public void ShowMessage(string caption, string message)
		{
			messageUC.ShowMessage(caption, message);
		}

		public void ShowErrorMessage(string caption, string message)
		{
			ShowErrorMessage(caption, message, null);
		}

		public void ShowErrorMessage(string caption, string message, Exception exception)
		{
			messageUC.ShowErrorMessage(caption, message, exception);
		}
	}
}