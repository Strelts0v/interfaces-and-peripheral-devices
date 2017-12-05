using System;
using System.IO;
using System.Windows.Forms;

namespace Demo
{
    public class Logger
    {
        private static Logger _instance;

        private StreamWriter _writer;

        private static readonly string _logFilePath = "logs.txt";

        private Logger()
        {
            OpenLogFile(false);
        }

        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void Log(string logMessage)
        {
            if (_writer == null)
            {
                OpenLogFile(false);
            }

            try
            {
                _writer.WriteLine($"| {DateTime.Now} | : {logMessage}");
                CloseLogFile();
                OpenLogFile(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ReleaseLogFile()
        {
            CloseLogFile();
        }

        public void CleanUpLogFile()
        {
            File.WriteAllText(_logFilePath, string.Empty);
        }

        private void OpenLogFile(bool needToCleanUpFile)
        {
            if (needToCleanUpFile)
            {
                File.WriteAllText(_logFilePath, string.Empty);
            }
            try
            {
                _writer = File.AppendText(_logFilePath);
            } catch (Exception ex)
            {
                OpenLogFile(false);
            }
        }

        private void CloseLogFile()
        {
             _writer.Close();
            _writer = null;
        }
    }
}