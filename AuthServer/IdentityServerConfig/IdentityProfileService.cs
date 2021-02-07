using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServerConfig;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AuthServer.IdentityServerConfig
{
    public class IdentityProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);

        }
    }
}
