using System.Configuration;

namespace Demo
{
    class ConfigManager
    {
        private static Configuration _configFile = ConfigurationManager
            .OpenExeConfiguration(ConfigurationUserLevel.None);

        private static KeyValueConfigurationCollection _settings = ConfigurationManager
            .OpenExeConfiguration(ConfigurationUserLevel.None)
            .AppSettings.Settings;

        private const string SharedSecret = "xxx123xxx";

        public static string GetProperty(string propertyName)
        {
            var encryptedResult = _settings[propertyName]?.Value;
            return encryptedResult == null 
                ? "Not found"
                : AesCryptographer.DecryptStringAes(encryptedResult, SharedSecret);
        }

        public static void SetProperty(string propertyName, string propertyValue)
        {
            var propertyEncodedValue = AesCryptographer.EncryptStringAes(propertyValue, SharedSecret);
            if (_settings[propertyName] == null)
            {
                _settings.Add(propertyName, propertyEncodedValue);
            }
            else
            {
                _settings[propertyName].Value = propertyEncodedValue;
            }
            _configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(_configFile.AppSettings.SectionInformation.Name);
        }

        public static void SetPropertyWithoutEncrypt(string propertyName, string propertyValue)
        {
            if (_settings[propertyName] == null)
            {
                _settings.Add(propertyName, propertyValue);
            }
            else
            {
                _settings[propertyName].Value = propertyValue;
            }
            _configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(_configFile.AppSettings.SectionInformation.Name);
        }
    }
}
