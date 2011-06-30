using System;
using System.Collections.Generic;
using System.Drawing;

namespace EvolutionNet.Util
{
	public class ConvertHelper
	{
		public static string IntToHex(int number)
		{
			return string.Format("{0:x}", number);
		}

		public static int HexToInt(string hexString)
		{
			if (hexString.Length == 1)
				hexString += hexString;

			return int.Parse(hexString,
							 System.Globalization.NumberStyles.HexNumber, null);
		}

		public static Color ColorFromHex(string hexa)
		{
			int i;
			int j;

			switch (hexa.Length)
			{
				case 3:
					i = 0;
					j = 1;
					break;
				case 4:
					i = 1;
					j = 1;
					break;
				case 6:
					i = 0;
					j = 2;
					break;
				case 7:
					i = 1;
					j = 2;
					break;
				default:
					throw new ArgumentOutOfRangeException("hexa", "The Hexadecimal string has a unsupported lenght");
			}

			int red = HexToInt(hexa.Substring(i, j));
			int green = HexToInt(hexa.Substring(i + 2, j));
			int blue = HexToInt(hexa.Substring(i + 4, j));

			return Color.FromArgb(red, green, blue);
		}

		public static int ArgbFromHex(string hexa)
		{
			int red = HexToInt(hexa.Substring(1, 2));
			int green = HexToInt(hexa.Substring(3, 2));
			int blue = HexToInt(hexa.Substring(5, 2));

			return Color.FromArgb(red, green, blue).ToArgb();
		}

		public static Color ColorFromArgb(string intArgb)
		{
			return Color.FromArgb(int.Parse(intArgb));
		}

		public static T GetFromString<T>(string strToConvert, T standardValue)
		{
			object ret = standardValue;
			if (strToConvert != null)
			{
				try
				{
					if (typeof(T) == typeof(bool))
						ret = bool.Parse(strToConvert);
					else if (typeof(T) == typeof(int))
						ret = int.Parse(strToConvert);
					else if (typeof(T).IsEnum)
						ret = Enum.Parse(typeof(T), strToConvert);
					else
						throw new NotImplementedException("Tipo para conversão não implementado!");
				}
				catch
				{
					return (T)ret;
				}
			}
			return (T)ret;
		}

		public static IList<T> ListEnumValues<T>()
		{
			List<T> list = new List<T>();
			foreach (string value in Enum.GetNames(typeof(T)))
			{
				T typedValue = (T)Enum.Parse(typeof(T), value);
				list.Add(typedValue);
			}

			return list;
		}

	}
}