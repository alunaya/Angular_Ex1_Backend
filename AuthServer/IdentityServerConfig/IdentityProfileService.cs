using AuthServer.Model;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = userManager.GetUserAsync(context.Subject).Result;
            context.IsActive = user != null;
            return Task.FromResult(0);

        }
    }
}
