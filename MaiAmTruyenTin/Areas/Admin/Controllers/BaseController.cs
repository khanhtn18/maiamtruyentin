using MaiAmTruyenTin.Common;
using System;
using System.Collections.Generic;
//using System.Globalization;
using System.Linq;
//using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertData"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertData"] = "alert-wanning";
            }
            else if (type == "error")
            {
                TempData["AlertData"] = "alert-error";
            }
        }
    }
}