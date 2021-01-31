using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.IdentityServerConfig
{
    public class TestUsers
    {
        public static List<TestUser> SetTestUser =>
            new List<TestUser>
            {
                new TestUser
            {
                SubjectId = "1",
                Username = "admin",
                Password = "admin"
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "user",
                Password = "user"
            }
            };
    }
}
