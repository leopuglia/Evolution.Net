using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.UI.Windows;
using log4net.Config;

namespace EvolutionNet.Sample.UI.Windows
{
    public partial class MainFrm : BaseFrm
	{
		public MainFrm()
		{
			InitializeComponent();
        }

        public override void DoLoad()
        {
            XmlConfigurator.Configure();
            AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();
        }
	}
}
