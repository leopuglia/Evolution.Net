/*
 * Created by: 
 * Created: ter�a-feira, 26 de fevereiro de 2008
 */

using System.ComponentModel;

namespace EvolutionNet.MVP.Core.Util
{
	/// <summary>
	/// Estrutura utilit�ria para definir uma propriedade para ordenamento de uma lista e a dire��o (ascendente ou decrescente).
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
		/// Dire��o do ordenamento.
		/// </summary>
		public ListSortDirection SortDirection
		{
			get { return sortDirection; }
			set { sortDirection = value; }
		}

		/// <summary>
		/// Construtor da estrutura, por padr�o ascendente.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		public PropertySortDirection(string propertyName) : this(propertyName, ListSortDirection.Ascending)
		{
		}
		
		/// <summary>
		/// Construtor da estrutura.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		/// <param name="sortDirection">Dire��o do ordenamento.</param>
		public PropertySortDirection(string propertyName, ListSortDirection sortDirection)
		{
			this.propertyName = propertyName;
			this.sortDirection = sortDirection;
		}
	}
}