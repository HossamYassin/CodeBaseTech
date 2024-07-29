using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IOptions<EmailSettings> _emailSettings;

        public EmailService(ILogger<EmailService> logger, IOptions<EmailSettings> emailSettings)
        {
            _logger = logger;
            _emailSettings = emailSettings;
        }

        public async Task<bool> SendEmailAsync(string subject, string body, string to)
        {
            string password = _emailSettings.Value.Password;

            using SmtpClient mail = new SmtpClient()
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = false,
                Host = _emailSettings.Value.SmtpServer,
                Port = _emailSettings. Value.Port,
                Credentials = new NetworkCredential(_emailSettings.Value.FromAddress, password)
            };
            MailAddress fromEmail;
            MailAddress toEmail;
            MailMessage msg;

            try
            {

                fromEmail = new MailAddress(_emailSettings.Value.FromAddress);
                toEmail = new MailAddress(to);

                msg = new MailMessage(fromEmail, toEmail);
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                await mail.SendMailAsync(msg);
                _logger.LogInformation($"Sending email to {to} from {_emailSettings.Value.FromAddress} with subject {subject}.");
                return true;
            }
            catch (SmtpException e)
            {
                _logger.LogError(e, $"from: {_emailSettings.Value.FromAddress}, to: {to}");
                return false;
            }
        }

    }

}
