using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace CustomFramework.EmailProvider
{
    public class EmailManager : IEmailManager
    {
        private readonly ILogger<EmailManager> _logger;
        private readonly EmailConfig _emailConfig;

        public EmailManager(ILogger<EmailManager> logger, EmailConfig emailConfig)
        {
            _logger = logger;
            _emailConfig = emailConfig;
        }

        public void SendEmail(string sender, IList<string> receiverList, string subject, string message)
        {
            try
            {
                var emailMessage = new MailMessage
                {
                    From = new MailAddress(sender),
                    Subject = subject,
                    Body = message,
                };

                foreach (var receiver in receiverList)
                {
                    emailMessage.To.Add(receiver);
                }

                var client = new SmtpClient
                {
                    Host = _emailConfig.MailServer,
                    Port = _emailConfig.MailServerPort,
                    EnableSsl = _emailConfig.EnableSsl,
                    UseDefaultCredentials = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(_emailConfig.Username, _emailConfig.Password)
                };

                client.Send(emailMessage);

            }
            catch (Exception e)
            {
                _logger.LogCritical(0, e, e.Message);
                throw;
            }
        }

    }
}