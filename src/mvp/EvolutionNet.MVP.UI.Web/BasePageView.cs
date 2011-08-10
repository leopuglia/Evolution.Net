using System;
using System.ComponentModel;
using System.Web.UI;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Web
{
	public class BasePageView : Page, IControlView, IWebControl
	{
		protected BaseUCView baseUC;

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
				AfterLoadComplete(this, new EventArgs());

			if (baseUC != null)
				baseUC.OnAfterLoadComplete(e);
		}

		#endregion

		#region Local Event Override

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			LoadComplete += BasePageView_LoadComplete;
		}

		#endregion

		#region Local Event Methods

		private void BasePageView_LoadComplete(object sender, EventArgs e)
		{
			OnAfterLoadComplete(e);
		}

		#endregion

		#region Local Methods

		protected void DeclareControlOnClient(string clientVarName, string clientControlID)
		{
			ClientScript.RegisterStartupScript(GetType(), clientVarName,
			                                   string.Format("var {0} = $get('{1}');\r\n", clientVarName, clientControlID), true);
		}

		#endregion
	}
}
