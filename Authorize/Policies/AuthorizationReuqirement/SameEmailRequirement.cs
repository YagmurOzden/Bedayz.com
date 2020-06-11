using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bedayzAPI.Authorize.Policies.AuthorizationReuqirement
{
    public class SameEmailRequirement : IAuthorizationRequirement
    {


        public int Email { get; }

        public SameEmailRequirement(int email)
        {

            Email = email;
        }
    }
}
