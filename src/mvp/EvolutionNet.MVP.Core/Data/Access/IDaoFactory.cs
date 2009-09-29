/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using EvolutionNet.MVP.Core.Data.Definition;

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
		/// <typeparam name="T">Tipo do modelo</typeparam>
		/// <typeparam name="IdT">Tipo do ID do modelo</typeparam>
		/// <returns></returns>
//		IDao<IdT> GetDao<IdT>(Type modelInterfaceType);
		T GetDao<T, IdT>() where T : IModel<IdT>;
	}

}