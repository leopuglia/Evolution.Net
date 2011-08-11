using System.Collections.Generic;
using System.Text;
using System.Web;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebRedirectHelper : IRedirectHelper
	{
		private const string TypeNameSource = "I{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDest = "{0}.aspx";

		#region Thread-safe Singleton

		private WebRedirectHelper()
		{
		}

		public static WebRedirectHelper Instance
		{
			get
			{
				return Nested.instance;
			}
		}
	    
		class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly WebRedirectHelper instance = new WebRedirectHelper();
		}

		#endregion

		public void RedirectToView<T>(object senderView) where T : IControlView
		{
			RedirectToView<T>(senderView, null);
		}

		public void RedirectToView<T>(object senderView, IDictionary<string, string> args) where T : IControlView
		{
			var path = IoCHelper.GetControlVirtualPath(
				TypeNameSource, TypeNameSourceExclude, typeof(T), TypeNameDest, null);

			if (args == null)
				HttpContext.Current.Response.Redirect(path);
			else
			{
				StringBuilder builder = new StringBuilder(path);
				foreach (var arg in args)
				{
					builder.Append(builder.Length == path.Length ? "?" : "&");
					builder.AppendFormat("{0}={1}", HttpUtility.UrlEncode(arg.Key), HttpUtility.UrlEncode(arg.Value));
				}

				HttpContext.Current.Response.Redirect(builder.ToString());
			}
		}

		public bool ShowModalDialogView<T>(T destView, object senderView) where T : IControlView
		{
			// I'm returning false here because in the web I have to edit the values after showing the modal dialog
			((IEditViewContainer<T>) senderView).ShowModalDialog();

			return false;
		}

		public T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView
		{
			return ((IEditViewContainer<T>) senderView).EditView;
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