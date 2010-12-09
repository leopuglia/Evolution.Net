using System;

namespace EvolutionNet.Calendar.Holiday
{
	public class NationalHoliday : BaseHoliday
	{
		public NationalHoliday(DateTime date, string name) : base(date, name, HolidayType.NationalHoliday)
		{
		}

		public NationalHoliday(int year, int month, int day, string name) : base(year, month, day, name, HolidayType.NationalHoliday)
		{
		}
	}
}
