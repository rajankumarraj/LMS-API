using AutoMapper;
using LMS.DATA;
using LMS.DATA.Model;
using LMS.MODELS.Constants;
using LMS.REPOSITORIES.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS.REPOSITORIES.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        private readonly LMSDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public UserRepository(LMSDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> AddTokenExpiration(ApplicationUser user, string TokenType)
        {
            double daysOfExpiration = 0;
            if (TokenType == EmailTokenType.InvitationToken)
            {
                daysOfExpiration = Convert.ToDouble(_configuration["TokenExpiry:Userinvitation:Minutes"]);

            }
            if (TokenType == EmailTokenType.SignUpToken)
            {
                daysOfExpiration = Convert.ToDouble(_configuration["TokenExpiry:Signup:Minutes"]);

            }

            var expiresAt = DateTime.Now.Add(TimeSpan.FromMinutes(daysOfExpiration));
            var tokenExpiredAtClaim = new Claim("emailConfirmationTokenExpiredAt", expiresAt.Ticks.ToString());
            return await _userManager.AddClaimAsync(user, tokenExpiredAtClaim);
        } 

        public async Task<bool> ValidateTokenExpires(ApplicationUser user)
        {
            bool expired = true;
            var claims = (await _userManager.GetClaimsAsync(user))
                        .Where(c => c.Type == "emailConfirmationTokenExpiredAt");
            var expiredAt = claims.LastOrDefault()?.Value;

            if (expiredAt != null)
            {
                var expires = Convert.ToInt64(expiredAt);
                var now = DateTime.Now.Ticks;
                expired = now <= expires;
            }
            else
            {
                expired = false;
            }

            return expired;
        }

        public async Task<bool> RemoveTokenExpiry(ApplicationUser user)
        {
            bool succedded = true;
            var claims = (await _userManager.GetClaimsAsync(user))
                      .Where(c => c.Type == "emailConfirmationTokenExpiredAt");
            if (claims != null)
            {
                // clear claims
                await _userManager.RemoveClaimsAsync(user, claims);
            }

            return succedded;

        }
    }
}
