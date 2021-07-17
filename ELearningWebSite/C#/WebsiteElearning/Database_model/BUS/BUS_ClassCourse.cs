using Database_model.DAO;
using Database_model.Model;
using System.Collections.Generic;

namespace Database_model.BUS
{
    public class BUS_ClassCourse
    {
        public List<Account> GetAllAccountInClassCourse(ClassCourse token)
        {
            List<Account> lst_acc = new List<Account>();
            DAO_Account dao_acc = new DAO_Account();
            lst_acc.AddRange(dao_acc.GetStudentInClassCourse(token.id));
            lst_acc.AddRange(dao_acc.GetTeacherInClassCourse(token.id));
            return lst_acc;
        }

        public void AddStudentToClass(ClassCourse token, Account_Student acc)
        {
            DAO_ClassCoure_Student dao_ccstudent = new DAO_ClassCoure_Student();
            dao_ccstudent.Add(token, acc);
        }

        public void AddTeacherToClass(ClassCourse token, Account_Teacher acc)
        {
            DAO_ClassCoure_Teacher dao_ccteacher = new DAO_ClassCoure_Teacher();
            dao_ccteacher.Add(token, acc);
        }

        public static List<ClassCourse> GetAllClassCourse()
        {
            DAO_ClassCourse dao_classCourse = new DAO_ClassCourse();
            return dao_classCourse.GetAllFull();
        }

        public static List<ClassCourse> GetAllClassOfCourse(int id)
        {
            DAO_ClassCourse dao_classCourse = new DAO_ClassCourse();
            return dao_classCourse.GetAllFull(id);
        }

        public static ClassCourse GetAClassCourse(int id)
        {
            DAO_ClassCourse dao_classCourse = new DAO_ClassCourse();
            return dao_classCourse.GetClassCourseFull(id);
        }

        public static List<ClassCourse> GetAllClassOfTeacher(int idTeacher)
        {
            DAO_ClassCoure_Teacher dao = new DAO_ClassCoure_Teacher();
            return dao.GetAllClass(idTeacher);
        }

        public static List<ClassCourse> GetAllClassOfStudent(int idStudent)
        {
            DAO_ClassCoure_Student dao = new DAO_ClassCoure_Student();
            return dao.GetAllClassOfStudent(idStudent);
        }

        public static List<Account> GetAllAccountInClass(int idClass)
        {
            DAO_ClassCoure_Student dao_ccs = new DAO_ClassCoure_Student();
            DAO_ClassCoure_Teacher dao_cct = new DAO_ClassCoure_Teacher();
            List<Account> acc = new List<Account>();
            acc.AddRange(dao_ccs.GetAllAccountInClass(idClass));
            acc.AddRange(dao_cct.GetAllAccountInClass(idClass));
            return acc;
        }

        public static List<Account_Student> GetAllStudentInClass(int idClass)
        {
            DAO_Account dao = new DAO_Account();
            return dao.GetStudentInClassCourse(idClass);
        }

        public static List<Account_Teacher> GetAllTeacherInClass(int idClass)
        {
            DAO_Account dao = new DAO_Account();
            return dao.GetTeacherInClassCourse(idClass);
        }

        public static bool AddAccountStudentToClass(int idClass, int idAccount)
        {
            DAO_ClassCoure_Student dao = new DAO_ClassCoure_Student();
            return dao.Add(idClass, idAccount);
        }

        public static bool AddAccountTeacherToClass(int idClass,int idAccount)
        {
            DAO_ClassCoure_Teacher dao = new DAO_ClassCoure_Teacher();
            return dao.Add(idClass, idAccount);
        }

        public static bool RemoveAnAccountStudentToClass(int idClass, int idAccount)
        {
            DAO_ClassCoure_Student dao = new DAO_ClassCoure_Student();
            return dao.RemoveAnStudentInClass(idAccount,idClass);
        }

        public static bool RemoveAllAccountStudentToClass(int idClass)
        {
            DAO_ClassCoure_Student dao = new DAO_ClassCoure_Student();
            return dao.RemoveAllStudentInClass(idClass);
        }

        public static bool RemoveAnAccountTeacherToClass(int idClass, int idAccount)
        {
            DAO_ClassCoure_Teacher dao = new DAO_ClassCoure_Teacher();
            return dao.RemoveAnTeacherInClass(idClass, idAccount);
        }

        public static bool RemoveAllAccountTeacherToClass(int idClass)
        {
            DAO_ClassCoure_Teacher dao = new DAO_ClassCoure_Teacher();
            return dao.RemoveAllTeacherInClass(idClass);
        }

        public static List<Account_Student> FindStudentInClass(int idClass, string key)
        {
            DAO_Account dao = new DAO_Account();
            return dao.FindStudentInClassCourse(idClass, key);
        }

        public static List<Account_Teacher> FindTeacherInClass(int idClass, string key)
        {
            DAO_Account dao = new DAO_Account();
            return dao.FindTeacherInClassCourse(idClass, key);
        }
    }
}
