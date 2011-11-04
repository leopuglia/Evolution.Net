using EvolutionNet.MVP.UI.Web;

namespace EvolutionNet.Sample.UI.Web.Base
{
	public class BaseSamplePage : BasePageView
	{
		public BaseSamplePage()
		{
//			HelperFactory.GetBackgroundWorkerHelper().
		}

		/*
		// TODO: Não funciona
		protected static string LoadControlHtml(UserControl control, string controlPath)
		{
			control = (UserControl)control.LoadControl(controlPath);
			var ms = new MemoryStream(); // create a memory stream
			var sw = new StreamWriter(ms); // create a stream writer based on the memory stream
			var writer = new HtmlTextWriter(sw); // create a HtmlTextWriter that writes to memory stream
			control.RenderControl(writer); // tell it to render itself.
			writer.Flush(); // flush the writer to the memory stream

			// convert the memory stream to byte array, convert that to a string using UTF8 encoding.
			var strTmp = Encoding.UTF8.GetString(ms.ToArray());
			return strTmp;
		}

		// TODO: Não funciona tbm
		public static string GenerateWebControlCode2(string fileName)
		{
			Type controlType = System.Web.Compilation.BuildManager.GetCompiledType(fileName);
			System.Reflection.ConstructorInfo constructor = controlType.GetConstructor(Type.EmptyTypes);
			Control control = (Control)constructor.Invoke(null);

			var ms = new MemoryStream(); // create a memory stream
			var sw = new StreamWriter(ms); // create a stream writer based on the memory stream
			var writer = new HtmlTextWriter(sw); // create a HtmlTextWriter that writes to memory stream
			control.RenderControl(writer); // tell it to render itself.
			writer.Flush(); // flush the writer to the memory stream

			// convert the memory stream to byte array, convert that to a string using UTF8 encoding.
			var strTmp = Encoding.UTF8.GetString(ms.ToArray());
			return strTmp;
		}

		// TODO: Funciona só pra user controls que não têm controles runat=server
		public static string GenerateWebControlCode(string fileName)
		{
			var fullFileName = HostingEnvironment.MapPath(fileName);
			var theText = "";
			if (fullFileName != null)
				theText = File.ReadAllText(fullFileName);
//			string str = "";
			string createCC = "";
//			string renderCC = "";
//			string attribsCC = "";

			//all <asp:Label like tags and id's
			Regex r = new Regex("\\<(?<tag>\\w*):(?<type>\\w*)" + "(.\\n?)*?id=\\\"?(?<id>\\w*)\\\"?(.\\n?)*?>", RegexOptions.IgnoreCase);
			MatchCollection matches = r.Matches(theText);
//			Match m = default(Match);

			//set the startindex to position after the last <%@ register tag!!
			int startindex = 0;
			Match matchRegistertags = Regex.Match(theText, "<%@.*?>", RegexOptions.RightToLeft);
			startindex = matchRegistertags.Index + matchRegistertags.Length;
			if ((startindex < 0))
			{
				startindex = 0;
			}

			foreach (Match m in matches)
			{
				//only start again after endtag (templated controls will not work!!)
				if (m.Index > startindex)
				{

					string tp = m.Groups["type"].Value;
					string id = m.Groups["id"].Value;
					string tag = m.Groups["tag"].Value;

					//the stuff for the render override
					//Get the html in before the control
					//and write this to the HTMLwriter
					string htmlstr = theText.Substring(startindex, m.Index - startindex);
					htmlstr = htmlstr.Replace("\"", "\"\"");
//					renderCC += "writer.Write(@\"" + htmlstr + "\");" + "\r\n";
//					renderCC += id + ".RenderControl(writer);" + "\r\n";

					//Set the index to the position of the endtag (if available,
					//otherwise control is closed with />
					startindex = m.Index + m.Length;
					string endtag = "</" + tag + ":" + tp + ">";
					int inext2 = theText.IndexOf(endtag, startindex);
					if (inext2 != -1)
					{
						startindex = inext2 + endtag.Length;
					}

					// the stuff for the init procedures make sure you add this to
					createCC += id + " = new " + tp + "();" + "\r\n";

					//Add attributes to the object.
					//Only attibutes assigned within the first tag no
					//templated controls or default properties are set
					Regex r2 = new Regex("(?<prop>\\w*)=\\\"?(?<value>\\w*)\\\"?", RegexOptions.IgnoreCase);
					MatchCollection ms2 = r2.Matches(m.Value);
					foreach (Match m2 in ms2)
					{
						string prop = m2.Groups["prop"].Value;
						string val = m2.Groups["value"].Value;
						if (prop.ToLower() != "runat")
						{
							createCC += id + "." + prop + " = \"" + val + "\";" + "\r\n";
						}
					}

					// TODO: Analisar essa variável createCC, não parei pra entendê-la...
					//add the control to the control collection
					createCC += "this.Controls.Add(" + id + ");" + "\r\n" + "\r\n";

				}
			}

			//render the final html after the last control
			string htmlstr2 = theText.Substring(startindex, theText.Length - startindex);
			htmlstr2.Replace("\"", "\"\"");
//			renderCC += "writer.Write(@\"" + htmlstr2 + "\");" + "\r\n";
			//now show the text om the output window

			return htmlstr2;
		}
		*/

	}
}