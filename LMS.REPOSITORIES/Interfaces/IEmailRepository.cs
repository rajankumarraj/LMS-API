using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.REPOSITORIES.Interfaces
{
    public interface IEmailRepository
    {
        Task<Response> InvitationEmail(string inviter, string userName, string email, string token);
        Task<Response> EmailVerification(string firstName, string email, string verificationLink);
        Task<Response> ForgetPassword(string userName, string email, string token);
        Task<Response> ForgetUserName(string userName, string email, string name);
    }
}
