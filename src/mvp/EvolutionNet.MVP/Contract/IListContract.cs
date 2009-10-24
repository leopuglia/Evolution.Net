namespace EvolutionNet.MVP.Contract
{
	public interface IListContract : IBaseContract
	{
		/// <summary>
		/// Lista todos os elementos do model
		/// </summary>
		void FindAll();

	}
}