using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace EvolutionNet.MVP.UI.Web
{
	public static class ControlHelper
	{
		//TODO: Aparentemente funciona com qualquer controle!!!
		public static string GenerateControlHtml(string localControl)
		{
			// Create instance of the page control
			Page page = new Page();
			page.EnableViewState = false;

			// Create instance of the user control
			Control userControl = page.LoadControl(localControl);
			userControl.ID = "_" + localControl.Replace("~", "").Replace("/", "").Replace(".ascx", "");

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

	}
}