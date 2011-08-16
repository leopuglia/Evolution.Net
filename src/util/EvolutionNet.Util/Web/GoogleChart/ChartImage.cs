/*
 * CHANGES:
 * ========
 * 2008-12-16: Fixed a divide-by-zero error in DataPointCollection.RenderRelativeCHDValues when all data points equal zero.
 *			  (Thanks to Mike Strand for pointing out this error.)
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.Util.Web.GoogleChart
{
	public delegate void DataPointEventHandler(object sender, DataPointEventArgs e);

	[ParseChildren(true, "Items"), DefaultEvent("DataPointDataBound")]
	public class ChartImage : DataBoundControl
	{
		#region Private member variables and events

		private static readonly object EventDataPointDataBound = new object();
		private DataPointCollection items;

		#endregion

		#region Properties and Events

		[Category("Appearance"), DefaultValue(""), Bindable(true),
		 Description("Specifies the alternate text for the chart image.")]
		public virtual string AlternateText
		{
			get
			{
				var str = ViewState["AlternateText"] as string;
				if (str == null)
					return string.Empty;
				return str;
			}
			set { ViewState["AlternateText"] = value; }
		}

		[DefaultValue(false), Category("Accessibility"),
		 Description("Specifies whether an empty alternate text is generated if none is specified.")]
		public virtual bool GenerateEmptyAlternateText
		{
			get
			{
				object o = ViewState["GenerateEmptyAlternateText"];
				if (o == null)
					return false;
				return Convert.ToBoolean(o);
			}
			set { ViewState["GenerateEmptyAlternateText"] = value; }
		}

		[DefaultValue(""), Editor("System.Web.UI.Design.UrlEditor", typeof (UITypeEditor)), Category("Accessibility"),
		 Description("The URL containing a more detailed description of the image.")]
		public virtual string DescriptionUrl
		{
			get
			{
				var str = ViewState["DescriptionUrl"] as string;
				if (str == null)
					return string.Empty;
				return str;
			}
			set { ViewState["DescriptionUrl"] = value; }
		}

		[Category("Layout"), DefaultValue(ImageAlign.NotSet), Description("Specifies the alignment for the chart image.")]
		public virtual ImageAlign ImageAlign
		{
			get
			{
				object o = ViewState["ImageAlign"];
				if (o == null)
					return ImageAlign.NotSet;
				return (ImageAlign) o;
			}
			set { ViewState["ImageAlign"] = value; }
		}

		[Category("Appearance"), DefaultValue(typeof (Color), ""), TypeConverterAttribute(typeof (WebColorConverter)),
		 Description("The chart line color.")]
		public virtual Color LineColor
		{
			get
			{
				object o = ViewState["LineColor"];
				if (o == null)
					return Color.Empty;
				return (Color) o;
			}
			set { ViewState["LineColor"] = value; }
		}

		[Category("Appearance"), DefaultValue(typeof (Color), ""), TypeConverterAttribute(typeof (WebColorConverter)),
		 Description("The chart fill color.")]
		public virtual Color FillColor
		{
			get
			{
				object o = ViewState["FillColor"];
				if (o == null)
					return Color.Empty;
				return (Color) o;
			}
			set { ViewState["FillColor"] = value; }
		}

		[DefaultValue(false), Themeable(false), Category("Behavior"),
		 Description("Append data bound items to the statically declared items?")]
		public virtual bool AppendDataBoundItems
		{
			get
			{
				object o = ViewState["AppendDataBoundItems"];
				if (o == null)
					return false;
				return (bool) o;
			}
			set
			{
				ViewState["AppendDataBoundItems"] = value;

				if (Initialized)
					RequiresDataBinding = true;
			}
		}

		[Description("The URL for the Google Chart API (less the querystring)."),
		 DefaultValue("http://chart.apis.google.com/chart?"), Themeable(false), Category("Behavior")]
		protected virtual string UrlBase
		{
			get
			{
				var str = ViewState["GoogleChartUrlBase"] as string;
				if (str == null)
					return "http://chart.apis.google.com/chart?";
				return str;
			}
			set { ViewState["Title"] = value; }
		}

		[Description("The chart type."), DefaultValue(ChartTypes.LineChart), Themeable(true), Category("Appearance")]
		public virtual ChartTypes ChartType
		{
			get
			{
				object type = ViewState["ChartType"];
				if (type == null)
					return ChartTypes.LineChart;
				return (ChartTypes) type;
			}
			set { ViewState["ChartType"] = value; }
		}

		protected override HtmlTextWriterTag TagKey
		{
			get { return HtmlTextWriterTag.Img; }
		}

		[PersistenceMode(PersistenceMode.InnerDefaultProperty), Category("Default"),
		 Description("The collection of data points that make up the chart.")]
		public virtual DataPointCollection Items
		{
			get
			{
				if (items == null)
				{
					items = new DataPointCollection();

					if (IsTrackingViewState)
					{
						((IStateManager) items).TrackViewState();
					}
				}

				return items;
			}
		}

		[Description("The chart title."), DefaultValue(""), Themeable(true), Category("Appearance")]
		public virtual string ChartTitle
		{
			get
			{
				var str = ViewState["ChartTitle"] as string;
				if (str == null)
					return string.Empty;
				return str;
			}
			set { ViewState["ChartTitle"] = value; }
		}

		[Description("The item in the data source that provides the label text."), DefaultValue(""), Themeable(false),
		 Category("Data")]
		public virtual string DataLabelField
		{
			get
			{
				var str = ViewState["DataLabelField"] as string;
				if (str == null)
					return string.Empty;
				return str;
			}
			set
			{
				ViewState["DataLabelField"] = value;

				if (Initialized)
					RequiresDataBinding = true;
			}
		}

		[Description("The format string for the label text."), DefaultValue(""), Themeable(false), Category("Data")]
		public virtual string DataLabelFormatString
		{
			get
			{
				var str = ViewState["DataLabelFormatString"] as string;
				if (str == null)
					return string.Empty;
				return str;
			}
			set
			{
				ViewState["DataLabelFormatString"] = value;

				if (Initialized)
					RequiresDataBinding = true;
			}
		}

		[Description("The item in the data source that provides the value."), DefaultValue(""), Themeable(false),
		 Category("Data")]
		public virtual string DataValueField
		{
			get
			{
				var str = ViewState["DataValueField"] as string;
				if (str == null)
					return string.Empty;
				return str;
			}
			set
			{
				ViewState["DataValueField"] = value;

				if (Initialized)
					RequiresDataBinding = true;
			}
		}

		public event DataPointEventHandler DataPointDataBound
		{
			add { Events.AddHandler(EventDataPointDataBound, value); }
			remove { Events.RemoveHandler(EventDataPointDataBound, value); }
		}

		#region Properties meaningless for Images - hidden from the Toolbox

		[Browsable(false), EditorBrowsableAttribute(EditorBrowsableState.Never),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override FontInfo Font
		{
			get { return base.Font; }
		}

		[Browsable(false), EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public override bool Enabled
		{
			get { return base.Enabled; }
			set { base.Enabled = value; }
		}

		#endregion

		#endregion

		#region Methods

		protected override void PerformDataBinding(IEnumerable data)
		{
			if (DesignMode == false)
			{
				base.PerformDataBinding(data);

				if (AppendDataBoundItems == false)
					Items.Clear();

				foreach (object point in data)
				{
					var item = new DataPoint();

					if (DataLabelField.Length > 0 || DataValueField.Length > 0)
					{
						if (DataLabelField.Length > 0)
							item.Label = DataBinder.GetPropertyValue(point, DataLabelField, DataLabelFormatString);
						if (DataValueField.Length > 0)
						{
							var propertyValue = DataBinder.GetPropertyValue(point, DataValueField);

							item.Value = propertyValue != null ? propertyValue.ToString() : "";
						}
					}
					else
					{
						item.Value = point.ToString();
					}

					OnDataPointDataBound(new DataPointEventArgs(item));

					Items.Add(item);
				}
			}
		}

		protected virtual void OnDataPointDataBound(DataPointEventArgs e)
		{
			var handler = (DataPointEventHandler) Events[EventDataPointDataBound];

			if (handler != null)
				handler(this, e);
		}

		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			base.AddAttributesToRender(writer);

			writer.AddAttribute(HtmlTextWriterAttribute.Src, CreateChartUrl());

			if (DescriptionUrl.Length > 0)
				writer.AddAttribute(HtmlTextWriterAttribute.Longdesc, ResolveClientUrl(DescriptionUrl));

			if (AlternateText.Length > 0 || GenerateEmptyAlternateText)
				writer.AddAttribute(HtmlTextWriterAttribute.Alt, AlternateText);

			if (ImageAlign != ImageAlign.NotSet)
			{
				string imageAlignValue;

				switch (ImageAlign)
				{
					case ImageAlign.Left:
						imageAlignValue = "left";
						break;
					case ImageAlign.Right:
						imageAlignValue = "right";
						break;
					case ImageAlign.Baseline:
						imageAlignValue = "baseline";
						break;
					case ImageAlign.Top:
						imageAlignValue = "top";
						break;
					case ImageAlign.Middle:
						imageAlignValue = "middle";
						break;
					case ImageAlign.Bottom:
						imageAlignValue = "bottom";
						break;
					case ImageAlign.AbsBottom:
						imageAlignValue = "absbottom";
						break;
					case ImageAlign.AbsMiddle:
						imageAlignValue = "absmiddle";
						break;
					default:
						imageAlignValue = "texttop";
						break;
				}

				writer.AddAttribute(HtmlTextWriterAttribute.Align, imageAlignValue);
			}
		}

		protected virtual string CreateChartUrl()
		{
			var sb = new StringBuilder(500);

			Unit chartWidth = Width;
			Unit chartHeight = Height;

			if (chartWidth == Unit.Empty)
				chartWidth = Unit.Pixel(100);
			if (chartHeight == Unit.Empty)
				chartHeight = Unit.Pixel(100);

			// Add base Url
			sb.Append(UrlBase);

			// Add chart type
			sb.Append("cht=").Append(GetChartTypeCode(ChartType));

			// Specify chart height & width
			sb.AppendFormat("&chs={0}x{1}", chartWidth.Value, chartHeight.Value);

			// Add the title, if present
			if (!string.IsNullOrEmpty(ChartTitle))
				sb.Append("&chtt=").Append(HttpUtility.UrlEncode(ChartTitle));

			// Specify the line color
			if (LineColor != Color.Empty)
				sb.AppendFormat("&chco={0}", ColorToHexString(LineColor));

			// Specify the fill color
			if (FillColor != Color.Empty)
				sb.AppendFormat("&chm=B,{0},0,0,0", ColorToHexString(FillColor));

			if (DesignMode)
			{
				// Render dummy data...
				var dummyCHD = new string[10];
				var rnd = new Random();
				for (int i = 0; i < dummyCHD.Length; i++)
				{
					int randomPlotPoint = rnd.Next(80) + 20;
					dummyCHD[i] = HttpUtility.UrlEncode(randomPlotPoint.ToString());
				}

				sb.Append("&chd=t:").Append(string.Join(",", dummyCHD));
			}
			else
			{
				// Add the Y axis designation and X axis designation (if needed)
				if (Items.HasLabels)
					sb.Append("&chxt=y,x"); // Add X and Y axes
				else
					sb.Append("&chxt=y"); // Add just Y axis

				// Specify data
				sb.Append("&chd=t:").Append(Items.RenderRelativeCHDValues(2));

				// Specify the Y axis values
				sb.AppendFormat("&chxr=0,0,{0}", Items.MaximumValue);

				// Specify the X axis label values, if needed
				if (Items.HasLabels)
					sb.AppendFormat("&chxl=1:|{0}", Items.RenderLabelValues());
			}

			return sb.ToString();
		}

		/// <summary>
		/// Convert a .NET Color to a hex string.
		/// </summary>
		/// <remarks>Code created by Steve Lautenschlager, available online at:
		/// http://www.cambiaresearch.com/c4/24c09e15-2941-4ad2-8695-00b1b4029f4d/Convert-dotnet-Color-to-Hex-String.aspx</remarks>
		/// <returns>ex: "FFFFFF", "AB12E9"</returns>
		private string ColorToHexString(Color color)
		{
			char[] hexDigits = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

			var bytes = new byte[3];
			bytes[0] = color.R;
			bytes[1] = color.G;
			bytes[2] = color.B;
			var chars = new char[bytes.Length*2];
			for (int i = 0; i < bytes.Length; i++)
			{
				int b = bytes[i];
				chars[i*2] = hexDigits[b >> 4];
				chars[i*2 + 1] = hexDigits[b & 0xF];
			}
			return new string(chars);
		}


		protected virtual string GetChartTypeCode(ChartTypes ct)
		{
			switch (ct)
			{
				case ChartTypes.LineChart:
					return "lc";

				case ChartTypes.BarChart:
					return "bvs";

				case ChartTypes.PieChart:
					return "p";

				case ChartTypes.PieChart3d:
					return "p3";

				case ChartTypes.SparkLine:
					return "ls";

				default:
					throw new ArgumentException("Invalid ChartType selected.");
			}
		}

		#region State Maintenance Methods

		protected override void LoadViewState(object savedState)
		{
			var state = savedState as object[];

			if (state != null)
			{
				base.LoadViewState(state[0]);
				((IStateManager) Items).LoadViewState(state[1]);
			}
		}

		protected override object SaveViewState()
		{
			var state = new object[2];
			state[0] = base.SaveViewState();
			state[1] = ((IStateManager) Items).SaveViewState();

			return state;
		}

		protected override void TrackViewState()
		{
			base.TrackViewState();
			((IStateManager) Items).TrackViewState();
		}

		#endregion

		#endregion
	}
}