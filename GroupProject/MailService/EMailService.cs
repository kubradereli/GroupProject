using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using System.Configuration;
using MimeKit;
using System;
using MailKit.Security;

namespace GroupProject.MailService
{
    public class EMailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EMailService()
        {
            _emailConfig = new EmailConfiguration()
            {
                From= "aleynaebrt@gmail.com",
                SmtpServer= "smtp.gmail.com",
                Port= 587,
                UserName = "aleynaebrt@gmail.com",
                Password = "A15766434.b"
            };
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    var x = client.IsSecure;
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    throw ex;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
