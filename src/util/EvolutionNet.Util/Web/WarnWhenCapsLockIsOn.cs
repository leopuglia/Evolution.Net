using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.Util.Web
{
	public class WarnWhenCapsLockIsOn : Label
	{
		#region Properties

		[Category("Behavior"), Description("The ID of the TextBox control the warning message applies to."), Themeable(false),
		 DefaultValue(""), IDReferenceProperty(typeof (TextBox))]
		public string TextBoxControlId
		{
			get
			{
				var s = ViewState["TextBoxControlId"] as string;
				return s ?? string.Empty;
			}
			set { ViewState["TextBoxControlId"] = value; }
		}

		[Category("Behavior"), Themeable(true), DefaultValue(2500),
		 Description("The number of milliseconds to display the warning message.")]
		public int WarningDisplayTime
		{
			get
			{
				object o = ViewState["WarningDisplayTime"];
				if (o != null && o is int)
					return Convert.ToInt32(o);
				return 2500;
			}
			set { ViewState["WarningDisplayTime"] = value; }
		}

		#endregion

		#region Methods

		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			base.AddAttributesToRender(writer);

			// Add a style attribute that hides this element (by default)
			writer.AddStyleAttribute(HtmlTextWriterStyle.Visibility, "hidden");
			writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
		}

		public override void Focus()
		{
			throw new NotSupportedException("The Focus() method is not supported for controls of this type.");
		}

		protected virtual TextBox GetTextBoxControl()
		{
			if (string.IsNullOrEmpty(TextBoxControlId))
				throw new HttpException(
					string.Format(
						"You must provide a value for the TextBoxControlId property for the WarnWhenCapsLockIsOn control with ID '{0}'.",
						ID));

			var tb = FindControl(TextBoxControlId) as TextBox;
			if (tb == null)
				throw new HttpException(
					string.Format(
						"The WarnWhenCapsLockIsOn control with ID '{0}' could not find a TextBox control with the ID '{1}'.", ID,
						TextBoxControlId));

			return tb;
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (Enabled)
			{
				/* We need to add two bits of JavaScript to the page:
				 *  (1) The include file that has the JavaScript function to check if Caps Lock is on
				 *  (2) JavaScript that will call the appropriate function in (1) when a key is pressed in the TextBoxControlId TextBox
				 */

				// (1) Register the client-side function using WebResource.axd (if needed)
				// see: http://aspnet.4guysfromrolla.com/articles/080906-1.aspx
				if (Page != null && !Page.ClientScript.IsClientScriptIncludeRegistered("skmcontrols"))
					Page.ClientScript.RegisterClientScriptInclude("skmcontrols",
																  Page.ClientScript.GetWebResourceUrl(GetType(),
																									  "EvolutionNet.Util.Web.skm.js"));


				// (2) Call skm_CountTextBox onkeyup
				TextBox tb = GetTextBoxControl();
				tb.Attributes["onkeypress"] += string.Format("skm_CheckCapsLock( event, '{0}', {1});", ClientID, WarningDisplayTime);
			}
		}

		#endregion
	}
}
