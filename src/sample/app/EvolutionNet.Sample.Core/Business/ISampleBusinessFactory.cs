using EvolutionNet.MVP.Business;

namespace EvolutionNet.Sample.Core.Business
{
	public interface ISampleBusinessFactory : IBusinessFactory
	{
		void GenerateCreationScripts(string fileName);
	}
}