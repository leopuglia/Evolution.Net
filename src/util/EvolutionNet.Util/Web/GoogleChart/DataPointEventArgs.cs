using System;

namespace EvolutionNet.Util.Web.GoogleChart
{
	public class DataPointEventArgs : EventArgs
	{
		private readonly DataPoint _dataPoint;

		public DataPointEventArgs(DataPoint dataPoint)
		{
			_dataPoint = dataPoint;
		}

		public DataPoint DataPoint
		{
			get { return _dataPoint; }
		}
	}
}
