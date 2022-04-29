using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TKMaster.AulaEnsino.Web.UI.Application.BaseService;
using TKMaster.AulaEnsino.Web.UI.Application.BaseService.Interfaces;

namespace TKMaster.AulaEnsino.Web.UI.Configurations.Filters
{
    public class CustomActionFilterConfig : ActionFilterAttribute, IExceptionFilter
    {
        #region Properties

        private readonly NotificationHandler _notifications;

        #endregion

        #region Constructor

        public CustomActionFilterConfig(INotificationHandler<Notification> notifications)
        {
            _notifications = (NotificationHandler)notifications;
        }

        #endregion

        #region Methods

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var controller = (Controller)context.Controller;
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 500;

                if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    context.HttpContext.Response.Headers.Add("error-notification", "Erro desconhecido");
                }
                else
                {
                    if (controller.TempData["Error"] == null)
                    {
                        controller.TempData["Error"] = "";
                        controller.TempData["Error"]= context.Exception.Message ?? context.Exception.StackTrace;
                        controller.TempData.Keep("Error");
                    }

                    context.Result = controller.RedirectToAction("Error", "Home");
                }
            }
            else if (_notifications.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.HttpContext.Response.Headers.Add("warning-Notification", _notifications.Notifications.Select(x => x.Message).FirstOrDefault());
            }

            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
        }

        #endregion
    }
}
