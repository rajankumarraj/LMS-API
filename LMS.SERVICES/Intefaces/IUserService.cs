using LMS.DATA.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SERVICES.Intefaces
{
    public  interface IUserService
    {
        Task<ApplicationUser> GetUserByUserName(string username);
        Task<int> GetComapnyIdByUserName(string username);
        Task<List<ApplicationUser>> GetUsersByCompanyIdId(int compaid, bool status);
        Task<IdentityResult> AddTokenExpiration(ApplicationUser user, string TokenType);
        Task<bool> ValidateTokenExpires(ApplicationUser user);
        Task<bool> RemoveTokenExpiry(ApplicationUser user);
    }
}
