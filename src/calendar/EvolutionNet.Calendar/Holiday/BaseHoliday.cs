using System;

namespace EvolutionNet.Calendar.Holiday
{
	public abstract class BaseHoliday
	{
		private DateTime date;
		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private HolidayType type;
		public HolidayType Type
		{
			get { return type; }
			set { type = value; }
		}

		protected BaseHoliday(DateTime date, string name, HolidayType type)
		{
			Date = date;
			Name = name;
			Type = type;
		}

		protected BaseHoliday(int year, int month, int day, string name, HolidayType type)
		{
			Date = new DateTime(year, month, day);
			Name = name;
			Type = type;
		}
	}
}
