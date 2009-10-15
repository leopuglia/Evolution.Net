/*
using System;
using EvolutionNet.MVP.Core.Data.Access;

namespace EvolutionNet.MVP.Data.Access
{
	[Serializable]
	public abstract class AbstractBaseDao<IdT> : IDao<IdT>
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

		public abstract void Save();
	}
}
*/
