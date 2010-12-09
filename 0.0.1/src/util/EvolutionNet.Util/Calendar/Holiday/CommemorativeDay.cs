using System;

namespace EvolutionNet.Util.Calendar.Holiday
{
	public class CommemorativeDay : BaseHoliday
	{
		public CommemorativeDay(DateTime date, string name) : base(date, name, HolidayType.CommemorativeDay)
		{
		}

		public CommemorativeDay(int year, int month, int day, string name) : base(year, month, day, name, HolidayType.CommemorativeDay)
		{
		}
	}
}
