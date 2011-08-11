using System;
using System.Web.UI;
using EvolutionNet.MVP.UI.Web;
using log4net;

namespace EvolutionNet.Sample.UI.Web.Base
{
	public partial class MessageUC : BaseMessageUC
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(MessageUC));

        public override void ShowMessage(string caption, string message)
        {
            LabelCaption.Text = caption;
            LabelMessage.Text = message;

            ScriptManager current = ScriptManager.GetCurrent(Page);
            if (current != null && current.IsInAsyncPostBack)
                UpdatePanelMessages.Update();
            else
                AnimationExtender2.Enabled = true;
        }

        public override void ShowErrorMessage(string caption, string message, Exception exception)
        {
            LabelCaption.Text = caption;

			var pageUrl = string.Format("Página: {0}\r\n", Request.RawUrl);
			var refererUrl = Request.UrlReferrer == null
			                 	? ""
			                 	: string.Format("Referer: {0}\r\n", 
									Request.UrlReferrer.AbsoluteUri.StartsWith("http://www.villadaspedras.com/") 
									? Request.UrlReferrer.PathAndQuery
									: Request.UrlReferrer.AbsoluteUri);
#if DEBUG
			LabelMessage.Text = string.Format(
				"<b>{0}</b><br/>{1}<br />{2}Exception: {3}", 
				message, 
				pageUrl,
				refererUrl == "" ? "" : refererUrl + "<br>",
				exception);
#else
			LabelMessage.Text = message;
#endif
			if (log.IsErrorEnabled)
				log.Error(pageUrl + refererUrl + message, exception);

            ScriptManager current = ScriptManager.GetCurrent(Page);
            if (current != null && current.IsInAsyncPostBack)
                UpdatePanelMessages.Update();
            else
                AnimationExtender2.Enabled = true;
        }
	}
}