/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;

namespace EvolutionNet.MVP.Core.Contract
{
	/// <summary>
	/// Essa interface representa o contrato entre o Presenter e o Facade, os métodos que ambos devem implementar
	/// </summary>
	public interface IContract : IDisposable
	{
		//TODO: Aki eu posso aplicar a pattern de command, adicionando os métodos pra adicionar cada comando no contrato e, assim, definir se um facade vai ter salvar, ou listartodos, etc.
		//TODO: Ou simplesmente definir os métodos Save, Cancelar, ou então os métodos CRUD, sei lá ou mesmo não definir métodos e deixar sem os métodos.

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

		//TODO: Modificar este método.
		/// <summary>
		/// Deleta o MainModel atual, mesmo a partir de um ID
		/// </summary>
		void Delete();

        /// <summary>
        /// Lista todos os elementos do model
        /// </summary>
		void FindAll();

		/// <summary>
		/// Realiza toda a inicialização necessária
		/// </summary>
		void Initialize();
		
	}
}