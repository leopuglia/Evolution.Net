/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Contract;
using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.IoC;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseFacadeFactory : BaseFactory, IBaseFacadeFactory
	{
		private const string TYPE_NAME_CONTRACT = "I{0}Contract";
		private const string TYPE_NAME_DEST = "{0}Facade";

		public ContractT GetFromContract<ContractT>() where ContractT : IBaseContract
		{
			return typeof(ContractT) == typeof(INullContract)
				? default(ContractT)
				: IoCHelper.InstantiateObj<ContractT>(TYPE_NAME_CONTRACT, TYPE_NAME_DEST, GetType());
		}

		/// <summary>
		/// Realiza a inicialização básica de um módulo, na implementação da Factory.
		/// </summary>
		public virtual void Initialize()
		{
			DaoInitializer.InitializeActiveRecord();
		}

/*
		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
		///</summary>
		public virtual void Dispose()
		{
			DaoInitializer.Dispose();
		}
*/

	}
	
}