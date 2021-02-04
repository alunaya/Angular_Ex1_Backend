using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Model
{
    public class UserRegisterInputModel
    {
        [Required]
        public string Username;
        [EmailAddress]
        public string Email;
        
        public string Password;
    }
}
