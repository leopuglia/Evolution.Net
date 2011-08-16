using System;
using System.Drawing;
using System.Windows.Forms;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class ProgressDlgFrm : Form
	{
		#region Local Attributes

		private readonly DateTime timeIni = DateTime.Now;
		private string timeStringFormat = "{1:00}:{2:00}";
		private bool showMilliseconds;
		private bool showHours;

		#endregion

		#region Public Properties

		public new string Text
		{
			get { return lblText.Text; }
			set { lblText.Text = value; }
		}

		public string Caption
		{
			get { return base.Text; }
			set { base.Text = value; }
		}

		public int Progress
		{
			get { return progressBar1.Value; }
			set { progressBar1.Value = value; }
		}

		public bool ShowHours
		{
			get { return showHours; }
			set
			{
				showHours = value;

				if (showMilliseconds)
				{
					timeStringFormat = "{0:00}:{1:00}:{2:00}.{3:000}";
					timer2.Interval = 1;
				}
				else
				{
					timeStringFormat = "{0:00}:{1:00}:{2:00}";
					timer2.Interval = 100;
				}
			}
		}

		public bool ShowMilliseconds
		{
			get { return showMilliseconds; }
			set
			{
				showMilliseconds = value;

				if (showHours)
				{
					timeStringFormat = "{0:00}:{1:00}:{2:00}.{3:000}";
				}
				else
				{
					timeStringFormat = "{1:00}:{2:00}.{3:000}";
				}

				timer2.Interval = 1;
			}
		}

		#endregion

		#region Constructor

		protected ProgressDlgFrm()
		{
			InitializeComponent();

//			ShowHours = true;
//			ShowMilliseconds = true;
			timer2.Enabled = true;
		}

		#endregion

		#region Event Methods

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (progressBar1.Value == 100)
				progressBar1.Value = 0;
			else if (progressBar1.Value == 90)
				progressBar1.Value = 99;
			else
				progressBar1.PerformStep();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			TimeSpan time = (DateTime.Now - timeIni);

//			timeStringFormat = "{0:00}:{1:00}:{2:00}.{3:000}";
			lblTime.Text = string.Format(timeStringFormat, time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
		}

		#endregion

		#region Public Methods

		public new void Hide()
		{
			Owner.Enabled = true;
			base.Hide();
		}

		public new void Close()
		{
			Owner.Enabled = true;
			base.Close();
		}

		public void SetAutomaticProgress()
		{
			timer1.Enabled = timer2.Enabled = true;
		}

		public void ProgressStep()
		{
			progressBar1.PerformStep();
		}

		public void ProgressIncrement(int value)
		{
			progressBar1.Increment(value);
		}

		public void StopTimeDisplay()
		{
			timer2.Enabled = false;
			timer2_Tick(this, new EventArgs());
		}

		#endregion

		#region Public Static Methods (Show)

		public static ProgressDlgFrm Show(Form owner)
		{
			return Show(owner, null);
		}
		
		public static ProgressDlgFrm Show(Form owner, string text)
		{
			return Show(owner, null, null);
		}

		public static ProgressDlgFrm Show(Form owner, string caption, string text)
		{
			return Show(owner, caption, text, ProgressDlgButtons.Cancel);
		}
		
		public static ProgressDlgFrm Show(
			Form owner, string caption, string text, ProgressDlgButtons buttons)
		{
			ProgressDlgFrm frm = new ProgressDlgFrm();

			if (text == null)
				text = MVPCommonMessages.ProgressDlgFrm_Msg001;

			if (caption == null)
				caption = MVPCommonMessages.ProgressDlgFrm_Caption001;
			
			frm.Text = text;
			frm.Caption = caption;
			
			switch(buttons)
			{
				case ProgressDlgButtons.Cancel:
					frm.btnOK.Visible = false;
					break;
				case ProgressDlgButtons.Ok:
					frm.btnCancelar.Visible = false;
					frm.btnOK.Location = new Point(frm.btnCancelar.Location.X, frm.btnCancelar.Location.Y);
					break;
			}

			frm.Owner = owner;
			owner.Enabled = false;

			frm.Show((IWin32Window)owner);

			return frm;
		}

		#endregion

	}
	
	public enum ProgressDlgButtons
	{
		Cancel,
		OkCancel,
		Ok
	}
}