/*
using System;
using EvolutionNet.MVP.Core.Data.Definition;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class BaseModel<IdT> : IModel<IdT>
	{
		private IdT id = default(IdT);
		
		/// <summary>
		/// ID may be of type string, int, custom type, etc.
		/// </summary>
		public virtual IdT ID
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// Transient objects are not associated with an item already in storage.  For instance,
		/// a User is transient if its ID is 0.
		/// </summary>
		public bool IsTransient
		{
			get 
			{
				return ID == null || ID.Equals(default(IdT));
			}
		}

		//TODO: Acho que este construtor que estava gerando o problema de LazyInitializeException
//		public BaseModel() : base()
//		{
//			// Instancia todas as propriedades que são TO's
//			foreach(PropertyInfo propInfo in GetType().GetProperties())
//			{
//				Type type = propInfo.PropertyType;
//				if (propInfo.GetValue(this, null) == null && type.GetInterface(typeof(IModel<>).FullName) != null)
//					propInfo.SetValue(this, Activator.CreateInstance(propInfo.PropertyType), null);
//			}
//		}
	}
}
*/
