/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

/*
using System;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Core.Data.Access;

namespace EvolutionNet.MVP.Data.Access.ActiveRecord
{
	[Serializable]
	[ActiveRecord]
	public abstract class ARBaseDao<IdT> : ActiveRecordBase<ARBaseDao<IdT>>, IDao<IdT>
	{
		private IdT id = default(IdT);

		/// <summary>
		/// ID may be of type string, int, custom type, etc.
		/// </summary>
		[PrimaryKey]
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
	}
}
*/
