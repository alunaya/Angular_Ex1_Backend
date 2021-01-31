using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.IdentityServerConfig
{
    public class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiScope> ApiScopes => 
            new List<ApiScope>
            {
                new ApiScope(name: "get-costing",   displayName: "get costing data"),
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("angular-ex1", "api for angular ex1")
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "angular-ex",
                    ClientId = "angualr-ex",
                    AccessTokenLifetime = (int)TimeSpan.FromMinutes(15).TotalSeconds,
                    AbsoluteRefreshTokenLifetime = (int)TimeSpan.FromDays(7).TotalSeconds,
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "angular-ex1", "refresh"
                    },

                }
            };
    }
}
