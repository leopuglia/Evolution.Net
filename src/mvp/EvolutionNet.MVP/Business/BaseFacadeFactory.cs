/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseFacadeFactory : BaseBOFactory
	{
		protected BaseFacadeFactory()
		{
			TypeNameDest = "{0}Facade";
		}
	}
}