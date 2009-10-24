/*
 * Created by: 
 * Created: terça-feira, 18 de dezembro de 2007
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EvolutionNet.MVP.Util
{
	/// <summary>
	/// Classe que define uma lista com generics dos tipos de seus elementos, mas que pode ser ordenada por controles visuais.
	/// </summary>
	/// <typeparam name="T">Tipo do elemento da lista</typeparam>
	public class SortableBindingList<T> : BindingList<T>
	{
		#region Private Variables

		private PropertyDescriptor propertyDescriptor;
		private ListSortDirection listSortDirection;
		private bool isSorted;

		#endregion

		#region Protected Properties

		protected override bool SupportsSortingCore
		{
			get { return true; }
		}

		protected override bool IsSortedCore
		{
			get { return isSorted; }
		}

		protected override PropertyDescriptor SortPropertyCore
		{
			get { return propertyDescriptor; }
		}

		protected override ListSortDirection SortDirectionCore
		{
			get { return listSortDirection; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Construtor da classe.
		/// </summary>
		public SortableBindingList()// : base()
		{
		}

		/// <summary>
		/// Construtor da classe com os dados iniciais.
		/// </summary>
		/// <param name="enumerable">Lista contendo os dados a serem adicionados inicialmente na classe</param>
		public SortableBindingList(IEnumerable<T> enumerable)// : this((IEnumerable)enumerable)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable", "The parameter cannot be null!");
			}

			AddRange(enumerable);
		}
		
//		public SortableBindingList(IEnumerable enumerable)
//		{
//			if (enumerable == null)
//			{
//				throw new ArgumentNullException("The parameter cannot be null!");
//			}
//
//			AddRange(enumerable);
//		}

		#endregion

		#region Public Methods

//		public void AddRange(IEnumerable enumerable)
//		{
//			foreach (T t in enumerable)
//			{
//				Add(t);
//			}
//		}

		/// <summary>
		/// Adiciona uma lista de elementos à lista atual.
		/// </summary>
		/// <param name="enumerable">Lista dos elementos a serem adicionados</param>
		public void AddRange(IEnumerable<T> enumerable)
		{
//			AddRange((IEnumerable) enumerable);
			foreach (T t in enumerable)
			{
				Add(t);
			}
		}
		
//		public void Sort(params string[] propertyNames)
//		{
//		}
		
		/// <summary>
		/// Realiza a ordenação por uma propriedade, ascendente.
		/// </summary>
		/// <param name="propertyName">Nome da propriedade de um elemento</param>
		public void Sort(string propertyName)
		{
			Sort(propertyName, true);
		}

		/// <summary>
		/// Realiza a ordenação por uma propriedade em uma direção (ascendente ou decrescente).
		/// </summary>
		/// <param name="propertyName">Nome da propriedade de um elemento</param>
		/// <param name="ascending">Direção do ordenamento (ascendente ou decrescente)</param>
		public void Sort(string propertyName, bool ascending)
		{
			Sort(new PropertySortDirection(propertyName, ascending));
		}

		/// <summary>
		/// Realiza a ordenação por uma propriedade em uma direção (ascendente ou decrescente).
		/// </summary>
		/// <param name="propertyDirection">Objeto contendo o descritor da propriedade e a direção do ordenamento</param>
		public void Sort(PropertySortDirection propertyDirection)
		{
			// Creates a new collection and assign it the properties for button1.
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

			// Sets an PropertyDescriptor to the specific property.
			PropertyDescriptor myProperty = properties.Find(propertyDirection.PropertyName, false);
			
			ApplySortCore(myProperty, propertyDirection.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
		}

		#endregion
		
		#region Protected Override Methods
		
		/// <summary>
		/// Realiza a ordenação por uma propriedade em uma direção (ascendente ou decrescente).
		/// </summary>
		/// <param name="prop">Descritor da propriedade</param>
		/// <param name="direction">Direção do ordenamento</param>
		protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
		{
			List<T> itemsList = (List<T>) Items;
			itemsList.Sort(delegate(T t1, T t2)
			{
				propertyDescriptor = prop;
				listSortDirection = direction;
				isSorted = true;

				int reverse = direction == ListSortDirection.Ascending ? 1 : -1;

				PropertyInfo propertyInfo = typeof(T).GetProperty(prop.Name);
				object value1 = propertyInfo.GetValue(t1, null);
				object value2 = propertyInfo.GetValue(t2, null);

				IComparable comparable = value1 as IComparable;
				if (comparable != null)
				{
					return reverse * comparable.CompareTo(value2);
				}
				else
				{
					comparable = value2 as IComparable;
					if (comparable != null)
					{
						return -1 * reverse * comparable.CompareTo(value1);
					}
					else
					{
						return 0;
					}
				}
			});

			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		/// <summary>
		/// Remove a ordenação aplicada.
		/// </summary>
		protected override void RemoveSortCore()
		{
			isSorted = false;
			propertyDescriptor = base.SortPropertyCore;
			listSortDirection = base.SortDirectionCore;
		}

		#endregion

	}
}