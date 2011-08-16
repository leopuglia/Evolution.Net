using System;
using System.ComponentModel;
using System.Web.UI;
using AttributeCollection = System.Web.UI.AttributeCollection;

namespace EvolutionNet.Util.Web.GoogleChart
{
	[ControlBuilderAttribute(typeof (DataPointControlBuilder)), ParseChildren(true, "Value"),
	 TypeConverter(typeof (ExpandableObjectConverter))]
	public class DataPoint : IStateManager, IParserAccessor, IAttributeAccessor
	{
		private AttributeCollection attribs;
		private string label;
		private bool labelIsDirty;
		private bool marked;
		private string value;
		private bool valueIsDirty;

		#region Constructors

		public DataPoint() : this(null, null)
		{
		}

		public DataPoint(string value) : this(value, null)
		{
		}

		public DataPoint(string value, string label)
		{
			Value = value;
			Label = label;
		}

		#endregion

		#region Properties

		[DefaultValue(""), PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
		public string Label
		{
			get
			{
				if (label != null)
					return label;
				return string.Empty;
			}
			set
			{
				label = value;

				if (((IStateManager) this).IsTrackingViewState)
				{
					labelIsDirty = true;
				}
			}
		}

		[DefaultValue(""), PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
		public string Value
		{
			get
			{
				if (value != null)
					return value;
				return string.Empty;
			}
			set
			{
				this.value = value;

				if (((IStateManager) this).IsTrackingViewState)
				{
					valueIsDirty = true;
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public AttributeCollection Attributes
		{
			get
			{
				if (attribs == null)
					attribs = new AttributeCollection(new StateBag(true));

				return attribs;
			}
		}

		internal bool Dirty
		{
			get { return valueIsDirty || labelIsDirty; }
			set
			{
				valueIsDirty = value;
				labelIsDirty = value;
			}
		}

		#endregion

		#region Methods

		internal void TrackViewState()
		{
			marked = true;
		}

		internal void LoadViewState(object state)
		{
			var stateData = state as string[];
			if (stateData != null)
			{
				if (stateData[0] != null)
					Label = stateData[0];
				if (stateData[1] != null)
					Value = stateData[1];
			}
		}

		internal object SaveViewState()
		{
			var state = new string[2];
			if (labelIsDirty)
				state[0] = Label;
			if (valueIsDirty)
				state[1] = Value;

			return state;
		}

		public override string ToString()
		{
			return Label;
		}

		public override bool Equals(object obj)
		{
			var gci = obj as DataPoint;
			if (gci == null)
				return false;
			return Label.Equals(gci.Label) && Value.Equals(gci.Value);
		}

		public override int GetHashCode()
		{
			// This code taken from the internal method System.Web.Util.HashCodeCombiner.CombineHashCodes
			return ((Value.GetHashCode() << 5) + Value.GetHashCode()) ^ Label.GetHashCode();
		}

		#endregion

		#region IAttributeAccessor Members

		string IAttributeAccessor.GetAttribute(string name)
		{
			return Attributes[name];
		}

		void IAttributeAccessor.SetAttribute(string name, string value)
		{
			Attributes[name] = value;
		}

		#endregion

		#region IParserAccessor Members

		void IParserAccessor.AddParsedSubObject(object obj)
		{
			if (obj is LiteralControl)
				Value = ((LiteralControl) obj).Text;
			else
				throw new FormatException(string.Format("Cannot parse input of type {0}. Expected Literal content.", obj.GetType()));
		}

		#endregion

		#region IStateManager Members

		bool IStateManager.IsTrackingViewState
		{
			get { return marked; }
		}

		void IStateManager.LoadViewState(object state)
		{
			LoadViewState(state);
		}

		object IStateManager.SaveViewState()
		{
			return SaveViewState();
		}

		void IStateManager.TrackViewState()
		{
			TrackViewState();
		}

		#endregion
	}


	public class DataPointControlBuilder : ControlBuilder
	{
		public override bool AllowWhitespaceLiterals()
		{
			return false;
		}


		public override bool HtmlDecodeLiterals()
		{
			// DataPoint text gets rendered as an encoded attribute value.

			// At parse time text specified as an attribute gets decoded, and so text specified as a
			// literal needs to go through the same process. 

			return true;
		}
	}
}