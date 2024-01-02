using domain;
using domain.shared.Enums;
using entityframework;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace api.Attributes
{
    public class RolePermission : ActionFilterAttribute
    {
        private readonly Role _requiredRole;

        public RolePermission(Role requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var dbContext = filterContext.HttpContext.RequestServices.GetRequiredService<AppDbContext>();

            var account = GetCurrentLoggedInAccount(filterContext, dbContext);

            if (UserHasRequiredRole(account, _requiredRole))
            {
                dbContext.SaveChanges();
            }

            base.OnResultExecuting(filterContext);
        }

        private Account GetCurrentLoggedInAccount(ResultExecutingContext filterContext, AppDbContext dbContext)
        {
            var userId = filterContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userGuid = new Guid(userId);

            return dbContext.Accounts.FirstOrDefault(a => a.Id == userGuid);
        }

        private bool UserHasRequiredRole(Account account, Role requiredRole)
        {
            return account.Role == requiredRole;
        }
    }
}