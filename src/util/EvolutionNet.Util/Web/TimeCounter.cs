using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.Util.Web
{
	public class TimeCounter : Label, IScriptControl
	{
		#region Local Attributes

		private ScriptManager scriptManager;
//		private readonly DateTime initialTime;

		private int interval
		{
			get { return ShowMilliseconds ? 1 : 100; }
		}

		private string timeStringFormat
		{
//			get { return ViewState["timeStringFormat"] as string ?? "{1:00}:{2:00}"; }
//			set { ViewState["timeStringFormat"] = value; }
			get
			{
				StringBuilder str = new StringBuilder();

				if (ShowHours)
					str.Append("{0:00}:");

				str.Append("{1:00}:{2:00}");

				if (ShowMilliseconds)
					str.Append(".{3:000}");

				return str.ToString();
			}
		}

		#endregion

		#region Public Properties

		// ReSharper disable UnusedMember.Global
		[Description("Defines if show hours"), Category("Behavior")]
		public virtual bool ShowHours
		{
			get { return ViewState["ShowHours"] != null ? (bool)ViewState["ShowHours"] : false; }
			set { ViewState["ShowHours"] = value; }
		}

		[Description("Defines if show milliseconds"), Category("Behavior")]
		public virtual bool ShowMilliseconds
		{
			get { return ViewState["ShowMilliseconds"] != null ? (bool)ViewState["ShowMilliseconds"] : false; }
			set { ViewState["ShowMilliseconds"] = value; }
		}

/*
		[Description("Defines the string format for exibition"), Category("Behavior")]
		public virtual string TimeStringFormat
		{
			get { return timeStringFormat; }
			set { timeStringFormat = value; }
		}
*/

		[Description("Defines if start counting on load"), Category("Behavior"), DefaultValue(true)]
		public virtual bool StartOnLoad
		{
			get { return ViewState["StartOnLoad"] != null ? (bool)ViewState["StartOnLoad"] : true; }
			set { ViewState["StartOnLoad"] = value; }
		}

		[Description("Button that starts the count"), Category("Behavior"), IDReferenceProperty(typeof(Button)), TypeConverter(typeof(AssociatedControlConverter/*ControlIDConverter*/))]
		public virtual string StartButtonID
		{
			get { return ViewState["StartButtonID"] as string ?? ""; }
			set { ViewState["StartButtonID"] = value; }
		}

		[Description("Defines if the button selected causes a postback"), Category("Behavior")]
		public virtual bool StartButtonCausesPostBack
		{
			get { return ViewState["StartButtonDoPostBack"] != null ? (bool)ViewState["StartButtonDoPostBack"] : false; }
			set { ViewState["StartButtonDoPostBack"] = value; }
		}

		[Description("Defines if the start button resets the counter"), Category("Behavior")]
		public virtual bool StartButtonResetCounter
		{
			get { return ViewState["StartButtonResetCounter"] != null ? (bool)ViewState["StartButtonResetCounter"] : false; }
			set { ViewState["StartButtonResetCounter"] = value; }
		}

		[Description("Button that stops the count"), Category("Behavior"), IDReferenceProperty(typeof(Button)), TypeConverter(typeof(AssociatedControlConverter/*ControlIDConverter*/))]
		public virtual string StopButtonID
		{
			get { return ViewState["ButtonStopID"] as string ?? ""; }
			set { ViewState["ButtonStopID"] = value; }
		}

		[Description("Define if the button selected causes a postback"), Category("Behavior")]
		public virtual bool StopButtonCausesPostBack
		{
			get { return ViewState["StopButtonDoPostBack"] != null ? (bool)ViewState["StopButtonDoPostBack"] : false; }
			set { ViewState["StopButtonDoPostBack"] = value; }
		}
		// ReSharper restore UnusedMember.Global

		#endregion

		public TimeCounter()
		{
//			initialTime = DateTime.Now;
		}

		#region Protected Methods

/*
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			if (string.IsNullOrEmpty(CssClass))
			{
				var style = new Style
								{
									BorderStyle = BorderStyle.Solid,
									BorderWidth = new Unit("1px"),
									BorderColor = Color.LightGray,
									Width = new Unit("200px"),
									Height = new Unit("20px"),
								};
				MergeStyle(style);

				if (Font.Size.IsEmpty)
					Font.Size = new FontUnit(new Unit("13px"));
				if (string.IsNullOrEmpty(Font.Name))
					Font.Name = "Arial";
			}

			base.AddAttributesToRender(writer);
		}
*/

		protected override void RenderContents(HtmlTextWriter writer)
		{
			//base.RenderContents(writer);

			var timeSpan = DateTime.Now - DateTime.Now;
			writer.Write(string.Format(timeStringFormat, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds));

/*
			writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID + IdSeparator + "Progress");
			if (string.IsNullOrEmpty(CssClassBar))
			{
				writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor,
										 ProgressBarColor == Color.Empty
										 	? "#00c"
											: new WebColorConverter().ConvertToString(ProgressBarColor));
			}
			else
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClassBar);
			}
			writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "100%");
			if (! DesignMode)
				writer.AddStyleAttribute(HtmlTextWriterStyle.Width, Progress + "%");
			else
				writer.AddStyleAttribute(HtmlTextWriterStyle.Width, 66 + "%");
			writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "relative");
			writer.AddStyleAttribute(HtmlTextWriterStyle.ZIndex, "1");
			if (DesignMode)
				writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "right");
			writer.RenderBeginTag(HtmlTextWriterTag.Div);

			if (DesignMode)
			{
				writer.Write(string.Format(PercentualFormat, 66));
			}

			writer.RenderEndTag();

			base.RenderContents(writer);
*/
		}

/*
		protected virtual Button GetButton()
		{
			var button = FindControl(TextBoxControlId) as TextBox;
			if (tb == null)
				throw new HttpException(
					string.Format("The TextBoxCounter control with ID '{0}' could not find a TextBox control with the ID '{1}'.", ID,
								  TextBoxControlId));

			return tb;
		}
*/

		protected override void OnPreRender(EventArgs e)
		{
			if (!DesignMode)
			{
				scriptManager = ScriptManager.GetCurrent(Page);
				if (scriptManager == null)
					throw new HttpException("A ScriptManager control must exist on the current page");

				// Register the current control script
				scriptManager.RegisterScriptControl(this);

				// Set client click event for StartButton, informing if it does postback
				if (!string.IsNullOrEmpty(StartButtonID))
				{
					var buttonStart = FindControl(StartButtonID) as Button;
					if (buttonStart == null)
						throw new HttpException(
							string.Format("The TimeCounter control with ID '{0}' could not find a Button with the ID '{1}'.",
										  ID, StartButtonID));

					// Aqui tem que usar "=" ao invés de "+="
					if (! StartButtonResetCounter)
					{
						buttonStart.Attributes["onclick"] =
//							string.Format("startTimeCounter('{0}', '{1}', '{2}');{3}",
//										  ClientID, timeStringFormat, interval,
//										  !StartButtonCausesPostBack ? "return false;" : "");
							string.Format("$find('{0}').startCount();{1}",
										  ClientID,
										  !StartButtonCausesPostBack ? "return false;" : "");
					}
					else
					{
						buttonStart.Attributes["onclick"] =
//							string.Format("startTimeCounter('{0}', '{1}', '{2}', new Date());{3}",
//										  ClientID, timeStringFormat, interval, //Dat5eTime.Now.ToString("r"),
//										  !StartButtonCausesPostBack ? "return false;" : "");
							string.Format("$find('{0}').startCount(new Date());{1}",
										  ClientID,
										  !StartButtonCausesPostBack ? "return false;" : "");
					}
				}

				// Set client click event for StopButton, informing if it does postback
				if (!string.IsNullOrEmpty(StopButtonID))
				{
					var buttonStop = FindControl(StopButtonID) as Button;
					if (buttonStop == null)
						throw new HttpException(
							string.Format("The TimeCounter control with ID '{0}' could not find a Button with the ID '{1}'.",
							              ID, StopButtonID));

					// Aqui tem que usar "=" ao invés de "+="
					buttonStop.Attributes["onclick"] = 
//						string.Format("stopTimeCounter('{0}');{1}", ClientID, !StopButtonCausesPostBack ? "return false;" : "");
						string.Format("$find('{0}').stopCount();{1}", ClientID, !StopButtonCausesPostBack ? "return false;" : "");
				}
			}

			base.OnPreRender(e);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (!DesignMode)
			{
				scriptManager.RegisterScriptDescriptors(this);
			}

			base.Render(writer);
		}

		#endregion

		#region Public Virtual Methods (IScriptControl)

		public virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			ScriptBehaviorDescriptor scriptDescriptor = 
				new ScriptBehaviorDescriptor("EvolutionNet.TimeCounter", ClientID);

			scriptDescriptor.AddProperty("id", ClientID);
			scriptDescriptor.AddProperty("interval", interval);
			scriptDescriptor.AddProperty("timeStringFormat", timeStringFormat);

			// Aqui está o pulo do gato, descobrir se está dentro de um update panel, é postback ou não
			scriptDescriptor.AddProperty("startCountOnInit", 
				StartOnLoad && (!WebControlHelper.IsInsideUpdatePanel(this) || !Page.IsPostBack));

			return new[] {scriptDescriptor};
		}

		public virtual IEnumerable<ScriptReference> GetScriptReferences()
		{
			return new[]
			{
				GetScriptReference("EvolutionNet.Util.Web.common.js"), 
				GetScriptReference("EvolutionNet.Util.Web.timecounter.js")
			};
		}

		#endregion

		private ScriptReference GetScriptReference(string scriptFile)
		{
			return new ScriptReference(GetScriptResourceUrl(scriptFile));
		}

		private string GetScriptResourceUrl(string scriptFile)
		{
			if (GetType().Assembly.GetManifestResourceInfo(scriptFile) == null)
				throw new Exception(string.Format("The specified resource {0} doesn't exist", scriptFile));

			return ResolveClientUrl(
				Page.ClientScript.GetWebResourceUrl(GetType(), scriptFile));
		}

	}
}