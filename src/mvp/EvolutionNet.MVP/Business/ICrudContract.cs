/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Essa interface representa o contrato entre o Presenter e o Facade, os métodos que ambos devem implementar
	/// </summary>
	public interface ICrudContract<TO, T, IdT> : IContract//, IDisposable
		where TO : TO<T, IdT>
		where T : class, IModel<IdT>
	{
		//TODO: Aki eu posso aplicar a pattern de command, adicionando os métodos pra adicionar cada comando no contrato e, assim, definir se um facade vai ter salvar, ou listartodos, etc.
		//TODO: Ou simplesmente definir os métodos Save, Cancelar, ou então os métodos CRUD, sei lá ou mesmo não definir métodos e deixar sem os métodos.
		TO To { get; }

		/// <summary>
		/// Reporta o progresso da requisição atual
		/// </summary>
		event EventHandler<ProgressEventArgs> ProgressReported;

		/// <summary>
		/// Busca os dados do MainModel a partir de um ID fornecido no mesmo
		/// </summary>
		void Find();

		/// <summary>
		/// Salva o MainModel atual
		/// </summary>
		void Save();

		/// <summary>
		/// Deleta o MainModel atual
		/// </summary>
		void Delete();
	}
}