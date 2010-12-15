using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.UI.Windows;
using log4net.Config;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class MainFrm : BaseFrmView
	{
		public MainFrm()
		{
			InitializeComponent();

			baseUC = mainView1;
		}

	}
}
