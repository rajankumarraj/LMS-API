using LMS.REPOSITORIES.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LMS.REPOSITORIES.Repositories
{
    public class EmailRepository : IEmailRepository
    {

        private readonly IConfiguration _configuration;
        private readonly string _sendgridKey;
        private readonly EmailAddress _fromEmailAddress;
        public EmailRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._sendgridKey = configuration["SendGrid:SendGrid-Dev-APIKey"];
            this._fromEmailAddress = new EmailAddress(configuration["SendGrid:From"], configuration["SendGrid:FromName"]);
        }

        public async Task<Response> EmailVerification(string firstName, string email, string token)
        {
            var sendGridClient = new SendGridClient(new HttpClient(), new SendGridClientOptions { ApiKey = _sendgridKey, HttpErrorAsException = true });
            string invitationLink = String.Format("{0}{1}{2}&email={3}", _configuration["EmailLinks:base-url"], _configuration["EmailLinks:admin-signup-email-verification"], token, email);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(_fromEmailAddress);
            sendGridMessage.AddTo(email);
            sendGridMessage.SetTemplateId("d-95f0f85042ca40b8a2a525f1b2f1f497");
            sendGridMessage.SetTemplateData(new
            {
                user = firstName,
                link = invitationLink
            });

            return await sendGridClient.SendEmailAsync(sendGridMessage);
        }

        public async Task<Response> InvitationEmail(string inviter, string userName, string email, string token)
        {
            var sendGridClient = new SendGridClient(new HttpClient(), new SendGridClientOptions { ApiKey = _sendgridKey, HttpErrorAsException = true });
            string invitationLink = String.Format("{0}{1}{2}&email={3}", _configuration["EmailLinks:base-url"], _configuration["EmailLinks:user-invitation"], token, email);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(_fromEmailAddress);
            sendGridMessage.AddTo(email);
            sendGridMessage.SetTemplateId("d-95f0f85042ca40b8a2a525f1b2f1f497");
            sendGridMessage.SetTemplateData(new
            {
                user = userName,
                inviter,
                link = invitationLink
            });

            return await sendGridClient.SendEmailAsync(sendGridMessage);
        }
        public async Task<Response> ForgetPassword(string userName, string email, string token)
        {
            var sendGridClient = new SendGridClient(new HttpClient(), new SendGridClientOptions { ApiKey = _sendgridKey, HttpErrorAsException = true });
            string invitationLink = String.Format("{0}{1}{2}&email={3}", _configuration["EmailLinks:base-url"], _configuration["EmailLinks:forget-password"], token, email);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(_fromEmailAddress);
            sendGridMessage.AddTo(email);
            sendGridMessage.SetTemplateId("d-95f0f85042ca40b8a2a525f1b2f1f497");
            sendGridMessage.SetTemplateData(new
            {
                UserName = userName,
                link = invitationLink
            });
            return await sendGridClient.SendEmailAsync(sendGridMessage);
        }
        public async Task<Response> ForgetUserName(string userName, string email, string name)
        {
            var sendGridClient = new SendGridClient(new HttpClient(), new SendGridClientOptions { ApiKey = _sendgridKey, HttpErrorAsException = true });
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(_fromEmailAddress);
            sendGridMessage.AddTo(email);
            sendGridMessage.SetTemplateId("d-95f0f85042ca40b8a2a525f1b2f1f497");
            sendGridMessage.SetTemplateData(new
            {
                userName,
                name
            });
            return await sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}
