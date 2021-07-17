using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Model;

namespace Website.Controllers.teacher.ContentLecture
{
    public class TeacherContentLectureController : Controller
    {
        TeacherServices.Teacher_ServiceSoapClient ws = new TeacherServices.Teacher_ServiceSoapClient();
        // GET: TeacherContentLecture
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Modal()
        {
            return PartialView("~/Views/PartialView/modalTeacherAddExam.cshtml");
        }

        public PartialViewResult ListQuestion()
        {
            ViewBag.LstQuest = JsonConvert.DeserializeObject<ListQuestion_MCQ>( ws.GetAllQuestion(0));
            return PartialView("~/Views/PartialView/lstQuestion");
        }

        public PartialViewResult AddQuestion(string content,string contentAnswer,string correctAnswer)
        {
            Random rd = new Random();
            //ws.CreateQuestMCQ(rd.Next(100000,999999).ToString(),"cau1","test",content," ",);
            ViewBag.LstQuest = JsonConvert.DeserializeObject<ListQuestion_MCQ>(ws.GetAllQuestion(0));
            return PartialView("~/Views/PartialView/lstQuestion");
        }

    }
}