using System.Configuration;

namespace EvolutionNet.MVP.Core.Configuration
{
	public static class BaseConfiguration
	{
		public static void SaveAppSettings()
		{
			System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			config.AppSettings.Settings.Clear();
			foreach (string settingKey in ConfigurationManager.AppSettings.Keys)
			{
				string settingValue = ConfigurationManager.AppSettings[settingKey];
				if (settingValue != null)
					config.AppSettings.Settings.Add(settingKey, settingValue);
			}
			config.Save();
		}
	}
}