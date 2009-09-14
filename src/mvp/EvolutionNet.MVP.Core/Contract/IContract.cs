/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;

namespace EvolutionNet.MVP.Core.Contract
{
	/// <summary>
	/// Essa interface representa o contrato entre o Presenter e o Facade, os m�todos que ambos devem implementar
	/// </summary>
	public interface IContract : IDisposable
	{
		//TODO: Aki eu posso aplicar a pattern de command, adicionando os m�todos pra adicionar cada comando no contrato e, assim, definir se um facade vai ter salvar, ou listartodos, etc.
		//TODO: Ou simplesmente definir os m�todos Save, Cancelar, ou ent�o os m�todos CRUD, sei l� ou mesmo n�o definir m�todos e deixar sem os m�todos.

		/// <summary>
		/// Reporta o progresso da requisi��o atual
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

		//TODO: Modificar este m�todo.
		/// <summary>
		/// Deleta o MainModel atual, mesmo a partir de um ID
		/// </summary>
		void Delete();

        /// <summary>
        /// Lista todos os elementos do model
        /// </summary>
		void FindAll();

		/// <summary>
		/// Realiza toda a inicializa��o necess�ria
		/// </summary>
		void Initialize();
		
	}
}