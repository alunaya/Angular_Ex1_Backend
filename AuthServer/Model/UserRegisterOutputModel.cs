using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Model
{
    public class UserRegisterOutputModel
    {
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
