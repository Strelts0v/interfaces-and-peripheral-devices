using System;
using System.IO;
using Newtonsoft.Json;

namespace Demo
{
    class ConfigManager
    {
        private static readonly string SharedSecret = "xxx123xxx";

        private static Settings _settings;

        public static string GetProperty(string propertyName)
        {
            if (_settings == null)
            {
                _settings = GetSettings();
            }
            var encryptedValue = _settings.GetType().GetProperty(propertyName)
                ?.GetValue(_settings, null).ToString();
            return AesCryptographer.DecryptStringAes(encryptedValue, SharedSecret);
        }

        public static void SetProperty(string propertyName, string propertyValue)
        {
            if (_settings == null)
            {
                _settings = GetSettings();
            }

            var propertyEncodedValue = AesCryptographer.EncryptStringAes(propertyValue, SharedSecret);

            _settings.GetType().GetProperty(propertyName)
                ?.SetValue(_settings, propertyEncodedValue);

            SetSettings(_settings);
        }

        private static Settings GetSettings()
        {
            try
            {
                using (var streamReader = new StreamReader(@".\application.config"))
                {
                    return JsonConvert.DeserializeObject<Settings>(Decrypt(streamReader.ReadToEnd()));
                }
            }

            catch (Exception)
            {
                return new Settings();
            }
        }

        private static void SetSettings(Settings settings)
        {
            using (var streamWriter = new StreamWriter(@".\application.config", false))
            {
                streamWriter.Write(Encrypt(JsonConvert.SerializeObject(settings)));
            }
        }

        private static string Encrypt(string input)
        {
            return AesCryptographer.EncryptStringAes(input, SharedSecret);
        }

        private static string Decrypt(string input)
        {
            return AesCryptographer.DecryptStringAes(input, SharedSecret);
        }
    }

    /*private static Configuration _configFile = ConfigurationManager
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
    }*/
}
