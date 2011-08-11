using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EvolutionNet.Sample.UI.Web.Base;

namespace EvolutionNet.Sample.UI.Web.Base
{
	public partial class _BaseMaster : MasterPage
	{
		private HtmlMeta descriptionMeta;
		private HtmlMeta keywordsMeta;

		public MessageUC MessageUC
		{
			get { return MessageUC1; }
		}

		protected override void OnInit(EventArgs e) 
		{
            base.OnInit(e);

            MetaDescriptionHolder.Load += MetaDescriptionHolder_Load;
            MetaKeywordsHolder.Load += MetaKeywordsHolder_Load;

            Page.LoadComplete += Page_LoadComplete;
        }

		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			Page page = sender as Page;
			if (page == null) return;

			if (descriptionMeta != null) page.Header.Controls.Add(descriptionMeta);
			if (keywordsMeta != null) page.Header.Controls.Add(keywordsMeta);
		}

		protected void MetaDescriptionHolder_Load(object sender, EventArgs e) 
		{
            string content = ParseHolderContent(MetaDescriptionHolder);

            if (string.IsNullOrEmpty(content)) return;

            descriptionMeta = new HtmlMeta {Name = "description", Content = content};
        }

		protected void MetaKeywordsHolder_Load(object sender, EventArgs e) 
		{
            string content = ParseHolderContent(MetaKeywordsHolder);

            if (string.IsNullOrEmpty(content)) return;

            keywordsMeta = new HtmlMeta {Name = "keywords", Content = content};
        }

        private string ParseHolderContent(Control holder) 
		{
            if (holder == null || holder.Controls.Count == 0) 
				return string.Empty;

			while (holder.Controls.Count > 0 && holder.Controls[0] is ContentPlaceHolder)
				holder = holder.Controls[0];

			if (holder.Controls.Count == 0)
				return string.Empty;

			LiteralControl control = holder.Controls[0] as LiteralControl;
            if (control == null || string.IsNullOrEmpty(control.Text)) 
				return string.Empty;

            return control.Text.Trim();
        }

	}
}
