/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using System;
using EvolutionNet.MVP.Contract;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Define uma interface da inst�ncia da AbstractIoCFactory, para a cria��o de Facades. 
	/// Dever� ser implementada no m�dulo de neg�cios.
	/// </summary>
	public interface IBaseFacadeFactory : IFactory//, IDisposable
	{
		ContractT GetFromContract<ContractT>() where ContractT : IBaseContract;

		/// <summary>
		/// Realiza a inicializa��o b�sica de um m�dulo, na implementa��o da Factory.
		/// </summary>
		void Initialize();
	}

}