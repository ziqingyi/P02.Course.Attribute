using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace P39.Course.dotnetCoreLib.Authentications
{
    public class AdvancedRequirement : AuthorizationHandler<NameAuthorizationRequirement>, IAuthorizationRequirement
    {
        // T is same in AuthorizationHandler and method HandleRequirementAsync's parameter
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            NameAuthorizationRequirement requirement)
        {
            if (context.User != null && context.User.HasClaim(c => c.Type == ClaimTypes.Sid))
            {
                string sid = context.User.FindFirst(c => c.Type == ClaimTypes.Sid).Value;

                //simple check: sid is not null, authorization success. 
                if (!sid.Equals(requirement.RequiredName))
                {
                    context.Succeed(requirement);
                }

            
            }

            return Task.CompletedTask;
        }

    }
}
