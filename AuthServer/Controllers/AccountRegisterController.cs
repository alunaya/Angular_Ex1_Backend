﻿using AuthServer.Model;
using IdentityServerConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;


        public AccountRegisterController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpPost]
        public async Task<string> Register([FromBody]UserRegisterInputModel registerModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
            };

            var createResult = await userManager.CreateAsync(user, registerModel.Password);
            if (createResult.Succeeded) {
                return "Create user success";
            }

            return "Create user failed";
        }
    }
}
