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
}
