using System;
using System.Collections.Generic;

namespace EvolutionNet.Calendar.Holiday.Country
{
	public abstract class BaseCountry
	{
		protected BaseCountry(int year)
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

		public static IList<NationalHoliday> ListNacionalHolidays(BaseCountry country)
		{
			return country.NationalHolidays;
		}

	}
}
