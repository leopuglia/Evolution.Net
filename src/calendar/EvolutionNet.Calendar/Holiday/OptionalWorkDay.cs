using System;

namespace EvolutionNet.Calendar.Holiday
{
	public class OptionalLaborDay : BaseHoliday
	{
		public OptionalLaborDay(DateTime date, string name) : base(date, name, HolidayType.OptionalLaborDay)
		{
		}

		public OptionalLaborDay(int year, int month, int day, string name) : base(year, month, day, name, HolidayType.OptionalLaborDay)
		{
		}
	}
}
