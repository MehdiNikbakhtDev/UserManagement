using Core.Services;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Helper;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Email
{
    public class SmtpEmailService : IEmailService
    {
        private readonly AppSettingsHelper _appSettings;

        public SmtpEmailService(IOptions<AppSettingsHelper> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public async Task SendEmailAsync(string to, string body)
        {
            var fromAddress = new MailAddress(_appSettings.EmailAddress, "Einladung System");
            var toAddress = new MailAddress(to, "");
            string fromPassword = _appSettings.EmailPassword;
            string subject = _appSettings.EmailSubject;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}
