using EvolutionNet.MVP.UI.Web;

namespace EvolutionNet.Sample.UI.Web.Base
{
	public class BaseSampleView : BaseUCView
	{
		protected override void OnLoad(System.EventArgs e)
		{
			if (Page != null && Page.Master != null && Page.Master.Master != null)
				((WebMessageHelper)HelperFactory.MessageHelper).MessageUC = ((_BaseMaster)Page.Master.Master).MessageUC;

			base.OnLoad(e);
		}

	}
}