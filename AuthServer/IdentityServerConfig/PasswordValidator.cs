using IdentityServer4.Validation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Models;
using IdentityServerConfig;

namespace AuthServer.IdentityServerConfig
{
    public class PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public PasswordValidator(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(new ApplicationUser { UserName = context.UserName } ,context.Password, true);
            if (signInResult.Succeeded) {
                context.Result = new GrantValidationResult(
                    subject: context.UserName,
                    authenticationMethod: IdentityServer4.Models.GrantType.ResourceOwnerPassword
                    );

                return;
            }

            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "Invalid username or password"
                    );

            return;
        }
    }
}
