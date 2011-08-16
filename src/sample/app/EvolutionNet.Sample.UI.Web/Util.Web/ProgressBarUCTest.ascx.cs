using System;
using EvolutionNet.Sample.UI.Web.Base;

namespace EvolutionNet.Sample.UI.Web.Util.Web
{
	public partial class ProgressBarUCTest : BaseSampleView
	{
		public bool isProgressRunning
		{
			get { return ViewState["isProgressRunning"] != null ? (bool) ViewState["isProgressRunning"] : false; }
			set { ViewState["isProgressRunning"] = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			ProgressBar1.AutoProgress = false;
//			if (!isProgressRunning)
				ProgressBar1.StepProgress(10);
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			ProgressBar1.AutoProgress = false;
//			if (!isProgressRunning)
				ProgressBar1.StepProgress(-10);
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
//			if (!isProgressRunning)
//			{
				ProgressBar1.AutoProgress = true;
//				isProgressRunning = true;
//			}
		}

		protected void Button4_Click(object sender, EventArgs e)
		{
//			if (isProgressRunning)
//			{
				ProgressBar1.AutoProgress = false;
//				isProgressRunning = false;
//			}
		}

	}
}