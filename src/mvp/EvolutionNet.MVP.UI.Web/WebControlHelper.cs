using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebControlHelper : IControlHelper
	{
		private const string TypeNameSource = "I{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDest = "{0}View.ascx";
		private readonly TemplateControl parentView;

		public WebControlHelper(IControlView view)
		{
			parentView = (TemplateControl)view;
		}

/*
		public void Initialize(IControlView view)
		{
			parentView = (TemplateControl)view;
		}
*/

		public T CreateControlView<T>() where T : IControlView
		{
			return CreateControlView<T>(null);
		}

		public T CreateControlView<T>(params object[] args) where T : IControlView
		{
			return (T)(object)parentView.LoadControl(IoCHelper.GetControlVirtualPath(
				TypeNameSource, TypeNameSourceExclude, typeof(T), TypeNameDest, null));
		}

		public void AddControlView(IControlView view)
		{
			parentView.Controls.Add((Control)view);
		}

		public void AddControlView(IControlView view, object controlCollection)
		{
			((ControlCollection)controlCollection).Add((Control)view);
		}

		public void AddControlViewAt(int index, IControlView view)
		{
			parentView.Controls.AddAt(index, (Control)view);
		}

		public void AddControlViewAt(int index, IControlView view, object controlCollection)
		{
			((ControlCollection)controlCollection).AddAt(index, (Control)view);
		}

		public void RemoveControlView(IControlView view)
		{
			parentView.Controls.Remove((Control)view);
		}

		public void RemoveControlView(IControlView view, object controlCollection)
		{
			((ControlCollection)controlCollection).Remove((Control)view);
		}

		public void RemoveControlViewAt(int index)
		{
			parentView.Controls.RemoveAt(index);
		}

		public void RemoveControlViewAt(int index, object controlCollection)
		{
			((ControlCollection)controlCollection).RemoveAt(index);
		}

		public T GetControlView<T>(object sender) where T : IControlView
		{
			while (!(sender is T))
			{
				sender = ((Control)sender).Parent;
			}

			return (T)sender;
		}

		#region GenerateControlHtml

		//TODO: Aparentemente funciona com qualquer controle!!!
		public static string GenerateControlHtml(string virtualPath)
		{
			// Create instance of the page control
			Page page = new Page();
			page.EnableViewState = false;

			// Create instance of the user control
			Control userControl = page.LoadControl(virtualPath);
			userControl.ID = "_" + virtualPath.Replace("~", "").Replace("/", "").Replace(".ascx", "");

			//Disabled ViewState- If required
			//userControl.EnableViewState = false;

			//Form control is mandatory on page control to process User Controls
			HtmlForm form = new HtmlForm();
			form.ID = "__t_FormTemp";

			//form.EnableViewState = false;
			page.Controls.Add(form); //Add form to the page
//			form.Controls.Add(new LiteralControl(STR_BeginRenderControlBlock));

			//Add user control to the form
			form.Controls.Add(userControl);
//			form.Controls.Add(new LiteralControl(STR_EndRenderControlBlock));

			//Write the control Html to text writer
			StringWriter textWriter = new StringWriter();

			//execute page on server
			HttpContext.Current.Server.Execute(page, textWriter, false);

			// Clean up code and return html
			string getHtml = CleanHtml(textWriter.ToString());
			textWriter.Dispose();

			return getHtml;
		}

		/// <summary>
		/// Removes Form tags using Regular Expression
		/// </summary>
		private static string CleanHtml(string html)
		{
			try
			{
				html = Regex.Replace(html, @"<[/]?(form|[ovwxp]:\w+)[^>]*?>", "", RegexOptions.IgnoreCase);

//				int inicio = html.IndexOf(STR_BeginRenderControlBlock);
//				html = html.Remove(0, inicio);
//
//				int fim = html.IndexOf(STR_EndRenderControlBlock) + STR_EndRenderControlBlock.Length;
//				html = html.Substring(0, fim);
			}
			catch
			{
				html = string.Empty;
			}

			return html;
		}

		#endregion

	}
}