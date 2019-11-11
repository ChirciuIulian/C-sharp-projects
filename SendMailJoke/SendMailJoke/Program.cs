using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendMailJoke
{
    class Program
    {
        static void Main(string[] args)
        {
            SendSMTPMail(false, "catalin.moldovan@ro.ibm.com", "ionut.miron@ro.ibm.com", "Salut Catalin.", "Astazi este ultima mea zi in IBM, si as vrea sa te invit la un suc. Daca ai timp sa ne vedem.");
        }

        public static void SendSMTPMail(bool isHtml, string to, string from, string subject, string body, string[] cc = null, string[] bcc = null, string[] attachmentPath = null)
        {


            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = new SmtpClient();

            //set FROM field
            objMailMessage.From = new MailAddress(from);

            //set RECIPIENTS
            objMailMessage.To.Add(new MailAddress(to));

            //set CC
            if (cc != null)
                foreach (var s in cc)
                    objMailMessage.CC.Add(new MailAddress(s));

            //set BCC
            if (bcc != null)
                foreach (var s in bcc)
                    objMailMessage.Bcc.Add(new MailAddress(s));

            //set ATTACHMENTS
            if (attachmentPath != null)
                foreach (var s in attachmentPath)
                    objMailMessage.Attachments.Add(new Attachment(s));

            objMailMessage.Subject = subject;
            objMailMessage.IsBodyHtml = isHtml;
            objMailMessage.Body = body;
            objSmtpClient = new SmtpClient("emea.relay.ibm.com", 25);
            objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            objSmtpClient.Send(objMailMessage);

            objMailMessage.Dispose();
            objSmtpClient.Dispose();
        }

    }
}
