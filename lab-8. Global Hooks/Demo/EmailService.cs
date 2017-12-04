using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    class EmailService
    {
        private static EmailService _instance;

        private Logger _logger;

        private EmailService()
        {
            _logger = Logger.Instance;
        }

        public static EmailService Instance => _instance ?? (_instance = new EmailService());

        public void SendEmail()
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(Properties.Settings.Default.EmailAddressFrom);
                mail.To.Add(Properties.Settings.Default.EmailAddressTo);
                mail.Subject = "Global Hooks. Logs";
                mail.Body = "Log file:";

                _logger.ReleaseLogFile();

                var attachment = new Attachment("logs.txt");
                mail.Attachments.Add(attachment);

                smtpServer.Credentials = new System.Net.NetworkCredential(
                    Properties.Settings.Default.EmailAddressFrom,
                    Properties.Settings.Default.Password);

                smtpServer.Port = 587;
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                attachment.Dispose();
                _logger.CleanUpLogFile();
                MessageBox.Show(@"Mail was sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
