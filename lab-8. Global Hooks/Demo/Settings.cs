using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Settings
    {
        public string IsHiddenAppMode { get; set; } 
            = AppProperties.IsHiddenAppModePropertyDefaultValue;

        public string EmailAddressFrom { get; set; } 
            = AppProperties.EmailAddressFromPropertyDefaultValue;

        public string Password { get; set; } 
            = AppProperties.PasswordPropertyDefaultValue;

        public string EmailAddressTo { get; set; } 
            = AppProperties.EmailAddressToPropertyDefaultValue;

        public string FileSize { get; set; }
            = AppProperties.FileSizePropertyDefaultValue;
    }
}
