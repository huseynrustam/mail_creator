using System;
using System.Net.Mail;
using System.Net;

namespace mail_creator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gmails = { "huseyn.test01@gmail.com", "rustamovhuseyn16@gmail.com","qurbanovferid688@gmail.com" };
            string FromMail = "thedotnetchannelsender22@gmail.com";
            string FromPassword = "lgioehkvchemfkrw";

            foreach (string gmail in gmails)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(FromMail);
                message.Subject = "test mail from workshop";
                message.To.Add(new MailAddress(gmail));
                message.Body = "workshop";

                // smtp configuration
                var SmtpClient = new SmtpClient("smtp.gmail.com");
                SmtpClient.Port = 587;
                SmtpClient.Credentials = new NetworkCredential(FromMail, FromPassword);
                SmtpClient.EnableSsl = true;

                try
                {
                    SmtpClient.Send(message);
                    Console.WriteLine($"Email sent successfully to {gmail}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email to {gmail}: {ex.Message}");
                }
            }
        }
    }
}
