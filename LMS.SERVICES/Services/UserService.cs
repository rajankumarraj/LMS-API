using LMS.DATA.Model;
using LMS.REPOSITORIES.Interfaces;
using LMS.SERVICES.Intefaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SERVICES.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        public UserService(UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<int> GetComapnyIdByUserName(string username)
        {
            var vUser = await _userManager.FindByNameAsync(username);
            return vUser.CompanyId;
        }

        public async Task<ApplicationUser> GetUserByUserName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<List<ApplicationUser>> GetUsersByCompanyIdId(int compId, bool status)
        {
            if (status)
                return await _userManager?.Users?.Where(u => u.CompanyId == compId && u.IsDeleted.Equals(false)).ToListAsync();
            else
                return await _userManager?.Users?.Where(u => u.CompanyId == compId && u.IsDeleted.Equals(true)).ToListAsync();
        }
        public async Task<IdentityResult> AddTokenExpiration(ApplicationUser user, string tokenType) => await _userRepository.AddTokenExpiration(user, tokenType);
        public async Task<bool> ValidateTokenExpires(ApplicationUser user) => await _userRepository.ValidateTokenExpires(user);
        public async Task<bool> RemoveTokenExpiry(ApplicationUser user) => await _userRepository.RemoveTokenExpiry(user);
    }
}
