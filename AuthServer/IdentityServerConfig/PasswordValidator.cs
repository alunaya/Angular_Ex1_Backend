using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Test;

namespace AuthServer.IdentityServerConfig
{
    public class PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IdentityServer4.Test.TestUserResourceOwnerPasswordValidator;
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            return Task.FromResult(0);
        }
    }
}
