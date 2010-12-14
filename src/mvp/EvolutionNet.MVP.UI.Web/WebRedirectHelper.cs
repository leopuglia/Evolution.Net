using System.Web;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Web
{
    public class WebRedirectHelper : BaseSingleton<WebRedirectHelper>, IRedirectHelper
    {
        private const string TypeNameSource = "{0}View";
        private const string TypeNameSourceExclude = "View";
        private const string TypeNameDest = "{0}.aspx";

        public void RedirectToView<T>(object senderView, params object[] args)
        {
            HttpContext.Current.Response.Redirect(IoCHelper.GetControlVirtualPath(
                TypeNameSource, TypeNameSourceExclude, typeof(T), TypeNameDest, null));
        }

        public bool RedirectToViewModal<T>(object senderView, params object[] args)
        {
            HttpContext.Current.Response.Redirect(IoCHelper.GetControlVirtualPath(
                TypeNameSource, TypeNameSourceExclude, typeof(T), TypeNameDest, null));

            return true;
        }
    }
}