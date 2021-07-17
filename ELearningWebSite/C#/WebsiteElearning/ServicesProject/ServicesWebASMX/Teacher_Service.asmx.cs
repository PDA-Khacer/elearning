using Database_model.BUS;
using Database_model.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ServicesProject.ServicesWebASMX
{
    /// <summary>
    /// Summary description for Teacher_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Teacher_Service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllLecture()
        {
            return JsonConvert.SerializeObject(new ListLecture(BUS_Lecture.GetAllLecture()));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllLectureInClass(int idClass)
        {
            return JsonConvert.SerializeObject(new ListLecture(BUS_Lecture.GetAllLectureInClass(idClass)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllQuestion(int idExam)
        {
            return JsonConvert.SerializeObject(new ListQuestion_MCQ(BUS_Lecture.GetAllQuestion(idExam)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetQuestion(int idQ)
        {
            return JsonConvert.SerializeObject(BUS_Lecture.GetQuestion(idQ));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetExam(int idExam)
        {
            return JsonConvert.SerializeObject(BUS_Lecture.GetExam(idExam));
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllExam(int idContent)
        {
            return JsonConvert.SerializeObject(new ListExam(BUS_Lecture.GetAllExam(idContent)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool CreateLecture(string codeLecture,string header,string description,int idTeacher,int idCourse)
        {
            return BUS_Lecture.CreateLecture(codeLecture,header,description,idTeacher,idCourse);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool AddLectureToClass(int idLecture, int idClass)
        {
            return BUS_Lecture.AddLectureToClass(idLecture,idClass);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool CreateAndAddToClass(string codeLecture, string header, string description, int idTeacher, int idCourse, int idClass)
        {
            return BUS_Lecture.AddLectureToClass(codeLecture, header, description, idTeacher, idCourse, idClass);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool RemoveALectureOfClass(int idLecture, int idClass)
        {
            return false;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool RemoveAllLectureOfClass(int idClass)
        {
            return false;
        }
        
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool CreateEmptyExamInLecture(string codeContent, string header, string description, string dayOpen, string dayClose, string dayExipre, string timeStart, float duration, int idTeacher, int idLecture)
        {
            return BUS_Lecture.CreateExam(codeContent, header, description, dayOpen, dayClose, dayExipre, timeStart, duration, idTeacher, idLecture);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool CreateQuestMCQ(string codeQuest,string numberOder,string header,string content,string img,int codeContentlec,string correctAnswer)
        {
            // desizer img to listIMG
            // create question
            // create questionMCQ
            return BUS_Lecture.CreateQuest(codeQuest,numberOder,header,content,img,2,codeContentlec,correctAnswer);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool CreateAnswerForQuestion(string codeAnswer, string charOrder, string content, string img,int codeQuestion)
        {
            // desizer img to listIMG
            // create Answer
            return BUS_Lecture.CreateAnswer(codeAnswer, charOrder, content, img, codeQuestion);
        }

        
        

    }
}
