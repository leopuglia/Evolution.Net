using System;
using System.Web;
using EvolutionNet.MVP.Business;
using EvolutionNet.Util.IoC;
using log4net.Config;

namespace EvolutionNet.Sample.UI.Web
{
	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
//			XmlConfigurator.Configure();
//			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}