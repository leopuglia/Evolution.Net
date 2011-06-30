using System;
using System.Web;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.IoC;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebRedirectHelper : BaseSingleton<WebRedirectHelper>, IRedirectHelper
	{
		private const string TypeNameSource = "{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDest = "{0}.aspx";

		public void RedirectToView<T>(object senderView, params object[] args) where T : IControlView
		{
			HttpContext.Current.Response.Redirect(IoCHelper.GetControlVirtualPath(
				TypeNameSource, TypeNameSourceExclude, typeof(T), TypeNameDest, null));
		}

		public bool ShowModalDialogView(IControlView destView, object senderView)
		{
			throw new NotImplementedException();
		}

		public T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView
		{
			throw new NotImplementedException();
		}

/*
		public bool ShowModalDialogView<T>(object senderView, params object[] args)
		{
			HttpContext.Current.Response.Redirect(IoCHelper.GetControlVirtualPath(
				TypeNameSource, TypeNameSourceExclude, typeof(T), TypeNameDest, null));

			return true;
		}
*/
	}
}