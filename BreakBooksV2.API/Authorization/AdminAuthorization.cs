using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BreakBooks.Authorization
{
    public class AdminAuthorization : AuthorizationHandler<AdminRequirement>
    {

        protected override Task HandleRequirementAsync
            (AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            var claim = context.User.FindFirst(claim => claim.Type == ClaimTypes.Role);
            
            if(claim?.Value == requirement.Role)
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}

