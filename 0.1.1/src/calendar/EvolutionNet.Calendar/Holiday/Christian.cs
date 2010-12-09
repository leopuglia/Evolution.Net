using System;

namespace EvolutionNet.Calendar.Holiday
{
	public static class Christian
	{
		public static DateTime GetCarnivalTuesdayDate(int year)
		{
			// Para calcular a Terça-feira de Carnaval basta subtrair 47 dias do Domingo de Páscoa.
			return GetEasterSundayDate(year).AddDays(-47);
		}

		public static DateTime GetMardiGrasDate(int year)
		{
			return GetCarnivalTuesdayDate(year);
		}

		public static DateTime GetAshWednesdayDate(int year)
		{
			return GetEasterSundayDate(year).AddDays(-46);
		}

		public static DateTime GetHolyFridayDate(int year)
		{
			// Para calcular a Terça-feira de Carnaval basta subtrair 47 dias do Domingo de Páscoa.
			return GetEasterSundayDate(year).AddDays(-2);
		}

		public static Period GetHolyWeekDate(int year)
		{
			return new Period(GetEasterSundayDate(year).AddDays(-8), GetEasterSundayDate(year).AddDays(-1));
		}

		// Calcula o domingo de páscoa segundo a fórmula de gauss
		public static DateTime GetEasterSundayByGaussDate(int year)
		{
			int day, month;

			int x, y;
			if (year < 1582)
				throw new ArgumentOutOfRangeException("year", "Year must be bigger or equal to 1582");
			if (year < 1600)
			{
				x = 22;
				y = 2;
			}
			else if (year < 1700)
			{
				x = 22;
				y = 2;
			}
			else if (year < 1800)
			{
				x = 23;
				y = 3;
			}
			else if (year < 1900)
			{
				x = 24;
				y = 4;
			}
			else if (year < 2000)
			{
				x = 24;
				y = 5;
			}
			else if (year < 2100)
			{
				x = 24;
				y = 5;
			}
			else if (year < 2200)
			{
				x = 24;
				y = 6;
			}
			else if (year < 2300)
			{
				x = 25;
				y = 7;
			}
			else
				throw new ArgumentOutOfRangeException("year", "Year must be smaller then 2300");

			int a = year % 19;
			int b = year % 4;
			int c = year % 7;
			int d = (19 * a + x) % 30;
			int e = (2 * b + 4 * c + 6 * d + y) % 7;

			if ((d + e) > 9)
			{
				day = d + e - 9;
				month = 4;
			}
			else
			{
				day = d + e + 22;
				month = 3;
			}

			if (month == 4)
				if (day == 26)
					day = 19;
				else if (day == 25 && d == 28 && a > 10)
					day = 18;

			return new DateTime(year, month, day);
		}

		/*
		a = MOD(ANO;19)
		b = ANO \ 100
		c = MOD(ANO;100)
		d = b \ 4
		e = MOD(b;4)
		f = (b + 8) \ 25
		g = (b - f + 1) \ 3
		h = MOD((19 × a + b - d - g + 15);30)
		i = c \ 4
		k = MOD(c;4)
		L = MOD((32 + 2 × e + 2 × i - h - k);7)
		m = (a + 11 × h + 22 × L) \ 451
		MÊS = (h + L - 7 × m + 114) \ 31
		DIA = MOD((h + L - 7 × m + 114);31) + 1
		*/
		// Algoritmo de Meeus/Jones/Butcher
		public static DateTime GetEasterSundayDate(int year)
		{
			int a, b, c, d, e, f, g, h, i, j, k, l, month, day;

			a = year % 19;
			b = year / 100;
			c = year % 100;
			d = b / 4;
			e = b % 4;
			f = (b + 8) / 25;
			g = (b - f + 1) / 3;
			h = (19 * a + b - d - g + 15) % 30;
			i = c / 4;
			j = c % 4;
			k = (32 + 2 * e + 2 * i - h - j) % 7;
			l = (a + 11 * h + 22 * k) / 451;
			month = (h + k - 7 * l + 114) / 31;
			day = (h + k - 7 * l + 114) % 31 + 1;

			return new DateTime(year, month, day);
		}

		public static DateTime GetPentecostDate(int year)
		{
			return GetEasterSundayDate(year).AddDays(49);
		}

		public static DateTime GetCorpusChristiFridayDate(int year)
		{
			return GetEasterSundayDate(year).AddDays(60);
		}

		public static DateTime GetChristmasDayDate(int year)
		{
			return new DateTime(year, 12, 25);
		}

	}
}
