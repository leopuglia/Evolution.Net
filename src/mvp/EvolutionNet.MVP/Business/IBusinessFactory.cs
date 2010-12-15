/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using System;
using EvolutionNet.MVP.IoC;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Define uma interface da inst�ncia da AbstractIoCFactory, para a cria��o de Facades. 
	/// Dever� ser implementada no m�dulo de neg�cios.
	/// </summary>
	public interface IBusinessFactory : IFactory//, IDisposable
	{
		ContractT GetFromContract<ContractT>(params object[] args) where ContractT : IContract;

		void Initialize();
//		void Initialize(Type type);
	}

}