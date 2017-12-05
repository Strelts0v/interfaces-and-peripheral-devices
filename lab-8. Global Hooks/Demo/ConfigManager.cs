using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class ConfigManager
    {
        private const string SharedSecret = "xxx123xxx";

        public string GetProperty(string propertyName)
        {
            var propertyValue = Properties.Settings.Default[propertyName].ToString();
            return AesCryptographer.DecryptStringAes(propertyValue, SharedSecret);
        }

        public void SetProperty(string propertyName, string propertyValue)
        {
            var propertyEncodedValue = AesCryptographer.EncryptStringAes(propertyValue, SharedSecret);
            Console.WriteLine(propertyEncodedValue);
            Properties.Settings.Default[propertyName] = propertyEncodedValue;
            Properties.Settings.Default.Save();
        }
    }
}
