using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using SealGame.Core.Dto;
using SealGame.Core.ServiceInterface;

namespace SealGame.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {
        private readonly IConfiguration _configuration;

        public EmailsServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailDto dto)
        {
            var email = CreateEmail(dto.To, dto.Subject, dto.Body);
            SendEmailInternal(email);
        }

        public void SendEmailToken(EmailTokenDto dto, string token)
        {
            dto.Token = token;
            var email = CreateEmail(dto.To, dto.Subject, dto.Body);
            SendEmailInternal(email);
        }

        private MimeMessage CreateEmail(string recipient, string subject, string body)
        {
            var email = new MimeMessage();
            var emailUserName = _configuration["EmailSettings:EmailUserName"];
            email.From.Add(MailboxAddress.Parse(emailUserName));
            email.To.Add(MailboxAddress.Parse(recipient));
            email.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = body
            };
            email.Body = builder.ToMessageBody();

            return email;
        }

        private void SendEmailInternal(MimeMessage email)
        {
            var emailHost = _configuration["EmailSettings:EmailHost"];
            var emailPassword = _configuration["EmailSettings:EmailPassword"];
            var emailUserName = _configuration["EmailSettings:EmailUserName"];

            using var smtp = new SmtpClient();
            smtp.Connect(emailHost, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(emailUserName, emailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}