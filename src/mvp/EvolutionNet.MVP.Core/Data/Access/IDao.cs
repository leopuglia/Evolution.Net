/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using EvolutionNet.MVP.Core.Data.Definition;

namespace EvolutionNet.MVP.Core.Data.Access
{
	/// <summary>
	/// Classe que define o Data Access Object b�sico, seus m�todos e propriedades.
	/// </summary>
	/// <typeparam name="IdT"></typeparam>
	public interface IDao<IdT> : IModel<IdT>
	{
		void Save();
		void Delete();
	}
}