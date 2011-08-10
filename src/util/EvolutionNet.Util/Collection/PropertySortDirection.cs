/*
 * Created by: 
 * Created: terça-feira, 26 de fevereiro de 2008
 */

namespace EvolutionNet.Util.Collection
{
	public enum PropertySortOrder
	{
		None,
		Ascending,
		Descending,
	}

	/// <summary>
	/// Estrutura utilitária para definir uma propriedade para ordenamento de uma lista e a direção (ascendente ou decrescente).
	/// </summary>
	public struct PropertySortDirection
	{
		private string propertyName;
//		private bool ascending;
		private PropertySortOrder sortOrder;

		/// <summary>
		/// Nome da propriedade.
		/// </summary>
		public string PropertyName
		{
			get { return propertyName; }
			set { propertyName = value; }
		}

/*
		public bool Ascending
		{
			get { return ascending; }
			set { ascending = value; }
		}
*/

		public PropertySortOrder SortOrder
		{
			get { return sortOrder; }
			set { sortOrder = value; }
		}

//		public PropertySortDirection() : this("", PropertySortOrder.None)
//		{
//		}

		/// <summary>
		/// Construtor da estrutura, por padrão ascendente.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		public PropertySortDirection(string propertyName) : this(propertyName, PropertySortOrder.None)
		{
		}

		/// <summary>
		/// Construtor da estrutura.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		/// <param name="sortOrder">Direção do ordenamento.</param>
		public PropertySortDirection(string propertyName, PropertySortOrder sortOrder)
		{
			this.propertyName = propertyName ?? "";
			this.sortOrder = sortOrder;
		}
	}

/*
	/// <summary>
	/// Estrutura utilitária para definir uma propriedade para ordenamento de uma lista e a direção (ascendente ou decrescente).
	/// </summary>
	public struct PropertySortDirection<T>
	{
		private T propertyEnum;
		private bool ascending;

		/// <summary>
		/// Nome da propriedade.
		/// </summary>
		public string PropertyName
		{
			get { return propertyEnum.ToString(); }
		}

		public T PropertyEnum
		{
			get { return propertyEnum; }
			set { propertyEnum = value; }
		}

		public bool Ascending
		{
			get { return ascending; }
			set { ascending = value; }
		}

		/// <summary>
		/// Construtor da estrutura, por padrão ascendente.
		/// </summary>
		/// <param name="propertyEnum">Nome da propriedade</param>
		public PropertySortDirection(T propertyEnum) : this(propertyEnum, true)
		{
		}
		
		/// <summary>
		/// Construtor da estrutura.
		/// </summary>
		/// <param name="propertyEnum">Nome da propriedade</param>
		/// <param name="ascending">Direção do ordenamento.</param>
		public PropertySortDirection(T propertyEnum, bool ascending)
		{
			this.propertyEnum = propertyEnum;
			this.ascending = ascending;
		}
	}
*/

}