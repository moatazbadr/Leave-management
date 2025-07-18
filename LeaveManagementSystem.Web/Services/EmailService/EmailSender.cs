using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net.Mail;

namespace LeaveManagementSystem.Web.Services.EmailService
{
    public class EmailSender :IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var Email = _configuration["EmailSettings:DefaultEmailAddress"];
            var SMTPServer = _configuration["EmailSettings:Server"];
            int SMTPPort = Convert.ToInt32( _configuration["EmailSettings:Port"]);
            var message = new MailMessage()
            {
                From = new MailAddress(Email),
                Body=htmlMessage,
                Subject = subject,
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress(email));
            using var Client = new SmtpClient(SMTPServer, SMTPPort);
           await  Client.SendMailAsync(message); 
            

        }
    }
}
