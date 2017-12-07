using System;
using System.IO;
using System.Windows.Forms;

namespace Demo
{
    public class Logger
    {
        private static StreamWriter _writer;

        private static readonly string _logFilePath = "logs.txt";

        public static void Log(string logMessage)
        {
            if (_writer == null)
            {
                OpenLogFile(false);
            }

            try
            {
                _writer?.WriteLine($"| {DateTime.Now} | : {logMessage}");
                CloseLogFile();
                OpenLogFile(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void ReleaseLogFile()
        {
            CloseLogFile();
        }

        public static void CleanUpLogFile()
        {
            File.WriteAllText(_logFilePath, string.Empty);
        }

        private static void OpenLogFile(bool needToCleanUpFile)
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

        private static void CloseLogFile()
        {
             _writer.Close();
            _writer = null;
        }
    }
}