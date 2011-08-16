using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.Util.Web
{
	public class RedirectButton : WebControl
	{
		#region Constructors

		public RedirectButton() : base(HtmlTextWriterTag.Input)
		{
		}

		#endregion

		#region Properties

		[Description("The Button's text."), Category("Appearance"), DefaultValue(""), Localizable(true), Bindable(true)]
		public string Text
		{
			get { return ViewState["Text"] as string ?? string.Empty; }
			set { ViewState["Text"] = value; }
		}

		[Description("The URL the user is redirected to when the Button is clicked."), Category("Behavior"), Themeable(false)]
		public string RedirectUrl
		{
			get { return ViewState["RedirectUrl"] as string ?? string.Empty; }
			set { ViewState["RedirectUrl"] = value; }
		}

		[Description("The ID of the associated control whose value will be included in the querystring."),
		 Category("Behavior"), Themeable(false)]
		public string AssociatedControlId
		{
			get { return ViewState["AssociatedControlId"] as string ?? string.Empty; }
			set { ViewState["AssociatedControlId"] = value; }
		}

		protected Control AssociatedControl
		{
			get { return string.IsNullOrEmpty(AssociatedControlId) ? null : FindControl(AssociatedControlId); }
		}

		[Description("The name of the querystring parameter used to send the associated control's value."),
		 Category("Behavior"), Themeable(false)]
		public string QueryStringParameterName
		{
			get { return ViewState["QueryStringParameterName"] as string ?? string.Empty; }
			set { ViewState["QueryStringParameterName"] = value; }
		}

		[Description("Additional opaque data to append to the querystring."), Category("Behavior"), Themeable(false)]
		public string AdditionalQuerystringContent
		{
			get { return ViewState["AdditionalQuerystringContent"] as string ?? string.Empty; }
			set { ViewState["AdditionalQuerystringContent"] = value; }
		}

		protected bool PropertiesValid
		{
			get { return ControlPropertiesValid(); }
		}

		#endregion

		#region Methods

		protected bool ControlPropertiesValid()
		{
			// Make sure RedirectUrl is set
			if (string.IsNullOrEmpty(RedirectUrl))
				throw new HttpException("You must provide a value for RedirectUrl.");

			// Make sure AssociatedControlId references a TextBox or DropDownList
			if (string.IsNullOrEmpty(AssociatedControlId) == false)
			{
				Control ctrl = FindControl(AssociatedControlId);
				if (ctrl == null)
					throw new HttpException(string.Format("Could not find AssociatedControlId, '{0}'.", AssociatedControlId));

				if (!(ctrl is TextBox || ctrl is DropDownList))
					throw new HttpException(
						string.Format("AssociatedControlId must be a TextBox or DropDownList. Type {0} not supported.", ctrl.GetType()));
			}

			// If QueryStringParameterName is specified then make sure AssociatedControlId is, too, and vice-a-versa
			if ((string.IsNullOrEmpty(QueryStringParameterName) == false && string.IsNullOrEmpty(AssociatedControlId)) ||
				(string.IsNullOrEmpty(QueryStringParameterName) && string.IsNullOrEmpty(AssociatedControlId) == false))
				throw new HttpException(
					"If  QueryStringParameterName is specified then AssociatedControlId must be assigned a value, too, and vice-a-versa.");

			// Make sure QueryStringParameterName, if provided, does not contain ? or &
			if (string.IsNullOrEmpty(QueryStringParameterName) == false && (QueryStringParameterName.IndexOf("?") >= 0 ||
																			QueryStringParameterName.IndexOf("&") >= 0))
				throw new HttpException("QueryStringParameterName cannot contain the ? or & characters.");

			// Make sure that AdditionalQuerystringContent, if provided, does not contain ?
			if (string.IsNullOrEmpty(AdditionalQuerystringContent) == false && AdditionalQuerystringContent.IndexOf("?") >= 0)
				throw new HttpException("AdditionalQuerystringContent cannot contain the ? character.");

			// If we reach here, then properties are valid!
			return true;
		}

		protected virtual string GetRedirectUrl()
		{
			string completeUrl = ResolveClientUrl(RedirectUrl);

			// Do we need to tack on a querystring?
			if (string.IsNullOrEmpty(QueryStringParameterName) == false ||
				string.IsNullOrEmpty(AdditionalQuerystringContent) == false)
			{
				// Yep! Add the ? if needed
				if (completeUrl.IndexOf("?") < 0)
					completeUrl += "?";
			}

			// Add the QueryStringParameterName and placeholder for the associated control's value, if needed
			if (string.IsNullOrEmpty(QueryStringParameterName) == false)
				completeUrl += string.Concat(QueryStringParameterName, "={AssocCtrlValue}");

			// Add the AdditionalQuerystringContent, if needed
			if (string.IsNullOrEmpty(AdditionalQuerystringContent) == false)
			{
				// Do we need to add an ampersand?
				if (completeUrl.EndsWith("?") == false && completeUrl.EndsWith("&") == false)
					completeUrl += "&";

				completeUrl += AdditionalQuerystringContent;
			}

			return completeUrl;
		}

		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
			writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
			writer.AddAttribute(HtmlTextWriterAttribute.Value, Text);

			base.AddAttributesToRender(writer);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			/* We need to add three bits of JavaScript to the page:
			 *  (1) The include file that has the JavaScript function to count the characters/words
			 *  (2) JavaScript that will call the appropriate function in (1) when the button is clicked
			 *  (3) If there is an AssociatedControl and it is a TextBox, JavaScript to "click" the button when the Enter key is pressed
			 */

			// (1) Register the EvolutionNet.Util.Web client-side functions using WebResource.axd (if needed)
			// see: http://aspnet.4guysfromrolla.com/articles/080906-1.aspx
			if (Page != null && !Page.ClientScript.IsClientScriptIncludeRegistered("skmcontrols"))
				Page.ClientScript.RegisterClientScriptInclude("skmcontrols",
					Page.ClientScript.GetWebResourceUrl(GetType(), "EvolutionNet.Util.Web.skm.js"));


			// (2) Call skm_Redirect when the Button is clicked
			Attributes["onclick"] += string.Format("skm_Redirect('{0}', '{1}');",
												   GetRedirectUrl(),
												   AssociatedControl == null ? string.Empty : AssociatedControl.ClientID);


			// (3) Have Enter cause a "click" if an associated control is specified and it's a single-line TextBox
			var AssociatedTextBoxControl = AssociatedControl as TextBox;
			if (AssociatedTextBoxControl != null && AssociatedTextBoxControl.TextMode == TextBoxMode.SingleLine)
			{
				AssociatedTextBoxControl.Attributes["onkeypress"] += string.Format("return skm_CheckForEnter(event, '{0}');",
																				   ClientID);
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (base.DesignMode == false)
				// Ensure properties are valid
				ControlPropertiesValid();

			base.Render(writer);
		}

		#endregion
	}
}
