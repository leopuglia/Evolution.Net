/*
 * Created by: 
 * Created: terça-feira, 18 de dezembro de 2007
 */

using System.Collections.Generic;
using EvolutionNet.MVP.Core.Data.Definition;

namespace EvolutionNet.MVP.Core.TO
{
	/// <summary>
	/// Interface que define um Transfer Object.
	/// </summary>
	/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
	/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
	public interface ITo<T, IdT> where T : IModel<IdT>
	{
		/// <summary>
		/// Modelo principal da funcionalidade sendo desenvolvida.
		/// </summary>
		T MainModel { get; set; }
        IList<T> List { get; set; }
	}
}