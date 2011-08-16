using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.Util.Web
{
	public class DataboundLabel : DataBoundControl
	{
		#region Properties

		[Themeable(false), Description("The field in the data source that provides the text."), DefaultValue(""),
		 Category("Data")]
		public virtual string DataTextField
		{
			get
			{
				object o = ViewState["DataTextField"];
				return o != null ? (string) o : string.Empty;
			}
			set
			{
				ViewState["DataTextField"] = value;

				base.OnDataPropertyChanged();
			}
		}


		[DefaultValue(""), Themeable(false), Description("The formatting applied to the text. For example, {0:d}."),
		 Category("Data")]
		public virtual string DataTextFormatString
		{
			get
			{
				object o = ViewState["DataTextFormatString"];
				return o != null ? (string) o : string.Empty;
			}
			set
			{
				ViewState["DataTextFormatString"] = value;

				base.OnDataPropertyChanged();
			}
		}

		[Category("Accessibility"), IDReferenceProperty, Description("The ID of the control associated with the Label."),
		 Themeable(false), TypeConverter(typeof (AssociatedControlConverter)), DefaultValue("")]
		public virtual string AssociatedControlID
		{
			get
			{
				var str = (string) ViewState["AssociatedControlID"];
				return str ?? string.Empty;
			}
			set { ViewState["AssociatedControlID"] = value; }
		}

		protected override HtmlTextWriterTag TagKey
		{
			get
			{
				return AssociatedControlID.Length != 0 ? HtmlTextWriterTag.Label : base.TagKey;
			}
		}

		public virtual string Text
		{
			get
			{
				object o = ViewState["Text"];
				return o != null ? (string) o : string.Empty;
			}
		}

		#endregion

		#region Methods

		protected override void PerformDataBinding(IEnumerable data)
		{
			base.PerformDataBinding(data);

			// Clear out the Text property
			ClearText();

			string formatString = "{0}";
			if (string.IsNullOrEmpty(DataTextFormatString) == false)
				formatString = DataTextFormatString;

			// Get the DataTextFormatString field value for the FIRST record
			foreach (object obj in data)
			{
				if (DesignMode)
					SetText(string.Format(formatString, "abc"));
				else
				{
					SetText(string.IsNullOrEmpty(DataTextField)
								? string.Format(formatString, obj)
								: DataBinder.GetPropertyValue(obj, DataTextField, formatString));
				}

				break;
			}
		}

		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			if (!string.IsNullOrEmpty(AssociatedControlID))
			{
				Control control = FindControl(AssociatedControlID);
				if (control == null && !DesignMode)
					throw new HttpException(string.Format("The DataboundLabel '{0}' cannot find associated control ID '{1}'.", ID,
														  AssociatedControlID));
				writer.AddAttribute(HtmlTextWriterAttribute.For, control.ClientID);
			}

			base.AddAttributesToRender(writer);
		}

		protected override void RenderContents(HtmlTextWriter writer)
		{
			writer.Write(Text);
		}


		protected virtual void SetText(string txt)
		{
			ViewState["Text"] = txt;
		}

		protected virtual void ClearText()
		{
			ViewState.Remove("Text");
		}

		#endregion
	}
}
