using LMS.DATA.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.REPOSITORIES.Interfaces
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {

        Task<IdentityResult> AddTokenExpiration(ApplicationUser user, string tokenType);
        Task<bool> ValidateTokenExpires(ApplicationUser user);
        Task<bool> RemoveTokenExpiry(ApplicationUser user);
    }
}
