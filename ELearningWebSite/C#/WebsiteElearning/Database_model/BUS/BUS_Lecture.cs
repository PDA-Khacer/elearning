using Database_model.DAO;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_model.BUS
{
    public class BUS_Lecture
    {
        public static List<Lecture> GetAllLecture()
        {
            DAO_Lecture dao = new DAO_Lecture();
            return dao.GetAll();
        }

        public static List<Lecture> GetAllLectureInClass(int idClass)
        {
            DAO_Lecture dao = new DAO_Lecture();
            return dao.GetAll(idClass,2);
        }

        public static bool AddLectureToClass(string codeLecture, string header, string description, int idTeacher, int idCourse,int idClassCourse)
        {
            DAO_Lecture daoLec = new DAO_Lecture();
            DAO_Lecture_Class daoLecClass = new DAO_Lecture_Class();
            if (!daoLec.Add(codeLecture, header, description, idCourse, idTeacher))
                return false;
            Lecture lec = daoLec.GetLecture(codeLecture);
            if (!daoLecClass.Add(lec.id, idClassCourse))
                return false;
            return true;
        }

        public static bool CreateLecture(string codeLecture, string header, string description, int idTeacher, int idCourse)
        {
            DAO_Lecture daoLec = new DAO_Lecture();
            return daoLec.Add(codeLecture, header, description, idCourse, idTeacher);
        }

        public static bool AddLectureToClass(int idLec, int idClass)
        {
            DAO_Lecture_Class daoLecClass = new DAO_Lecture_Class();
            return daoLecClass.Add(idLec,idClass);
        }

        public static bool CreateExam(string codeContent, string header, string description, string dayOpen, string dayClose, string dayExipre, string timeStart, float duration, int idTeacher,int idLecture)
        {
            DAO_ContentLec_Exam daoLec = new DAO_ContentLec_Exam();
            return daoLec.Add(codeContent, header, description, dayOpen, dayClose, dayExipre, timeStart, duration, idTeacher,idLecture);
        }

        public static bool CreateQuest(string codeQuest, string numOder, string header, string content, string imgs, int typeQ, int idExam, string codeAnswer)
        {
            DAO_Question dao = new DAO_Question();
            return dao.Add( codeQuest,  numOder,  header, content, imgs, typeQ, idExam, codeAnswer);
        }

        public static bool CreateAnswer(string codeAnswer, string charOrder, string content, string img, int codeQuestion)
        {
            DAO_Answer dao = new DAO_Answer();
            return dao.AddMCQ(codeAnswer,charOrder,content,img,codeQuestion);
        }

        public static List<Question_MCQ> GetAllQuestion(int idExam)
        {
            DAO_Question_MCQ daoLec = new DAO_Question_MCQ();
            return daoLec.GetAllQuest(idExam);
        }

        public static Question_MCQ GetQuestion(int idQ)
        {
            DAO_Question_MCQ daoLec = new DAO_Question_MCQ();
            return daoLec.GetQuestion_MCQ(idQ);
        }

        public static ContentLec GetExam(int idExam)
        {
            DAO_ContentLec_Exam daoLec = new DAO_ContentLec_Exam();
            return daoLec.GetContentLec(idExam);
        }

        public static List<ContentLec> GetAllExam(int idContenLec)
        {
            DAO_ContentLec_Exam daoLec = new DAO_ContentLec_Exam();
            return daoLec.GetAll(idContenLec, 1);
        }
    }
}
