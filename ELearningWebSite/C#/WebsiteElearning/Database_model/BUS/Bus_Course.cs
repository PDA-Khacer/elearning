using Database_model.DAO;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_model.BUS
{
    public class Bus_Course
    {
       public static List<Course> getAllCourse()
       {
            DAO_Course dao = new DAO_Course();
            return dao.GetAll();
       }

        public static List<Course> getAllCourseFull()
        {
            DAO_Course dao = new DAO_Course();
            return dao.GetAll();
        }

        public static Course getCourseFull(int id)
        {
            DAO_Course dao = new DAO_Course();
            return dao.GetCourse(id);
        }

        public static List<Account> getAllAccountInCourse(int idCourse)
        {
            List<Account> acc = new List<Account>();
            DAO_ClassCoure_Student dao_ccs = new DAO_ClassCoure_Student();
            DAO_ClassCoure_Teacher dao_cct = new DAO_ClassCoure_Teacher();
            List<ClassCourse> lstCC = BUS_ClassCourse.GetAllClassOfCourse(idCourse);
            foreach(ClassCourse item in lstCC)
            {
                acc.AddRange(dao_cct.GetAllAccountInClass(item.id));
                acc.AddRange(dao_ccs.GetAllAccountInClass(item.id));
            }
            return acc;
        }

        public static List<Account_Student> getAllStudentInCourse(int idCourse)
        {
            List<Account_Student> acc = new List<Account_Student>();
            List<ClassCourse> lstCC = BUS_ClassCourse.GetAllClassOfCourse(idCourse);
            DAO_Account dao = new DAO_Account();
            foreach (ClassCourse item in lstCC)
            {
                acc.AddRange(dao.GetStudentInClassCourse(item.id));
            }
            return acc;
        }

        public static List<Account_Teacher> getAllTeacherInCourse(int idCourse)
        {
            List<Account_Teacher> acc = new List<Account_Teacher>();
            List<ClassCourse> lstCC = BUS_ClassCourse.GetAllClassOfCourse(idCourse);
            DAO_Account dao = new DAO_Account();
            foreach (ClassCourse item in lstCC)
            {
                acc.AddRange(dao.GetTeacherInClassCourse(item.id));
            }
            return acc;
        }
    }
}
