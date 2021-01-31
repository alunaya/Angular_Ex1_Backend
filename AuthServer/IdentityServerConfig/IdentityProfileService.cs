using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.IdentityServerConfig
{
    public class IdentityProfileService : IProfileService
    {
        Task IProfileService.GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException();
        }

        Task IProfileService.IsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException();
        }
    }
}
