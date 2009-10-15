using System.Drawing;

namespace EvolutionNet.Util.Imaging
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

	}
}