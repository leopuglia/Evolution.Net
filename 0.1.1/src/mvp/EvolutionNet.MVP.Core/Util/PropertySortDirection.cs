/*
 * Created by: 
 * Created: terça-feira, 26 de fevereiro de 2008
 */

using System.ComponentModel;

namespace EvolutionNet.MVP.Core.Util
{
	/// <summary>
	/// Estrutura utilitária para definir uma propriedade para ordenamento de uma lista e a direção (ascendente ou decrescente).
	/// </summary>
	public struct PropertySortDirection
	{
		private string propertyName;
		private ListSortDirection sortDirection;

		/// <summary>
		/// Nome da propriedade.
		/// </summary>
		public string PropertyName
		{
			get { return propertyName; }
			set { propertyName = value; }
		}

		/// <summary>
		/// Direção do ordenamento.
		/// </summary>
		public ListSortDirection SortDirection
		{
			get { return sortDirection; }
			set { sortDirection = value; }
		}

		/// <summary>
		/// Construtor da estrutura, por padrão ascendente.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		public PropertySortDirection(string propertyName) : this(propertyName, ListSortDirection.Ascending)
		{
		}
		
		/// <summary>
		/// Construtor da estrutura.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		/// <param name="sortDirection">Direção do ordenamento.</param>
		public PropertySortDirection(string propertyName, ListSortDirection sortDirection)
		{
			this.propertyName = propertyName;
			this.sortDirection = sortDirection;
		}
	}
}