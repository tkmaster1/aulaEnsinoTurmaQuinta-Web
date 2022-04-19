using Microsoft.AspNetCore.Authorization;

namespace TKMaster.AulaEnsino.Web.UI.Configurations
{
    public class AllowAnonymous : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (IAuthorizationRequirement requirement in context.PendingRequirements.ToList())
                context.Succeed(requirement); // Simply pass all requirements

            return Task.CompletedTask;
        }
    }
}
