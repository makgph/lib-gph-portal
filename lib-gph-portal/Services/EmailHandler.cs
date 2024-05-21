using System.Net.Mail;

namespace sa.gov.libgph.Services
{
    public class EmailHandler
    {
        public string EmailReceiver { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        public void SendEmail()
        {
            MailMessage Message = new MailMessage();
            SmtpClient client = new SmtpClient();

            Message.To.Add(new MailAddress(EmailReceiver));
            Message.Subject = EmailSubject;
            Message.Body = EmailBody;
            client.Send(Message);

        }
       

    }
}