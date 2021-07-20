using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Model;

namespace Website.Controllers.admin.Teacher
{
    public class TeacherAdminController : Controller
    {
        // GET: TeacherAdmin
        AdminService.Admin_ServiceSoapClient ws = new AdminService.Admin_ServiceSoapClient();
        public ActionResult Index()
        {
            ViewBag.lstTeacher = JsonConvert.DeserializeObject<ListAccountTeacher>(ws.GetAllTeacherInSystem()).accounts;
            return View("~/Views/UI_Admin/TeacherAdmin/listTeacher.cshtml");
        }

        public ActionResult ViewAdd()
        {
            return View("~/Views/UI_Admin/TeacherAdmin/add_teacher.cshtml");
        }

        public ActionResult ViewEdit(int id)
        {
            ViewBag.teacher = JsonConvert.DeserializeObject<Account_Teacher>(ws.GetTeacherInSystem(id));
            return View("~/Views/UI_Admin/TeacherAdmin/edit_teacher.cshtml");
        }
    }
}