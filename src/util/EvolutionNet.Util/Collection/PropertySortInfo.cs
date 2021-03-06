/*
 * Created by: 
 * Created: ter�a-feira, 26 de fevereiro de 2008
 */

using System;

namespace EvolutionNet.Util.Collection
{
	[Serializable]
	public enum PropertySortOrder
	{
		None,
		Ascending,
		Descending,
	}

	/// <summary>
	/// Estrutura utilit�ria para definir uma propriedade para ordenamento de uma lista e a dire��o (ascendente ou decrescente).
	/// </summary>
	[Serializable]
	public struct PropertySortInfo
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

//		public PropertySortInfo() : this("", PropertySortOrder.None)
//		{
//		}

		/// <summary>
		/// Construtor da estrutura, por padr�o ascendente.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		public PropertySortInfo(string propertyName) : this(propertyName, PropertySortOrder.None)
		{
		}

		/// <summary>
		/// Construtor da estrutura.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		/// <param name="sortOrder">Dire��o do ordenamento.</param>
		public PropertySortInfo(string propertyName, PropertySortOrder sortOrder)
		{
			this.propertyName = propertyName ?? "";
			this.sortOrder = sortOrder;
		}
	}

/*
	/// <summary>
	/// Estrutura utilit�ria para definir uma propriedade para ordenamento de uma lista e a dire��o (ascendente ou decrescente).
	/// </summary>
	public struct PropertySortInfo<T>
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
		/// Construtor da estrutura, por padr�o ascendente.
		/// </summary>
		/// <param name="propertyEnum">Nome da propriedade</param>
		public PropertySortInfo(T propertyEnum) : this(propertyEnum, true)
		{
		}
		
		/// <summary>
		/// Construtor da estrutura.
		/// </summary>
		/// <param name="propertyEnum">Nome da propriedade</param>
		/// <param name="ascending">Dire��o do ordenamento.</param>
		public PropertySortInfo(T propertyEnum, bool ascending)
		{
			this.propertyEnum = propertyEnum;
			this.ascending = ascending;
		}
	}
*/

}