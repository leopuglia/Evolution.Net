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
			return int.Parse(hexString,
							 System.Globalization.NumberStyles.HexNumber, null);
		}

		public static Color ColorFromHexadecimal(string hexa)
		{
			int red = HexToInt(hexa.Substring(1, 2));
			int green = HexToInt(hexa.Substring(3, 2));
			int blue = HexToInt(hexa.Substring(5, 2));

			return Color.FromArgb(red, green, blue);
		}

		public static int ArgbFromHexadecimal(string hexa)
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
			var list = new List<T>();
			foreach (var value in Enum.GetNames(typeof(T)))
			{
				var typedValue = (T)Enum.Parse(typeof(T), value);
				list.Add(typedValue);
			}

			return list;
		}

	}
}