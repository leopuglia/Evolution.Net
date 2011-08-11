using System;
using System.ComponentModel;
using System.Web.UI;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseUCView : UserControl, IControlView, IWebControl
	{
		#region Public Properties

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

		#endregion

		#region Public Event Definition

		[Category("Behavior"), Description("Event fired after all the controls are loaded.")]
		public event EventHandler AfterLoadComplete;

		#endregion

		#region Public Event Calling

		public void OnAfterLoadComplete(EventArgs e)
		{
			if (AfterLoadComplete != null)
				AfterLoadComplete(this, e);

			EvokeAfterLoadCompleteOnChild(Controls, e);
		}

		#endregion

		#region Local Methods

		protected void RegisterControlOnClientStartup(string clientVarName, string clientControlID)
		{
			ScriptManager.RegisterStartupScript(this, GetType(), clientVarName,
			                                    string.Format("var {0} = $get('{1}');\r\n", clientVarName, clientControlID), true);
		}

		protected void RegisterControlOnClientStartup(UpdatePanel panel, string clientVarName, string clientControlID)
		{
			ScriptManager.RegisterStartupScript(panel, panel.GetType(), clientVarName,
			                                    string.Format("var {0} = $get('{1}');\r\n", clientVarName, clientControlID), true);
		}

		protected void RegisterStartupScript(UpdatePanel panel, string key, string script)
		{
			ScriptManager.RegisterStartupScript(panel, panel.GetType(), key, script, true);
		}

		protected void RegisterStartupScript(string key, string script)
		{
			ScriptManager.RegisterStartupScript(this, GetType(), key, script, true);
		}

		protected void SetFocusJavascript(UpdatePanel updatePanelEdit, string modalPopupName, string clientID)
		{
			RegisterControlOnClientStartup(updatePanelEdit, "controlToFocus", clientID);
			RegisterStartupScript(updatePanelEdit, "FocusCategoryName", @"
				Sys.Application.add_load(modalSetup);

				function SetFocusOnControl()
				{
					controlToFocus.select();
				}
				function modalSetup()
				{
					var modalPopup = $find('" + modalPopupName + @"');
					modalPopup.add_shown(SetFocusOnControl);		 
				}");
		}

		#endregion

		#region Local Event Calling

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
