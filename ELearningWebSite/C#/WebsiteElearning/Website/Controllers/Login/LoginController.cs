using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database_model.BUS;

namespace Website.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("~/Views/UI_Student/Login/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Login()
        {
            string user = Request.Form["username"];
            string pass = Request.Form["password"];
            if(BUS_Account.checkAccount(user,pass,2))
            {
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.messError = "Tên đăng nhập hoặc mật khẩu sai !!";
                return View("~/Views/UI_Student/Login/Login.cshtml");
            }
        }        
    }
}