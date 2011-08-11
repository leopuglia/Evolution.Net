using System;
using System.Web;

namespace EvolutionNet.Sample.UI.Web
{
	public partial class _AdminMaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
		}

	}
}
