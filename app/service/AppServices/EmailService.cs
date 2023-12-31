
using Microsoft.Extensions.Options;
using service.contract.DTOs.Email;
using service.contract.IAppServices;
using System.Net;
using System.Net.Mail;

namespace service.AppServices
{
    public class EmailService : IEmailService
    {
        readonly SmtpConfigModel smtpConfig;
        private static SmtpClient GetSmtpClient(SmtpConfigModel smptConfig)
        {
            NetworkCredential networkCredential = new()
            {
                UserName = smptConfig.Account,
                Password = smptConfig.Password
            };
            SmtpClient smtp = new()
            {
                Host = smptConfig.Host,
                Port = smptConfig.Port,
                EnableSsl = smptConfig.UseSsl,
                Credentials = networkCredential
            };
            return smtp;

        }
        public EmailService(SmtpConfigModel smtpConfig)
        {
            this.smtpConfig = smtpConfig;
        }
        public MailMessage CreateMailMessage(string subject, string body, bool isHtml = true, params string[] receivers)
        {
            MailMessage mailMessage = new MailMessage()
            {
                Body = body,
                Subject = subject,
                IsBodyHtml = isHtml,
            };
            mailMessage.From = new MailAddress(smtpConfig.Account, smtpConfig.DisplayName);
            mailMessage.To.Add(string.Join(",", receivers));
            return mailMessage;
        }
        public MailMessage AttachFile(MailMessage mailMessage, byte[] fileBytes, string contentType = "application/pdf")
        {
            using var ms = new MemoryStream(fileBytes);
            Attachment attachment = new Attachment(ms, contentType: new System.Net.Mime.ContentType(contentType));
            return AttachFile(mailMessage, attachment);

        }
        public MailMessage AttachFile(MailMessage mailMessage, params Attachment[] attachments)
        {
            mailMessage.Attachments.Concat(attachments);
            return mailMessage;
        }
        public async Task SendMessage(MailMessage mailMessage)
        {
            using SmtpClient smtp = GetSmtpClient(smtpConfig);
            await smtp.SendMailAsync(mailMessage);

        }
    }
}
