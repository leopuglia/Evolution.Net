/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System.Collections.Generic;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Essa interface representa o contrato entre o Presenter e o Facade, os métodos que ambos devem implementar
	/// </summary>
	public interface ICrudListContract<TO, T, IdT> : IListContract<TO, T, IdT>//, IDisposable
		where TO : CrudListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		//TODO: Aki eu posso aplicar a pattern de command, adicionando os métodos pra adicionar cada comando no contrato e, assim, definir se um facade vai ter salvar, ou listartodos, etc.
		//TODO: Ou simplesmente definir os métodos Save, Cancelar, ou então os métodos CRUD, sei lá ou mesmo não definir métodos e deixar sem os métodos.
//		TO To { get; }
		IList<ValidationError> ErrorList { get; set; }

		/// <summary>
		/// Salva o MainModel atual
		/// </summary>
		void Save();

		void SaveList();

		/// <summary>
		/// Deleta o MainModel atual
		/// </summary>
		void Delete();

		void DeleteList();

		void DeleteByID();

		bool Validate(bool throwException);

	}
}