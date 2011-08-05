using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Access;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Data.Definition;
using log4net.Config;

namespace EvolutionNet.Sample.Business
{
	public class BOFactory : BaseBOFactory, IFacadeFactory
	{
		private bool isInitialized;

		public override void Initialize()
		{
			if (!isInitialized)
			{
				XmlConfigurator.Configure();
				DaoInitializer.Instance.InitializeActiveRecord(typeof (SqlServerModel));
				isInitialized = true;
			}
		}

		public void GenerateCreationScripts(string fileName)
		{
			DaoInitializer.Instance.GenerateCreationScripts(fileName);
		}
	}
}