using System;
using EvolutionNet.Sample.UI.Web.Base;

namespace EvolutionNet.Sample.UI.Web
{
	public partial class Default : BaseSamplePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			baseUC = CategoryCrudView1;
		}
	}
}
