using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class LogFileWatcher
    {
        private static EmailService _emailService;
        private static ConfigManager _configManager;

        private const int BytesPerKBytes = 1024;

        public LogFileWatcher(string filePath)
        {
            _emailService = EmailService.Instance;
            _configManager = new ConfigManager();

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
            var maxFileSize = int.Parse(_configManager.GetProperty(AppProperties.FileSizeProperty));
            if (file.Length / BytesPerKBytes >= maxFileSize)
            {
                _emailService.SendEmail();
            }
        }
    }
}
