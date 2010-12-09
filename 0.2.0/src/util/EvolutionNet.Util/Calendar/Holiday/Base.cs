using System.Collections;
using System.Collections.Generic;

namespace EvolutionNet.Util.Calendar.Holiday
{
	public abstract class Base
	{
		protected Base(int year)
		{
			Year = year;
		}

		private int year;
		public int Year
		{
			get { return year; }
			set { year = value; }
		}

		public abstract IList<NationalHoliday> NationalHolidays { get; }
		public abstract IList<BaseHoliday> Holidays { get; }

/*
		public static IList<NationalHoliday> ListNationalHolidays(BaseCountry country)
		{
			return country.NationalHolidays;
		}

		public static IList<NationalHoliday> ListHolidays(BaseCountry country)
		{
			return country.Holidays;
		}
*/

		//TODO: Move this method from here o a util class
		public static IList<T> ConvertListTo<T>(IEnumerable list)
		{
			IList<T> listNew = new List<T>();
			foreach (object e in list)
			{
				listNew.Add((T)e);
			}

			return listNew;
		}

	}
}
