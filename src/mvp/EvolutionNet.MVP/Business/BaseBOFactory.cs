using System;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseBOFactory : BaseFactory, IBusinessFactory
	{
		protected string TypeNameContractIgnore;
		protected string TypeNameContract;
		protected string TypeNameDest;

		protected BaseBOFactory()
		{
			TypeNameContractIgnore = "Business";
			TypeNameContract = "I{0}Contract";
			TypeNameDest = "{0}BO";
		}

//		private bool isInitialized;

/*
		/// <summary>
		/// Instancia um objeto a partir de tipo e descrição do formato do tipo, tanto de origem como de destino.
		/// </summary>
		/// <param name="sourceFormat">String de formato do tipo de origem, por exemplo "{0}Presenter"</param>
		/// <param name="sourceType">Tipo de origem, por exemplo [Funcionalidade]Presenter</param>
		/// <param name="destFormat">String de formato do tipo de destino, por exemplo "{0}Facade"</param>
		/// <param name="destType">Tipo de destino, por exemplo [Funcionalidade]Facade</param>
		/// <param name="args">Argumentos a serem passados ao construtor do tipo</param>
		/// <returns>Retorna uma instância baseada no tipo de destino, por exemplo [Tipo.Funcionalidade]Facade</returns>
		public object GetObject(string sourceFormat, Type sourceType, 
			string destFormat, Type destType, params object[] args)
		{
			return IoCHelper.InstantiateObj(sourceFormat, sourceType,
											destFormat, destType, args);
		}
*/

		public T CreateInstanceFromInterface<T>(string sourceFormat, string sourceExclude, string destFormat,
												string destAdd, Type destType, params object[] args)
		{
			return IoCHelper.InstantiateObj<T>(sourceFormat, sourceExclude, destFormat, destAdd, destType, args);
		}

		public T CreateInstance<T>(params object[] args)
		{
			return (T) Activator.CreateInstance(typeof (T), args);
		}

		public ContractT GetFromContract<ContractT>(params object[] args) where ContractT : IContract
		{
			return typeof (ContractT) == typeof (INullContract)
				   	? default(ContractT)
				   	: IoCHelper.InstantiateObj<ContractT>(TypeNameContract, TypeNameContractIgnore,
				   										  TypeNameDest, null, GetType(),
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