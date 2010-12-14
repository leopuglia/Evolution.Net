using System;
using System.Web.UI;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BasePageView : Page, IControlView
	{
	    private IControlHelper controlHelper;

	    #region Propriedades

	    public IPathHelper PathHelper
	    {
	        get { return WebPathHelper.Instance; }
	    }

        public IControlHelper ControlHelper
        {
            get { return controlHelper ?? (controlHelper = new WebControlHelper(this)); }
        }

        public IMessageHelper MessageHelper
        {
            get { return WebMessageHelper.Instance; }
        }

	    public IRedirectHelper RedirectHelper
	    {
            get { return WebRedirectHelper.Instance; }
	    }

	    public IControlView ParentView
        {
            get { return (IControlView)Parent; }
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

	    #region Métodods Locais (Inicialização)

/*
	    protected override void OnInit(EventArgs e)
	    {
	        base.OnInit(e);

//            ControlHelper.Initialize(this);

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
