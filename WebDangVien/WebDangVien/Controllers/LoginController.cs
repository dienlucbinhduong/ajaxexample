using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDangVien.Models;
using DVModels.DAO;

namespace WebDangVien.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index (LoginModel model)
        {
            var result = new AccountModel().Login(model.UserName, model.Password);
            if (result && ModelState.IsValid)            
            {
                var userSess = new Code.UserSession();
                userSess.UserName = model.UserName;
                userSess.Password = model.Password;
                Session.Add(Common.CommonConstants.USER_SESSION, userSess);
                Code.SessionHelper.SetSession(new Code.UserSession(){UserName=model.UserName});               
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}