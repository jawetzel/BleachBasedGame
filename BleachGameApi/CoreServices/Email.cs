using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace CoreServices
{
    public static class Email
    {
        public static bool SendEmail(string email, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Spoken Past Auto Sender", "SpokenPastAutoMailer@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = body };
            using (var client = new SmtpClient())
            {//begin using
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTlsWhenAvailable);
                client.AuthenticationMechanisms.Remove("XOAUTH2"); // Must be removed for Gmail SMTP
                client.Authenticate("email@gmail.com",
                    "password");
                client.Send(emailMessage);
                client.Disconnect(true);
            }//end using
            return true;
        }
    }

}
