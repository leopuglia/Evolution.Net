using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvolutionNet.MVP.UI.Web;

namespace EvolutionNet.Sample.UI.Web.Base
{
	public partial class ProgressUC : BaseProgressUC
	{
		private string text;

		private string caption;

		private bool cancelEnabled;

		private int progress;

		private bool showHours;

		private bool showMilliseconds;

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public override event EventHandler<EventArgs> CancelButtonClick;

		public override string Text
		{
			get { return LblText.Text; }
			set { LblText.Text = value; }
		}

		public override string Caption
		{
			get { return LblCaption.Text; }
			set { LblCaption.Text = value; }
		}

		public override bool CancelEnabled
		{
			get { return BtnCancel.Enabled; }
			set { BtnCancel.Enabled = value; }
		}

		public override int Progress
		{
			get { return ProgressBar1.Progress; }
			set { ProgressBar1.Progress = value; }
		}

		public override bool ShowHours
		{
			get { return showHours; }
			set { showHours = value; }
		}

		public override bool ShowMilliseconds
		{
			get { return showMilliseconds; }
			set { showMilliseconds = value; }
		}

		public override void Show()
		{
			throw new NotImplementedException();
		}

		public override void Close()
		{
			throw new NotImplementedException();
		}

		public override void StepProgress(int value)
		{
			throw new NotImplementedException();
		}

		protected void BtnCancel_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}