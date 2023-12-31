using entityframework;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Attributes
{
    public class AppActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

            var appDbContext = filterContext.HttpContext.RequestServices.GetService<AppDbContext>();
            appDbContext.SaveChanges();
            base.OnResultExecuting(filterContext);
        }
    }
}