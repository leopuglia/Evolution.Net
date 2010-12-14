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

			XmlConfigurator.Configure();
			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();
		}

/*
		public override void DoLoad()
		{
			XmlConfigurator.Configure();
			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();
		}
*/
	}
}
