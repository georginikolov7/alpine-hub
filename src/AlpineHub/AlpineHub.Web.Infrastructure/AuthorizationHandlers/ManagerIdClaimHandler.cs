using AlpineHub.Core.Contracts;
using AlpineHub.Web.AuthorizationRequirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using static AlpineHub.Data.Constants.CustomClaims;
namespace AlpineHub.Web.AuthorizationHandlers
{
    public class ManagerIdClaimHandler(IManagerService managerService) : AuthorizationHandler<ManagerIdRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ManagerIdRequirement requirement)
        {
            var managerIdClaim = context.User.FindFirst(c => c.Type == ManagerIdClaim);
            if (managerIdClaim is null)
            {
                context.Fail();
                return;
            }

            string? managerId = managerIdClaim.Value;
            string? userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await managerService.IsManagerIdValid(managerId, userId))
            {
                context.Succeed(requirement);
            }
            return;
        }
    }
}
