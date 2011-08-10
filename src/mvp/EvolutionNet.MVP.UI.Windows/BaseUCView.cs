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
		public event EventHandler LoadComplete;

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

		public void OnLoadComplete(EventArgs e)
		{
			if (LoadComplete != null)
				LoadComplete(this, e);

			EvokeLoadCompleteOnChild(Controls, e);
		}

		#endregion

		#region Private Methods

		private void EvokeLoadCompleteOnChild(ControlCollection controls, EventArgs e)
		{
			foreach (Control control in controls)
			{
				var view = control as BaseUCView;
				if (view != null && view.LoadComplete != null)
					view.LoadComplete(view, e);

				if (control.Controls.Count != 0)
					EvokeLoadCompleteOnChild(control.Controls, e);
			}
		}

		#endregion

	}
}
