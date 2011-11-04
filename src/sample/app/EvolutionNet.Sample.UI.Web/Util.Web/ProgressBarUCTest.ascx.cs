using System;
using EvolutionNet.Sample.UI.Web.Base;

namespace EvolutionNet.Sample.UI.Web.Util.Web
{
	public partial class ProgressBarUCTest : BaseSampleView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			ProgressBar1.StepProgress(10);
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			ProgressBar1.StepProgress(-10);
		}

	}
}