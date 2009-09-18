using System;

namespace EvolutionNet.Calendar.Holiday
{
	public class NationalHolidayAlias : BaseHoliday
	{
		public NationalHolidayAlias(DateTime date, string name) : base(date, name, HolidayType.NationalHolidayAlias)
		{
		}

		public NationalHolidayAlias(int year, int month, int day, string name) : base(year, month, day, name, HolidayType.NationalHolidayAlias)
		{
		}
	}
}
