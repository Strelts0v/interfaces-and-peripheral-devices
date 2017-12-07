using System.IO;

namespace Demo
{
    class LogFileWatcher
    {
        private const int BytesPerKBytes = 1024;

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
            var maxFileSize = int.Parse(ConfigManager.GetProperty(AppProperties.FileSizeProperty));
            if (file.Length / BytesPerKBytes >= maxFileSize)
            {
                EmailService.SendEmail();
            }
        }
    }
}
