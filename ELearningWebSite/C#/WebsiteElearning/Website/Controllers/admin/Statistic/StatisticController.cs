using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Model;

namespace Website.Controllers.admin.Statistic
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        AdminService.Admin_ServiceSoapClient ws = new AdminService.Admin_ServiceSoapClient();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StatisticStudent()
        {
            ViewBag.lstStudent = JsonConvert.DeserializeObject<ListAccountStudent>(ws.GetAllStudentInSystem()).accounts;
            return View("~/Views/UI_Admin/Statistic/student.cshtml");
        }

        public ActionResult StatisticTeacher()
        {
            ViewBag.lstTeacher = JsonConvert.DeserializeObject<ListAccountTeacher>(ws.GetAllTeacherInSystem()).accounts;
            return View("~/Views/UI_Admin/Statistic/teacher.cshtml");
        }

        public ActionResult StatisticAccount()
        {
            return View("~/Views/UI_Admin/Statistic/account.cshtml");
        }

        public ActionResult StatisticCourse()
        {
            ViewBag.listCourse = JsonConvert.DeserializeObject<ListCourse>(ws.GetAllCourse());
            return View("~/Views/UI_Admin/Statistic/course.cshtml");
        }

        public ActionResult StatisticClassCourse()
        {
            ViewBag.listClassCoures = JsonConvert.DeserializeObject<ListClassCourse>(ws.GetAllClassCourse());
            return View("~/Views/UI_Admin/Statistic/classCourse.cshtml");
        }

        public ActionResult StatisticLecture()
        {
            return View("~/Views/UI_Admin/Statistic/lecture.cshtml");
        }
    }
}