/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Define uma interface da instância da AbstractIoCFactory, para a criação de Facades. 
	/// Deverá ser implementada no módulo de negócios.
	/// </summary>
	public interface IBusinessFactory : IFactory//, IDisposable
	{
		ContractT GetFromContract<ContractT>(params object[] args) where ContractT : IBaseContract;

		/// <summary>
		/// Realiza a inicialização básica de um módulo, na implementação da Factory.
		/// </summary>
		void Initialize();
	}

}