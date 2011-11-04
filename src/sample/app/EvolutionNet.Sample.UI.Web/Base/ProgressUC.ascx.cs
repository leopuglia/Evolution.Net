using System;
using System.Web.UI;
using EvolutionNet.MVP.UI.Web;

namespace EvolutionNet.Sample.UI.Web.Base
{
	public partial class ProgressUC : BaseProgressUC, ICallbackEventHandler
	{
		#region Public Properties

		public override Guid TaskID
		{
			get { return ViewState["TaskID"] != null ? (Guid) ViewState["TaskID"] : Guid.Empty; }
			set { ViewState["TaskID"] = value; }
		}

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
			get { return TimeCounter1.ShowHours; }
			set { TimeCounter1.ShowHours = value; }
		}

		public override bool ShowMilliseconds
		{
			get { return TimeCounter1.ShowMilliseconds; }
			set { TimeCounter1.ShowMilliseconds = value; }
		}

/*
		public bool TimerEnabled
		{
			get { return Timer1.Enabled; }
			set { Timer1.Enabled = value; }
		}
*/

		#endregion

		public override event EventHandler<EventArgs> CancelButtonClick;

		#region Event Methods

		protected void Page_Load(object sender, EventArgs e)
		{
			ClientScriptManager cm = Page.ClientScript;
			String cbReference = cm.GetCallbackEventReference(this, "arg",
				"ReceiveServerData2", "");
			String callbackScript = "function CallServer2(arg, context) {" +
				cbReference + "; }";
			cm.RegisterClientScriptBlock(this.GetType(),
				"CallServer2", callbackScript, true);
//			if (!IsPostBack)
//			{
				//RegisterControlOnClientScriptBlock("progressBar", ProgressBar1.ClientID);

				//Page.ClientScript.RegisterClientScriptBlock(GetType(), "progressBarName", 
				Page.ClientScript.RegisterStartupScript(GetType(), "progressBarName", 
					string.Format("var progressBarName = '{0}';\r\n", 
								  ProgressBar1.ClientID),
					true);
//				RegisterControlOnClientStartup("progressBar", ProgressBar1.ClientID);
				RegisterStartupScript(UpdatePanelProgress, "timeCounterStart", @"
					Sys.Application.add_load(startCounter);

					function doStartCounter() {
						var timeCounter = $find('" + TimeCounter1.ClientID + @"');
						timeCounter.startCount(new Date());
					}
					function startCounter() {
						var modalPopup = $find('" + ModalPopupProgress.BehaviorID + @"');
						modalPopup.add_shown(doStartCounter);
					}
					");
//			}
		}

		protected void BtnCancel_Click(object sender, EventArgs e)
		{
			if (CancelButtonClick != null)
				CancelButtonClick(this, e);
		}

		protected void Timer1_Tick(object sender, EventArgs e)
		{
			Progress = (int)Cache[TaskID.ToString()];
//			Progress = Cache[TaskID.ToString()] != null ? (int)Cache[TaskID.ToString()] : 0;
		}

		#endregion

		#region Public Methods

		public override void Show()
		{
/*
			ScriptManager.RegisterStartupScript(UpdatePanelProgress, GetType(), "teste", 
				string.Format("$find('{0}').startCount(new Date());", TimeCounter1.ClientID),
				true);
*/
			ModalPopupProgress.Show();
//			Timer1.Enabled = true;
		}

		public override void Close()
		{
//			Timer1.Enabled = false;
			ModalPopupProgress.Hide();
		}

		public override void StepProgress(int value)
		{
			ProgressBar1.StepProgress(value);
		}

		#endregion

		public void RaiseCallbackEvent(string eventArgument)
		{
		}

		public string GetCallbackResult()
		{
//			Request.Form["TxtSlowWorkTime"] = "10";
			//this.BtnSlowWork.Text = "Teste";
//			return "Teste";
			return Cache[TaskID.ToString()] != null ? Cache[TaskID.ToString()].ToString() : "0";
		}

		protected void RegisterStartupScript(UpdatePanel panel, string key, string script)
		{
			ScriptManager.RegisterStartupScript(panel, panel.GetType(), key, script, true);
		}

		protected void RegisterControlOnClientScriptBlock(string clientVarName, string clientControlID)
		{
			ScriptManager.RegisterClientScriptBlock(this, GetType(), clientVarName,
													string.Format("var {0} = $find('{1}');\r\n", clientVarName, clientControlID), true);
		}

		protected void RegisterControlOnClientStartup(string clientVarName, string clientControlID)
		{
			ScriptManager.RegisterStartupScript(this, GetType(), clientVarName,
												string.Format("var {0} = $find('{1}');\r\n", clientVarName, clientControlID), true);
		}

		protected void RegisterControlOnClientStartup(UpdatePanel panel, string clientVarName, string clientControlID)
		{
			ScriptManager.RegisterStartupScript(panel, panel.GetType(), clientVarName,
												string.Format("var {0} = $find('{1}');\r\n", clientVarName, clientControlID), true);
		}

		protected void Timer1_Tick1(object sender, EventArgs e)
		{
//			ProgressBar1.StepProgress(10);
			if (Cache[TaskID.ToString()] != null)
				ProgressBar1.Progress = (int) Cache[TaskID.ToString()];
		}

//		protected void RegisterClientScriptBlock(UpdatePanel panel, string key, string script)
//		{
//			ScriptManager.RegisterClientScriptBlock(panel, panel.GetType(), key, script, true);
//		}

/*
		private string GetRefreshScript()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("var timerID;");

			sb.AppendLine("function ShowProgress() {");
			sb.AppendLine(Page.ClientScript.GetCallbackEventReference(this, "taskID", "UpdateStatus", "null", true));
			sb.AppendFormat("  timerID = " + "   window.setTimeout(\"ShowProgress()\", {0});", RefreshRate * 1000);
			sb.AppendLine("}");
			sb.AppendLine(GetUpdateStatus());
			sb.AppendLine("function StopProgress() {");
			sb.AppendFormat("  var label = " * " document.getElementById(‘{0}_Status’);", this.ID);
			sb.AppendLine();
			sb.AppendLine("  label.innerHTML = ‘‘;");
			sb.AppendLine("  window.clearTimeout(timerID);");
			sb.AppendLine("}");

			return sb.ToString();
		}

		private string GetUpdateStatus()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("function UpdateStatus(response, context) {");
			sb.AppendFormat("  var label = " + " document.getElementById(‘{0}_Status’);", this.ID);
			sb.AppendLine();
			sb.AppendLine("  label.innerHTML = response;");
			sb.AppendLine("}");
			return sb.ToString();
		}


		private string taskID;
		public void RaiseCallbackEvent(string argument)
		{
			taskID = argument;
		}

		public string GetCallbackResult()
		{
			string status = string.Empty;
			status = TaskHelpers.GetStatus(taskID);
			return status;
		}
*/

	}

}