using System.Web.UI;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseUCView : UserControl, IControlView, IWebControl
	{
		#region Propriedades Públicas

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

		#endregion

		#region Métodos Públicos (IControlView)

/*
		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{
		}
*/

		#endregion

		#region Métodos Locais (Inicialização)

/*
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

//			ControlHelper.Initialize(this);

			Page.Load += BasePageLoad;
			Page.LoadComplete += BasePageLoadComplete;
		}

		private void BasePageLoad(object sender, EventArgs e)
		{
			DoLoad();
		}

		private void BasePageLoadComplete(object sender, EventArgs e)
		{
			DoLoadComplete();
		}
*/

		#endregion

	}
}
