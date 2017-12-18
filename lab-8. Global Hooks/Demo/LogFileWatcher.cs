using System;
using System.IO;

namespace Demo
{
    class LogFileWatcher
    {
        private const int BytesPerKBytes = 1024;
        private const int DefaultMaxFileSize = 10 * 1024;

        private static readonly string SharedSecret = "xxx123xxx";

        public LogFileWatcher(string filePath)
        {
            var watcher = new FileSystemWatcher
            {
                Path = filePath,
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "*.txt"
            };

            watcher.Changed += OnFileChanged;

            watcher.EnableRaisingEvents = true;
        }

        private static void OnFileChanged(object source, FileSystemEventArgs e)
        {
            var file = new FileInfo(e.FullPath);
            var maxFileSize = DefaultMaxFileSize;
            try
            {
                maxFileSize = int.Parse(ConfigManager.GetProperty(AppProperties.FileSizeProperty));
                if (maxFileSize <= 0)
                {
                    maxFileSize = int.Parse(AesCryptographer
                        .DecryptStringAes(AppProperties.FileSizePropertyDefaultValue, SharedSecret));
                }
            }
            catch (FormatException)
            {}

            if (file.Length / BytesPerKBytes >= maxFileSize)
            {
                EmailService.SendEmail();
            }
        }
    }
}
