using System;
using System.Text;

namespace EvolutionNet.Sample.UI.Web
{
	public partial class ProgressBarTest3 : System.Web.UI.Page
	{
		private int width = 200;
		private int progress
		{
			get { return ViewState["progress"] != null ? (int) ViewState["progress"] : 0; }
			set { ViewState["progress"] = value; }
		}

		private string percentText = "{0}%";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				SetProgress(0);
			}
		}

		public void StepProgress(int step)
		{
			SetProgress(progress + step);
		}

		public void SetProgress(int current)
		{
			progress = current;
			StringBuilder s = new StringBuilder();
			s.AppendLine("<div id=\"box\">\r\n");
			s.AppendFormat("	<div id=\"display\">{0}</div>\r\n", string.Format(percentText, current));
			s.AppendFormat("	<div id=\"perc\" style=\"width: {0}%;\"></div>\r\n", current);
			s.AppendLine("</div>\r\n");
			LblProgress.Text = s.ToString();
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			StepProgress(10);
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			StepProgress(-10);
		}
	}
}