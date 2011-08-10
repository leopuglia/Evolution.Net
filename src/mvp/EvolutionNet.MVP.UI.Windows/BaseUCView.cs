using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class BaseUCView : UserControl, IWinControl, IControlView
	{
		#region Local Attributes

		private readonly bool isVSDesigner = true;

		protected bool IsVSDesigner
		{
			get { return isVSDesigner; }
		}

		#endregion

		#region Event Definition

		[Category("Behavior"), Description("Event fired after all the form and controls are loaded.")]
		public event EventHandler AfterLoadComplete;

		#endregion

		#region Public Properties

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

		#endregion

		#region Constructor

		protected BaseUCView()
		{
			isVSDesigner = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

			InitializeComponent();

			WinMessageHelper.Instance.Initialize(this);
		}

		#endregion

		#region Public Methods

		public void Close()
		{
			if (ParentForm != null) ParentForm.Close();
		}

		public void OnAfterLoadComplete(EventArgs e)
		{
			if (AfterLoadComplete != null)
				AfterLoadComplete(this, e);

			EvokeAfterLoadCompleteOnChild(Controls, e);
		}

		#endregion

		#region Private Methods

		private void EvokeAfterLoadCompleteOnChild(ControlCollection controls, EventArgs e)
		{
			foreach (Control control in controls)
			{
				var view = control as BaseUCView;
				if (view != null && view.AfterLoadComplete != null)
					view.AfterLoadComplete(view, e);

				if (control.Controls.Count != 0)
					EvokeAfterLoadCompleteOnChild(control.Controls, e);
			}
		}

		#endregion

	}
}
