using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.Util.Web
{
	public class ProgressBar : WebControl, IScriptControl
	{
		#region Local Attributes

		private ScriptManager scriptManager;
/*
		private int count
		{
			get { return ViewState["count"] != null ? (int)ViewState["count"] : 0; }
			set { ViewState["count"] = value; }
		}
*/

		#endregion

		#region Public Properties

		// ReSharper disable UnusedMember.Global
		[Description("The color of the progress bar"), Category("Appearance")]
		public virtual Color ProgressBarColor
		{
			get { return ViewState["ProgressBarColor"] != null ? (Color)ViewState["ProgressBarColor"] : Color.Empty; }
			set { ViewState["ProgressBarColor"] = value; }
		}

		[Description("Image URL for the progress bar"), Category("Appearance")]
		public virtual string ProgressBarImageUrl
		{
			get { return ViewState["ProgressBarImageUrl"] != null ? (string) ViewState["ProgressBarImageUrl"] : ""; }
			set { ViewState["ProgressBarImageUrl"] = value; }
		}

		[Description("CSS Class name applied to the internal bar div"), Category("Appearance"), DefaultValue("")]
		public virtual string CssClassBar
		{
			get { return ViewState["CssClassBar"] != null ? (string)ViewState["CssClassBar"] : ""; }
			set { ViewState["CssClassBar"] = value; }
		}

		[Description("CSS Class name applied to the internal percentual div"), Category("Appearance"), DefaultValue("")]
		public virtual string CssClassPercentual
		{
			get { return ViewState["CssClassPercentual"] != null ? (string)ViewState["CssClassPercentual"] : ""; }
			set { ViewState["CssClassPercentual"] = value; }
		}

		[Description("Current progress percentual format string"), Category("Behavior"), DefaultValue("{0}%")]
		public virtual string PercentualFormat
		{
			get { return ViewState["PercentualFormat"] != null ? (string)ViewState["PercentualFormat"] : "{0}%"; }
			set { ViewState["PercentualFormat"] = value; }
		}

		[Description("Show current progress percentual text"), Category("Behavior"), DefaultValue(true)]
		public virtual bool ShowPercentualText
		{
			get { return ViewState["ShowPercentualText"] != null ? (bool)ViewState["ShowPercentualText"] : true; }
			set { ViewState["ShowPercentualText"] = value; }
		}

		[Description("Current progress"), Category("Behavior"), DefaultValue(0)]
		public int Progress
		{
			get { return ViewState["Progress"] != null ? (int)ViewState["Progress"] : 0; }
			set
			{
				if (value < 0 || value > 100)
					throw new ArgumentOutOfRangeException("value", value, "The progress value should be between 0 and 100");
				ViewState["Progress"] = value;
			}
		}

		[Description("Define if auto progress is enabled on load"), Category("Behavior"), DefaultValue(false)]
		public virtual bool AutoProgress
		{
			get { return ViewState["AutoProgress"] != null ? (bool) ViewState["AutoProgress"] : false; }
			set
			{
				ViewState["AutoProgress"] = value;
/*
				if (!DesignMode && Page != null && Page.IsPostBack && ViewState["AutoProgress"] != null && ((bool)ViewState["AutoProgress"]) != value)
				{
					var control = WebControlHelper.FindUpdatePanelOrPage(this);
					if (!value)
					{
						ScriptManager.RegisterStartupScript(
							control,
							control.GetType(),
							ClientID + "_stopAutoProgress",
//							string.Format("Sys.Application.add_load(function() {{\r\n\t$find('{0}').stopAutoProgress();\r\n}});\r\n", ClientID),
							string.Format("Sys.Application.add_load(function() {{\r\n\t$find('{0}').stopAutoProgress({1});\r\n}});\r\n",
							              ClientID,
							              count),
							true);
						count++;
					}
				}
*/
			}
		}
		// ReSharper restore UnusedMember.Global

		#endregion

		#region Constructors

		public ProgressBar() : base(HtmlTextWriterTag.Div)
		{
		}

		#endregion

		#region Public Methods

		public void StepProgress(int step)
		{
			Progress += step;
		}

		#endregion

		#region Protected Overriden Methods (WebControl)

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

		protected override void RenderContents(HtmlTextWriter writer)
		{
			// Adding div with the progress text
			if (!DesignMode && ShowPercentualText)
			{
//				writer.Indent++;

				writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClassPercentual);
				writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "table");
				writer.AddStyleAttribute("#position", "relative");
				writer.AddStyleAttribute(HtmlTextWriterStyle.Overflow, "hidden");
				writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");

				writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "100%");
				writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
				writer.AddStyleAttribute(HtmlTextWriterStyle.Position, "relative");
				writer.AddStyleAttribute("float", "left");
				writer.AddStyleAttribute(HtmlTextWriterStyle.ZIndex, "2");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);

//				writer.Indent++;
				writer.AddAttribute(HtmlTextWriterAttribute.Style,
									" #position: absolute; #top: 50%;display: table-cell; vertical-align: middle;");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);

//				writer.Indent++;
				writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID + IdSeparator + "Percentual");
				writer.AddAttribute(HtmlTextWriterAttribute.Style, " #position: relative; #top: -50%");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
				writer.Write(string.Format(PercentualFormat, Progress));

				writer.RenderEndTag();
//				writer.Indent--;

				writer.RenderEndTag();
//				writer.Indent--;

				writer.RenderEndTag();
//				writer.Indent--;
			}

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

//			writer.Indent--;

			base.RenderContents(writer);
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (!DesignMode)
			{
				scriptManager = ScriptManager.GetCurrent(Page);

				if (scriptManager == null)
					throw new HttpException("A ScriptManager control must exist on the current page");

				scriptManager.RegisterScriptControl(this);
			}

			base.OnPreRender(e);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (!DesignMode)
			{
				scriptManager.RegisterScriptDescriptors(this);

/*
				var control = FindUpdatePanel(this);
				if (AutoProgress)
				{
					ScriptManager.RegisterStartupScript(
						control,
						control.GetType(),
						ClientID + "_setAutoProgress",
						string.Format("Sys.Application.add_init(function() {{\r\n\t$find('{0}').setAutoProgress();\r\n}});\r\n", ClientID),
//						string.Format("$find('{0}').setAutoProgress();", ClientID),
						true);
				}
				else
				{
					ScriptManager.RegisterStartupScript(
						control,
						control.GetType(),
						ClientID + "_stopAutoProgress",
						//string.Format("Sys.Application.add_init(function() {{\r\n\t$find('{0}').stopAutoProgress();\r\n}});\r\n", ClientID),
						string.Format("$find('{0}').stopAutoProgress();", ClientID),
						true);
				}
*/
			}

			base.Render(writer);

		}

		#endregion

		#region Public Virtual Methods (IScriptControl

		public virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			ScriptBehaviorDescriptor scriptDescriptor = 
				new ScriptBehaviorDescriptor("EvolutionNet.ProgressBar", ClientID);

			scriptDescriptor.AddProperty("id", ClientID);

			// Aqui está o pulo do gato, descobrir se não está dentro de um update panel ou, se estiver, se não é postback
			scriptDescriptor.AddProperty("startOnInit",
				AutoProgress && (!WebControlHelper.IsInsideUpdatePanel(this) || !Page.IsPostBack));

			scriptDescriptor.AddProperty("percentualFormat", PercentualFormat);
			scriptDescriptor.AddProperty("showPercentualText", ShowPercentualText);
			scriptDescriptor.AddProperty("progressValue", Progress);
			scriptDescriptor.AddProperty("progressBarDivID", ClientID + IdSeparator + "Progress");
			scriptDescriptor.AddProperty("percentDivID", ClientID + IdSeparator + "Percentual");

			return new[] {scriptDescriptor};
		}

		public virtual IEnumerable<ScriptReference> GetScriptReferences()
		{
			return new[]
			{
				GetScriptReference("EvolutionNet.Util.Web.common.js"), 
				GetScriptReference("EvolutionNet.Util.Web.progressbar.js")
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