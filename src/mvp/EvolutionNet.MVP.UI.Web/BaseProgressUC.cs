using System;
using System.Web.UI;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public abstract class BaseProgressUC : UserControl, IWebControl
	{
		#region Local Attributes

//		private readonly DateTime timeIni = DateTime.Now;
//		private string timeStringFormat = "{1:00}:{2:00}";
//		private bool showMilliseconds;
//		private bool showHours;

//		private readonly Timer timer1;
//		private readonly Timer timer2;

		#endregion

		public abstract event EventHandler<EventArgs> CancelButtonClick;

		#region Public Abstract Properties

		public abstract string Text { get; set; }
		public abstract string Caption { get; set; }
		public abstract bool CancelEnabled { get; set; }

		#endregion

		#region Public Properties

		public abstract int Progress { get; set; }

//		public int StepSize { get; set; }

		public abstract bool ShowHours { get; set; }
/*
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
*/

		public abstract bool ShowMilliseconds { get; set; }
/*
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
*/

		#endregion

		#region Constructor

		protected BaseProgressUC()
		{
//			ShowHours = true;
//			ShowMilliseconds = true;

/*
			timer1 = new Timer();
			timer1.Interval = 200;
			timer1.Enabled = false;
			timer1.Tick += timer1_Tick;

			timer2 = new Timer();
			timer2.Enabled = true;
			timer2.Tick += timer2_Tick;
*/
		}

		#endregion

		#region Event Methods

/*
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (Progress == 100)
				Progress = 0;
			else if (Progress == 90)
				Progress = 99;
			else
				PerformStep();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			TimeSpan time = (DateTime.Now - timeIni);

//			timeStringFormat = "{0:00}:{1:00}:{2:00}.{3:000}";
			Text = string.Format(timeStringFormat, time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
		}
*/

		#endregion

		#region Public Abstract Methods

		public abstract void Show();
		public abstract void Close();
		public abstract void StepProgress(int value);
//		public abstract void PerformStep();
//		public abstract void PerformStep(int value);

		#endregion

	}
}