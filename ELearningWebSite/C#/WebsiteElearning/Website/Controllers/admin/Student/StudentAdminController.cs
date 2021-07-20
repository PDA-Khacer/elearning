using Newtonsoft.Json;
using Website.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers.admin.Student
{
    public class StudentAdminController : Controller
    {
        // GET: StudentAdmin
        AdminService.Admin_ServiceSoapClient ws = new AdminService.Admin_ServiceSoapClient();
        public ActionResult Index()
        {
            ViewBag.lstStudent = JsonConvert.DeserializeObject<ListAccountStudent>(ws.GetAllStudentInSystem()).accounts;
            return View("~/Views/UI_Admin/StudentAdmin/listStudent.cshtml");
        }

        public ActionResult ViewAdd()
        {
            return View("~/Views/UI_Admin/StudentAdmin/add_student.cshtml");
        }

        public ActionResult ViewEdit(int id)
        {
            ViewBag.student = JsonConvert.DeserializeObject<Account_Student>(ws.GetStudentInSystem(id));
            return View("~/Views/UI_Admin/StudentAdmin/edit_student.cshtml");
        }
    }
}