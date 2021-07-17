
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Model;
using Newtonsoft.Json;

namespace Website.Controllers.admin.Course
{
    public class CourseController : Controller
    {
        AdminService.Admin_ServiceSoapClient ws = new AdminService.Admin_ServiceSoapClient();
        // GET: Course
        public ActionResult Index()
        {
            ListCourse lstCourse = JsonConvert.DeserializeObject<ListCourse>(ws.GetAllCourse());
            ViewBag.listCourse = lstCourse;
            return View("~/Views/UI_Admin/Course/view_list_course.cshtml");
        }
    }
}