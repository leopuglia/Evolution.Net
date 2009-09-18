using System;
using System.Globalization;

namespace EvolutionNet.Calendar
{
	public class Month
	{
		public static DateTime DateFromWeekday(int year, int month, DayOfWeek dayOfWeek, int position)
		{
			int numDays = CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(year, month);
			int pos = 1;
			DateTime date;
			for (int i = 1; i <= numDays; i++)
			{
				date = new DateTime(year, month, i);
				if (date.DayOfWeek == dayOfWeek)
				{
					pos++;
					if (pos == position)
						return date;
				}
			}

			throw new ArgumentOutOfRangeException("position", string.Format("The position {0} doesn't exist on that month", position));
		}

		public static DateTime DateFromWeekdayByEnd(int year, int month, DayOfWeek dayOfWeek, int position)
		{
			int numDays = CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(year, month);
			int pos = 1;
			DateTime date;
			for (int i = numDays; i >= 1; i--)
			{
				date = new DateTime(year, month, i);
				if (date.DayOfWeek == dayOfWeek)
				{
					pos++;
					if (pos == position)
						return date;
				}
			}

			throw new ArgumentOutOfRangeException("position", string.Format("The position {0} doesn't exist on that month", position));
		}
	}
}
