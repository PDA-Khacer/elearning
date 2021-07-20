
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

        public ActionResult ShowListClassCourse(int id)
        {
            ListClassCourse lstCC = JsonConvert.DeserializeObject<ListClassCourse>(ws.GetAllClassCourseOfCourse(id));
            ViewBag.listClassCoures = lstCC;
            ViewBag.Couse = JsonConvert.DeserializeObject<Model.Course>(ws.GetCourse(id));
            return View("~/Views/UI_Admin/ClassCourse/view_list_class_coures.cshtml");
        }

        public ActionResult ViewAdd()
        {
            return View("~/Views/UI_Admin/Course/add_course.cshtml");
        }

        public ActionResult ViewEdit(int id)
        {
            ViewBag.Couse = JsonConvert.DeserializeObject<Model.Course>(ws.GetCourse(id));
            return View("~/Views/UI_Admin/Course/edit_course.cshtml");
        }
    }
}