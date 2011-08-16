using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;

namespace EvolutionNet.Util.Web.GoogleChart
{
	[ToolboxItem(false)]
	public class DataPointCollection : StateManagedCollection
	{
		public DataPoint this[int index]
		{
			get { return ((IList) this)[index] as DataPoint; }
		}

		/// <summary>
		/// Returns a Boolean value indicating whether the data being plotted has any associated labels.
		/// </summary>
		public bool HasLabels
		{
			get
			{
				for (int i = 0; i < Count; i++)
					if (!string.IsNullOrEmpty(this[i].Label))
						return true;

				// If we reach here, no Labels found
				return false;
			}
		}

		public decimal MaximumValue
		{
			get
			{
				decimal maxValue = decimal.MinValue;

				for (int i = 0; i < Count; i++)
				{
					decimal valueAsDecimal = Convert.ToDecimal(this[i].Value);

					if (valueAsDecimal > maxValue)
						maxValue = valueAsDecimal;
				}

				if (maxValue == decimal.MinValue)
					maxValue = 0M;

				return maxValue;
			}
		}

		public string RenderRelativeCHDValues(int decimalPlaces)
		{
			if (decimalPlaces < 0 || decimalPlaces > 5)
				decimalPlaces = 2;

			if (Count == 0)
				return string.Empty;
			if (Count == 1)
				return "100";

			// Determine the maximum data point value
			decimal maxValue = MaximumValue;

			// Now compute the relative values
			string formatString = string.Concat("N", decimalPlaces);
			var formattedRelativeValues = new List<string>(Count);
			for (int i = 0; i < Count; i++)
			{
				decimal litValue = Convert.ToDecimal(this[i].Value);
				decimal relValue = 0M;
				if (maxValue != 0)
					relValue = (litValue/maxValue)*100M;

				formattedRelativeValues.Add(HttpUtility.UrlEncode(relValue.ToString(formatString)));
			}

			// Finally, return the formatted results
			return string.Join(",", formattedRelativeValues.ToArray());
		}

		public string RenderLabelValues()
		{
			var labelValues = new List<string>(Count);

			for (int i = 0; i < Count; i++)
				labelValues.Add(HttpUtility.UrlEncode(this[i].Label));

			return string.Join("|", labelValues.ToArray());
		}

		public void Add(DataPoint dataPoint)
		{
			((IList) this).Add(dataPoint);
		}

		public bool Contains(DataPoint dataPoint)
		{
			return ((IList) this).Contains(dataPoint);
		}

		public int IndexOf(DataPoint dataPoint)
		{
			return ((IList) this).IndexOf(dataPoint);
		}

		public void Insert(int index, DataPoint dataPoint)
		{
			((IList) this).Insert(index, dataPoint);
		}

		public void RemoveAt(int index)
		{
			((IList) this).RemoveAt(index);
		}

		public void Remove(DataPoint dataPoint)
		{
			((IList) this).Remove(dataPoint);
		}

		protected override void SetDirtyObject(object o)
		{
			((DataPoint) o).Dirty = true;
		}
	}
}
