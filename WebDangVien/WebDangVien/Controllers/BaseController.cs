using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDangVien.Controllers
{
    public class BaseController : Controller
    {
        //hàm dùng kiểm tra xem người dùng đã đăng nhập chưa, nếu chưa đăng nhập thì thoát ra trang login
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (Code.UserSession)Session[Common.CommonConstants.USER_SESSION];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type=="success")
            {
                TempData["AlertType"]="alert-success";
            } 
            else if (type=="warning")
            {
                TempData["AlertType"]="alert-warning";
            }
            else if (type=="error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}