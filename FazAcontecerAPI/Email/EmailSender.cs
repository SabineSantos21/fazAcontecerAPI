using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Net.Mail;

namespace FazAcontecerAPI.Models
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string emails, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress("Faz Acontecer", "fazacontecerAPP@outlook.com"));

                foreach (var email in emails.Split(';'))
                {
                    mimeMessage.To.Add(new MailboxAddress(email));
                }

                mimeMessage.Subject = subject;

                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);

                    await client.AuthenticateAsync("fazacontecerAPP@outlook.com", "fazacontecer2023");

                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task SendEmailAsync(string emails, string subject, string message, string attachments)
        {
            try
            {
                var mimeMessage = new MimeMessage();

                mimeMessage.From.Add(new MailboxAddress("Faz Acontecer", "fazacontecerAPP@outlook.com"));

                foreach (var email in emails.Split(';'))
                {
                    mimeMessage.To.Add(new MailboxAddress(email));
                }

                mimeMessage.Subject = subject;

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = message;

                foreach (string attachment in attachments.Split(';'))
                {
                    bodyBuilder.Attachments.Add(@attachment);
                }

                mimeMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);

                    await client.AuthenticateAsync("fazacontecerAPP@outlook.com", "fazacontecer2023");

                    await client.SendAsync(mimeMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }

}
