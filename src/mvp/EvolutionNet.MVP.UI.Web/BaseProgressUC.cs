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

		public abstract Guid TaskID { get; set; }
		public abstract string Text { get; set; }
		public abstract string Caption { get; set; }
		public abstract bool CancelEnabled { get; set; }
		public abstract int Progress { get; set; }
		public abstract bool ShowHours { get; set; }
		public abstract bool ShowMilliseconds { get; set; }

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