using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Lib
{
    public static class EmailHandler
    {
        public static void SendEmail(NetworkCredential fromAddressCredential, string toEmailAddress, string emailSubject, string emailBody, bool isBodyHtml)
        {

            try
            {
                using (var smtp = new System.Net.Mail.SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";   // change as required
                    smtp.Port = 587;                // change as required
                    smtp.EnableSsl = false;         // change as required
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = fromAddressCredential;   //new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(fromAddressCredential.UserName);
                        mail.To.Add(new MailAddress(toEmailAddress));
                        mail.Subject = emailSubject;
                        mail.Body = emailBody;
                        mail.IsBodyHtml = isBodyHtml;

                        smtp.Send(mail);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
