/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using System;
using EvolutionNet.MVP.Core;
using EvolutionNet.MVP.Core.Data.Access;
using EvolutionNet.MVP.Core.IoC;

namespace EvolutionNet.MVP.Data.Access
{
	public abstract class BaseDaoFactory : BaseFactory, IDaoFactory
	{
		//TODO: Colocar essas strings na configuração. Elas são parte do Scaffolding!
		private const string SOURCE_FORMAT = "I{0}";
		private const string DEST_FORMAT = "{0}Dao";

		public IDao<IdT> GetDao<IdT>(Type modelInterfaceType)
		{
			return IoCHelper.InstantiateObj<IDao<IdT>>(SOURCE_FORMAT, modelInterfaceType, 
			                                           DEST_FORMAT, GetType());
			
		}
	}
}