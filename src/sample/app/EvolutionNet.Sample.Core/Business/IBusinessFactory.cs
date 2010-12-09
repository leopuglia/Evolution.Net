using EvolutionNet.MVP.Business;

namespace EvolutionNet.Sample.Core.Business
{
    public interface IFacadeFactory : IBusinessFactory
    {
		void GenerateCreationScripts(string fileName);
    }
}