using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseMessageUC : UserControl
	{
		protected Label BaseLabelCaption;
		protected Label BaseLabelMessage;
		protected UpdatePanel BaseUpdatePanel;
		protected Panel BasePanel;

		public virtual void ShowMessage(string caption, string message)
		{
			BaseLabelCaption.Text = caption;
			BaseLabelMessage.Text = message;

			ScriptManager current = ScriptManager.GetCurrent(Page);
			if (current != null && current.IsInAsyncPostBack)
				BaseUpdatePanel.Update();
			else
				Show();
		}

		public virtual void ShowErrorMessage(string caption, string message, string exceptionMessage)
		{
			BaseLabelCaption.Text = caption;
            BaseLabelMessage.Text = string.Format("<b>{0}</b><br/>Exception: {1}", message, exceptionMessage);

			ScriptManager current = ScriptManager.GetCurrent(Page);
			if (current != null && current.IsInAsyncPostBack)
				BaseUpdatePanel.Update();
			else
				Show();
		}

		protected virtual void Show()
		{
		}

	}
}