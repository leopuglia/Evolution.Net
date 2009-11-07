using System;
using System.Web.UI;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseUC : UserControl, IWebUCView
	{
		protected BaseMessageUC messageUC;

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			Page.LoadComplete += BasePage_LoadComplete;
		}

		private void BasePage_LoadComplete(object sender, EventArgs e)
		{
			DoLoadComplete();
		}

		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{

		}

		public virtual void ShowMessage(string caption, string message)
		{
			messageUC.ShowMessage(caption, message);
		}

		public virtual void ShowErrorMessage(string caption, string message, Exception ex)
		{
			messageUC.ShowErrorMessage(caption, message, ex);
		}

		public virtual object CreateControl(string virtualPath)
		{
			return LoadControl(virtualPath);
		}

		public virtual object CreateControl(Type t, params object[] args)
		{
			return LoadControl(t, args);
		}

		public virtual T CreateControl<T>(string virtualPath) where T : Control
		{
			return (T) LoadControl(virtualPath);
		}

		public virtual T CreateControl<T>(params object[] args) where T : Control
		{
			return (T)LoadControl(typeof(T), args);
		}

	}
}
