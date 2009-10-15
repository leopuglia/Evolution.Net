/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using System;
using EvolutionNet.MVP.Core.Data.Access;

namespace EvolutionNet.MVP.Core.Data.Access
{
	/// <summary>
	/// Define uma interface da inst�ncia da AbstractFactory, para a cria��o de Data Access Objects. 
	/// Dever� ser implementada no m�dulo de acesso a dados.
	/// </summary>
	public interface IDaoFactory : IFactory
	{
		/// <summary>
		/// M�todo que retorna um Dao a partir de um modelo (Model).
		/// </summary>
		/// <typeparam name="IdT">Tipo do Identity do modelo</typeparam>
		/// <param name="modelInterfaceType">Tipo da interface que define o modelo.</param>
		/// <returns></returns>
		IDao<IdT> GetDao<IdT>(Type modelInterfaceType);
	}

}