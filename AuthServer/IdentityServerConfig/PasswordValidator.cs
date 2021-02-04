using IdentityServer4.Validation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Models;
using IdentityServerConfig;
using System;

namespace AuthServer.IdentityServerConfig
{
    public class PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public PasswordValidator(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            ApplicationUser user = await userManager.FindByNameAsync(context.UserName) ?? await userManager.FindByEmailAsync(context.UserName);

            if(user == null)
            {
                context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "Invalid username or password"
                    );
                return;
            }

            SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(user, context.Password, false);
            if (signInResult.Succeeded)
            {
                context.Result = new GrantValidationResult(
                    subject: user.UserName,
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
