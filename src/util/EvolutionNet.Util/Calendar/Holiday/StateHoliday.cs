using System;

namespace EvolutionNet.Util.Calendar.Holiday
{
	public class StateHoliday : BaseHoliday
	{
		public StateHoliday(DateTime date, string name) : base(date, name, HolidayType.StateHoliday)
		{
		}

		public StateHoliday(int year, int month, int day, string name) : base(year, month, day, name, HolidayType.StateHoliday)
		{
		}
	}
}