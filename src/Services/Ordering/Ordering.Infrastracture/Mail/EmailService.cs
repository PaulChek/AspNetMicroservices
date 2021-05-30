using Microsoft.Extensions.Options;
using Ordering.App.Contracts.Infrastructure;
using Ordering.App.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.infrastructure.Mail {
    public class EmailService : IEmailService {
        private readonly EmailSettings _settings;


        public EmailService(IOptions<EmailSettings> settings) {
            _settings = settings.Value;
        }

        public async Task<bool> SendEmail(Email mail) {
            var client = new SendGridClient(_settings.ApiKey);
            var subject = mail.Subject;
            var to = new EmailAddress(mail.To);
            var emailBody = mail.Body;

            var from = new EmailAddress(_settings.FromAddress, _settings.FromName);

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            Console.WriteLine(response.IsSuccessStatusCode ? "Email Send" : "Error Email");

            return response.IsSuccessStatusCode;
        }
    }
}
