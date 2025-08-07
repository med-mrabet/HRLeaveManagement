using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSetting { get; }

        public EmailSender(IOptions<EmailSettings> emailSetting)
        {
            this._emailSetting = emailSetting.Value;
        }
        public async Task<bool> SendEmailAsync(EmailMessage email)
        {
            var sendGridClient = new SendGridClient(_emailSetting.ApiKey);
            var to  = new EmailAddress(email.To);
            var from = new EmailAddress(_emailSetting.FromEmail, _emailSetting.FromName);
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await sendGridClient.SendEmailAsync(message);
            return response.IsSuccessStatusCode;


        }
    }
}
