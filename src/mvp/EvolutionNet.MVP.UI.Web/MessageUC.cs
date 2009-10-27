using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseMessageUC : UserControl
	{
		protected Label BaseLabel;
		protected UpdatePanel BaseUpdatePanel;
		protected Panel BasePanel;

		public virtual void ShowMessage(string message)
		{
			ShowMessage(message, false);
		}

		public virtual void ShowMessage(string message, bool isPostBack)
		{
			BaseLabel.Text = message;
			
			if (!isPostBack)
				BaseUpdatePanel.Update();
			else
				BasePanel.Style["display"] = "block";
		}

		public virtual void ShowErrorMessage(string message, Exception ex)
		{
			ShowErrorMessage(message, ex, false);
		}

		public virtual void ShowErrorMessage(string message, Exception ex, bool isPostBack)
		{
			BaseLabel.Text = string.Format("<b>{0}</b><br />{1}", message, ex.Message);

			if (!isPostBack)
				BaseUpdatePanel.Update();
			else
				BasePanel.Style["display"] = "block";

#if DEBUG
			throw ex;
#endif
		}

	}
}