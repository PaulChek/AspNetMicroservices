using Application.Contracts_Interfaces;
using Application.Model;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Mail {
    public class EmailService : IEmailService {
        private EmailSettings _settings { get; }

        public EmailService(IOptions<EmailSettings> settings) {
            _settings = settings.Value;
        }

        public async Task<bool> SendMail(IEmail email) {

            var client = new SendGridClient(_settings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress {
                Email = _settings.FromAddress,
                Name = _settings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            Console.WriteLine("Email sent.");

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            Console.WriteLine("Email sending failed.");
            return false;
        }
    }
}
