/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseFacadeFactory : BaseFactory, IBusinessFactory
	{
		private const string TYPE_NAME_CONTRACT_IGNORE = "Business";
		private const string TYPE_NAME_CONTRACT = "I{0}Contract";
		private const string TYPE_NAME_DEST = "{0}Facade";

//		private bool isInitialized;

		public ContractT GetFromContract<ContractT>(params object[] args) where ContractT : IContract
		{
			return typeof (ContractT) == typeof (INullContract)
				   	? default(ContractT)
				   	: IoCHelper.InstantiateObj<ContractT>(TYPE_NAME_CONTRACT, TYPE_NAME_CONTRACT_IGNORE,
				   										  TYPE_NAME_DEST, null, GetType(),
														  args);
		}

		public abstract void Initialize();
/*
		{
			if (!isInitialized)
			{
				XmlConfigurator.Configure();
				DaoInitializer.Instance.InitializeActiveRecord();
				isInitialized = true;
			}
		}

		public virtual void Initialize(Type type)
		{
			if (!isInitialized)
			{
				XmlConfigurator.Configure();
				DaoInitializer.Instance.InitializeActiveRecord(type);
				isInitialized = true;
			}
		}
*/

	}
	
}