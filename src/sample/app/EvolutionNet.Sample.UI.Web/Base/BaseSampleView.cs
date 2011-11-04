using System;
using EvolutionNet.MVP.UI.Web;

namespace EvolutionNet.Sample.UI.Web.Base
{
	public class BaseSampleView : BaseUCView
	{
		protected override void OnLoad(System.EventArgs e)
		{
			if (Page != null && Page.Master != null && Page.Master.Master != null)
			{
				var baseMaster = ((_BaseMaster) Page.Master.Master);

				((WebMessageHelper) HelperFactory.MessageHelper).MessageUC = baseMaster.MessageUC;

				baseMaster.ProgressUC.TaskID =
					((WebBackgroundWorkerHelper2) HelperFactory.GetBackgroundWorkerHelper()).TaskID = Guid.NewGuid();
//				((WebBackgroundWorkerHelper) HelperFactory.GetBackgroundWorkerHelper()).ProgressUC =
//					baseMaster.ProgressUC;
			}

			base.OnLoad(e);
		}

	}
}