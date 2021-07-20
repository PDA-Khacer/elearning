using Website.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers.admin.ClassCourse
{
    public class ClassCourseController : Controller
    {
        AdminService.Admin_ServiceSoapClient ws = new AdminService.Admin_ServiceSoapClient();
        static int idClass;
       // Model.ClassCourse cC = new Model.ClassCourse();
        // /ClassCourse/Index
        // GET: ClassCourse
        public ActionResult Index()
        {
            ListClassCourse lstCC = JsonConvert.DeserializeObject<ListClassCourse>(ws.GetAllClassCourse());
            ViewBag.listClassCoures = lstCC;
            return View("~/Views/UI_Admin/ClassCourse/view_list_class_coures.cshtml");
        }

        public ActionResult DetailClassCourse(int id)
        {
            Model.ClassCourse cC = JsonConvert.DeserializeObject<Model.ClassCourse>(ws.GetClassCourse(id));
            ViewBag.classCoures = cC;
            Session["classCourse"] = cC;
            return View("~/Views/UI_Admin/ClassCourse/view_detail_class_course.cshtml");
        }

        public ActionResult ViewAddClassCourse1()
        {
            ViewBag.lstCourse = JsonConvert.DeserializeObject<ListCourse>(ws.GetAllCourse()).courses;
            return View("~/Views/UI_Admin/ClassCourse/add_class_course.cshtml");
        }

        public ActionResult ViewAddClassCourse2(int id)
        {
            ViewBag.Couse = JsonConvert.DeserializeObject<Model.Course>(ws.GetCourse(id));
            ViewBag.lstCourse = JsonConvert.DeserializeObject<ListCourse>(ws.GetAllCourse()).courses;
            return View("~/Views/UI_Admin/ClassCourse/add_class_course.cshtml");
        }

        public ActionResult ViewEditClassCourse(int id)
        {
            Model.ClassCourse cC = JsonConvert.DeserializeObject<Model.ClassCourse>(ws.GetClassCourse(id));
            ViewBag.Couse = JsonConvert.DeserializeObject<Model.Course>(ws.GetCourse(cC.idCourse));
            return View("~/Views/UI_Admin/ClassCourse/view_detail_class_course.cshtml");
        }

        public PartialViewResult Modal()
        {
            return PartialView("~/Views/PartialView/modalLecture.cshtml");
        }

        public PartialViewResult LstTeacher(int id)
        {
            ViewBag.lstTeacher = (Session["classCourse"] as Model.ClassCourse).LstTeacher.accounts;
            return PartialView("~/Views/PartialView/lstTeacher.cshtml");
        }

        public PartialViewResult LstStudent(int id)
        {
            ViewBag.lstStudent = (Session["classCourse"] as Model.ClassCourse).LstStudent.accounts; 
            return PartialView("~/Views/PartialView/lstStudent.cshtml");
        }

        public PartialViewResult LstTeacherModal(int id)
        {
            ViewBag.lstTeachermodal = (Session["classCourse"] as Model.ClassCourse).LstTeacher.accounts;
            ViewBag.type = 1;
            return PartialView("~/Views/PartialView/lstTeacherModal.cshtml");
        }

        public PartialViewResult LstStudentModal(int id)
        {
            ViewBag.lstStudentmodal = (Session["classCourse"] as Model.ClassCourse).LstStudent.accounts;
            ViewBag.type = 1;
            return PartialView("~/Views/PartialView/lstStudentModal.cshtml");
        }

        public PartialViewResult FindStudent(string key)
        {
            ViewBag.lstStudentmodal = JsonConvert.DeserializeObject<ListAccountStudent>(ws.FindStudentInSystem(key)).accounts;
            ViewBag.type = 2;
            return PartialView("~/Views/PartialView/lstStudentModal.cshtml");
        }

        public PartialViewResult FindTeacher(string key)
        {
            ViewBag.lstTeachermodal = JsonConvert.DeserializeObject<ListAccountTeacher>(ws.FindTeacherInSystem(key)).accounts;
            ViewBag.type = 2;
            return PartialView("~/Views/PartialView/lstTeacherModal.cshtml");
        }

        // được gọi thông qua Ajax
        public ActionResult AddStudentInClass(string lstId)
        {
            // tách con listId => String[] trong đó lần lượt chứa các id để thêm vào lớp
            string[] lstIdStudent = lstId.Split('.');
            // for cho tới khi hết id
            int idClass = (Session["classCourse"] as Model.ClassCourse).id;
            foreach (string item in lstIdStudent)
            {
                if(!item.Equals(string.Empty))
                {
                    ws.AddStudentToClassCourse(idClass, Int32.Parse(item));
                }    
            }
            // lấy lại danh sách sinh viên sau khi đã cập nhật     
            List<Account_Student> lstStu = JsonConvert.DeserializeObject<ListAccountStudent>(ws.GetAllStudent(idClass)).accounts;
            ViewBag.lstStudentmodal = lstStu;
            ViewBag.type = 1;
            return View("~/Views/PartialView/lstStudentModal.cshtml");
        }
        public ActionResult RemoveStudentFormClass(string lstId)
        {
            // tách con listId => String[] trong đó lần lượt chứa các id để thêm vào lớp
            string[] lstIdStudent = lstId.Split('.');
            // for cho tới khi hết id
            int idClass = (Session["classCourse"] as Model.ClassCourse).id;
            foreach (string item in lstIdStudent)
            {
                if (!item.Equals(string.Empty))
                {
                    ws.RemoveStudentToClassCourse(idClass, Int32.Parse(item));
                }
            }
            // lấy lại danh sách sinh viên sau khi đã cập nhật     
            List<Account_Student> lstStu = JsonConvert.DeserializeObject<ListAccountStudent>(ws.GetAllStudent(idClass)).accounts;
            ViewBag.lstStudentmodal = lstStu;
            ViewBag.type = 1;
            return View("~/Views/PartialView/lstStudentModal.cshtml");
        }
    }
}