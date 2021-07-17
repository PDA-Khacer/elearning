using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers.teacher.Lecture
{
    public class LectureController : Controller
    {
        // GET: Lecture
        public ActionResult Index()
        {
            return View("~/Views/UI_Teacher/Lecture/view_detail_lecture.cshtml");
        }

        public PartialViewResult Modal()
        {
            return PartialView("~/Views/PartialView/modalTeacherLecture.cshtml");
        }

        public ActionResult ViewAddExam()
        {
            return View("~/Views/UI_Teacher/ContentLec/view_Add_Exam.cshtml");
        }
    }
}