using EvolutionNet.MVP.View;
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

        public void ShowErrorMessage(string caption, string message, string exceptionMessage)
        {
            messageUC.ShowErrorMessage(caption, message, exceptionMessage);
        }
    }
}