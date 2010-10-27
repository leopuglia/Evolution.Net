using System.Web.UI;

namespace EvolutionNet.MVP.UI.Web
{
	public abstract class BaseMessageUC : UserControl
	{
	    public abstract void ShowMessage(string caption, string message);
	    public abstract void ShowErrorMessage(string caption, string message, string exceptionMessage);
	}
}