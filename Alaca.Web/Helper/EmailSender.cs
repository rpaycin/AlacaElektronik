using System;
using System.Net;
using System.Net.Mail;

namespace Alaca.Web.Helper
{
    public sealed class EmailSender
    {
        public static void Send(string subject, string body, string toMailAddress)
        {
            string fromAddress = "test@gmail.com"; // todo : değişcek
            const string fromPassword = "şifre"; // todo : değişcek

            // TODO: açılacak olan gmail hesabı üzerinden email gönderim yapabilmek için https://www.google.com/settings/security/lesssecureapps linki açılır ve çıkan sayfada izin verilir

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(toMailAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}