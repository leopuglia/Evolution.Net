/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using System;
using EvolutionNet.MVP.Core.Data.Access;

namespace EvolutionNet.MVP.Core.Data.Access
{
	/// <summary>
	/// Define uma interface da instância da AbstractFactory, para a criação de Data Access Objects. 
	/// Deverá ser implementada no módulo de acesso a dados.
	/// </summary>
	public interface IDaoFactory : IFactory
	{
		/// <summary>
		/// Método que retorna um Dao a partir de um modelo (Model).
		/// </summary>
		/// <typeparam name="IdT">Tipo do Identity do modelo</typeparam>
		/// <param name="modelInterfaceType">Tipo da interface que define o modelo.</param>
		/// <returns></returns>
		IDao<IdT> GetDao<IdT>(Type modelInterfaceType);
	}

}