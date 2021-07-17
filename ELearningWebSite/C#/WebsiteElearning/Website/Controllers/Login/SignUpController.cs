using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers.Login
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult ShowForm()
        {
            return View();
        }
    }
}