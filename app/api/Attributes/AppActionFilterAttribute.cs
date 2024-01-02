using entityframework;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Attributes
{
    public class AppActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

            var appDbContext = filterContext.HttpContext.RequestServices.GetService<AppDbContext>();
            var transaction = appDbContext.Database.BeginTransaction();
            try
            {
                appDbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }

            base.OnResultExecuting(filterContext);
        }
    }
}