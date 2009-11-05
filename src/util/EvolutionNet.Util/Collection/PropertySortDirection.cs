/*
 * Created by: 
 * Created: terça-feira, 26 de fevereiro de 2008
 */

namespace EvolutionNet.Util.Collection
{
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

	/// <summary>
	/// Estrutura utilitária para definir uma propriedade para ordenamento de uma lista e a direção (ascendente ou decrescente).
	/// </summary>
	public struct PropertySortDirection
	{
		private string propertyName;
		private bool ascending;

		/// <summary>
		/// Nome da propriedade.
		/// </summary>
		public string PropertyName
		{
			get { return propertyName; }
			set { propertyName = value; }
		}

		public bool Ascending
		{
			get { return ascending; }
			set { ascending = value; }
		}

		/// <summary>
		/// Construtor da estrutura, por padrão ascendente.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		public PropertySortDirection(string propertyName)
			: this(propertyName, true)
		{
		}

		/// <summary>
		/// Construtor da estrutura.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade</param>
		/// <param name="ascending">Direção do ordenamento.</param>
		public PropertySortDirection(string propertyName, bool ascending)
		{
			this.propertyName = propertyName;
			this.ascending = ascending;
		}
	}

}