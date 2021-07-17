using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_model.Model
{
    public class ListCourse
    {
        public List<Course> courses ;
        public ListCourse()
        {

        }
        public ListCourse(List<Course> lstCourse)
        {
            this.courses = lstCourse;
        }

    }

    public class ListClassCourse
    {
        public List<ClassCourse> classCourses;
        public ListClassCourse()
        {

        }
        public ListClassCourse(List<ClassCourse> lstCourse)
        {
            this.classCourses = lstCourse;
        }

    }

    public class ListAccount
    {
        public List<Account> accounts;
        public ListAccount()
        {

        }
        public ListAccount(List<Account> accounts)
        {
            this.accounts = accounts;
        }

    }

    public class ListAccountTeacher
    {
        public List<Account_Teacher> accounts;
        public ListAccountTeacher()
        {

        }
        public ListAccountTeacher(List<Account_Teacher> accounts)
        {
            this.accounts = accounts;
        }

    }

    public class ListAccountStudent
    {
        public List<Account_Student> accounts;
        public ListAccountStudent()
        {

        }
        public ListAccountStudent(List<Account_Student> accounts)
        {
            this.accounts = accounts;
        }

    }

    public class ListLecture
    {
        public List<Lecture> lectures;
        public ListLecture()
        {

        }
        public ListLecture(List<Lecture> lectures)
        {
            this.lectures = lectures;
        }

    }

    public class ListQuestion
    {
        public List<Question>  questions;
        public ListQuestion()
        {

        }
        public ListQuestion(List<Question> questions)
        {
            this.questions = questions;
        }
    }

    public class ListAnswer
    {
        public List<Answer> answers;
        public ListAnswer()
        {
            answers = new List<Answer>();
        }
        public ListAnswer(List<Answer> answers)
        {
            this.answers = answers;
        }
    }
    public class ListQuestion_MCQ
    {
        public List<Question_MCQ> question_MCQs;
        public ListQuestion_MCQ()
        {
            question_MCQs = new List<Question_MCQ>();
        }
        public ListQuestion_MCQ(List<Question_MCQ> question_MCQs)
        {
            this.question_MCQs = question_MCQs;
        }
    }

    public class ListExam
    {
        public List<ContentLec> contentLec_Exams;
        public ListExam()
        {
            contentLec_Exams = new List<ContentLec>();
        }
        public ListExam(List<ContentLec> contentLec_Exams)
        {
            this.contentLec_Exams = contentLec_Exams;
        }
    }
}
