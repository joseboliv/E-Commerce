namespace Utilities.EmailSender
{
    using Utilities.EmailSender.Models;
    using Microsoft.Extensions.Options;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;

    public class EmailSender : IEmailSender
    {
        public EmailSettings EmailSettings { get; }

        public EmailSender(IOptions<EmailSettings> mailSettings)
        {
            this.EmailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequestModel model)
        {
            if (model.ToEmails.Count == 0) return;

            MailMessage mail = new() { From = new MailAddress(EmailSettings.Mail, EmailSettings.DisplayName, Encoding.UTF8) };

            model.ToEmails.ForEach(to =>
            {
                mail.To.Add(new MailAddress(to));
            });

            if (model.Attachments != null)
            {
                byte[] fileBytes;
                model.Attachments.ForEach(file =>
                {
                    if (file.Length > 0)
                    {
                        using MemoryStream ms = new();
                        file.CopyToAsync(ms);
                        fileBytes = ms.ToArray();
                        Attachment data = new(ms, MediaTypeNames.Application.Octet);
                        mail.Attachments.Add(data);
                    }
                });
            }

            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            using SmtpClient smtp = new(EmailSettings.Mail);
            smtp.Host = EmailSettings.Host;
            smtp.Credentials = new NetworkCredential(EmailSettings.Mail, EmailSettings.Password);
            smtp.Port = EmailSettings.Port;
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
            smtp.Dispose();
        }
    }
}
