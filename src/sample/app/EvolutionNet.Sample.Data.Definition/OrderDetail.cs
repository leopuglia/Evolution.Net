namespace EvolutionNet.Sample.Data.Definition
{
	public partial class OrderDetail
	{
		public virtual OrderDetailKey ID
		{
			get
			{
				return OrderDetailKey;
			}
			set
			{
				OrderDetailKey = value;
			}
		}
	}
}