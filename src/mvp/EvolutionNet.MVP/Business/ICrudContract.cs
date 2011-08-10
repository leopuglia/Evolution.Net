/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System.Collections.Generic;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Essa interface representa o contrato entre o Presenter e o Facade, os m�todos que ambos devem implementar
	/// </summary>
	public interface ICrudContract<TO, T, IdT> : IListContract<TO, T, IdT>//, IDisposable
		where TO : CrudTO<T, IdT>
		where T : class, IModel<IdT>
	{
		//TODO: Aki eu posso aplicar a pattern de command, adicionando os m�todos pra adicionar cada comando no contrato e, assim, definir se um facade vai ter salvar, ou listartodos, etc.
		//TODO: Ou simplesmente definir os m�todos Save, Cancelar, ou ent�o os m�todos CRUD, sei l� ou mesmo n�o definir m�todos e deixar sem os m�todos.
//		TO To { get; }
		IList<ValidationError> ErrorList { get; set; }

		/// <summary>
		/// Busca os dados do MainModel a partir de um ID fornecido no mesmo
		/// </summary>
		void Find();

		/// <summary>
		/// Lista todos os elementos do model
		/// </summary>
//		void FindAll();

		/// <summary>
		/// Salva o MainModel atual
		/// </summary>
		void Save();

		/// <summary>
		/// Deleta o MainModel atual
		/// </summary>
		void Delete();

		void DeleteByID();

		bool Validate(bool throwException);

	}
}