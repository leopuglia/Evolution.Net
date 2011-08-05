using System.Web.UI;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Web
{
	public class BasePageView : Page, IControlView, IWebControl
	{
		#region Propriedades

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

		#endregion

/*
		#region Métodos Públicos (IControlView)

		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{
		}

		#endregion
*/

		#region Métodos Locais (Inicialização)

/*
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

//			ControlHelper.Initialize(this);

			Page.Load += Page_Load;
			Page.LoadComplete += Page_LoadComplete;
		}

		private void Page_Load(object sender, EventArgs e)
		{
			DoLoad();
		}

		private void Page_LoadComplete(object sender, EventArgs e)
		{
			DoLoadComplete();
		}
*/

		#endregion

	}
}
