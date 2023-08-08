using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.REPOSITORIES.Interfaces;
using LMS.SERVICES.Intefaces;
using SendGrid;
namespace LMS.SERVICES.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _IemailRepository;

        public EmailService(IEmailRepository emailRepository) => _IemailRepository = emailRepository;

        public async Task<Response> InvitationEmail(string inviter, string userName, string emailTo, string token) => await _IemailRepository.InvitationEmail(inviter, userName, emailTo, token);

        public async Task<Response> EmailVerification(string firstName, string email, string token) => await _IemailRepository.EmailVerification(firstName, email, token);
        public async Task<Response> ForgetPassword(string userName, string email, string token) => await _IemailRepository.ForgetPassword(userName, email, token);
        public async Task<Response> ForgetUserName(string userName, string email, string name) => await _IemailRepository.ForgetUserName(userName, email, name);
    }
}
