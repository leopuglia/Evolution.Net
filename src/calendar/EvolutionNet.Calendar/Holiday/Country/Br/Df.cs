using System;
using System.Collections.Generic;

namespace EvolutionNet.Calendar.Holiday.Country.Br
{
	public class Df : National
	{
		public Df(int year) : base(year)
		{
		}

		#region BrasiliaFoundationDay

		public StateHoliday BrasiliaFoundation
		{
			get { return GetBrasiliaFoundation(Year); }
		}

		public static StateHoliday GetBrasiliaFoundation(int year)
		{
			return new StateHoliday(GetBrasiliaFoundationDate(year), "Brasilia Foundation");
		}

		public static DateTime GetBrasiliaFoundationDate(int year)
		{
			return new DateTime(year, 4, 21);
		}

		#endregion

		#region ChristianDay

		public StateHoliday ChristianDay
		{
			get { return GetChristianDay(Year); }
		}

		public static StateHoliday GetChristianDay(int year)
		{
			return new StateHoliday(GetChristianDayDate(year), "Brasilia Foundation");
		}

		public static DateTime GetChristianDayDate(int year)
		{
			return new DateTime(year, 11, 30);
		}

		#endregion

		public IList<StateHoliday> StateHolidays
		{
			get
			{
				List<StateHoliday> list = new List<StateHoliday>(
					new StateHoliday[]
						{
							BrasiliaFoundation,
							ChristianDay
						});

				return list;
			}
		}

		public override IList<BaseHoliday> Holidays
		{
			get
			{
				List<BaseHoliday> list = new List<BaseHoliday>();
				list.AddRange(ConvertListTo<BaseHoliday>(NationalHolidays));
				list.AddRange(ConvertListTo<BaseHoliday>(StateHolidays));

				return list;
			}
		}

	}
}
