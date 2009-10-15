using System;

namespace EvolutionNet.Util.Calendar
{
	public struct Period
	{
		private DateTime start;
		private DateTime end;

		public Period(DateTime start, DateTime end)
		{
			this.start = start;
			this.end = end;
		}

		public DateTime Start
		{
			get { return start; }
			set { start = value; }
		}

		public DateTime End
		{
			get { return end; }
			set { end = value; }
		}

		public TimeSpan Span
		{
			get { return end - start; }
		}

		//TODO: Adicionar mais algumas funções pra facilitar, tipo Add no final, Add no inicio, etc
	}
}
