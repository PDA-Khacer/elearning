using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_ClassCoure_Teacher
    {
        public DAO_ClassCoure_Teacher()
        {
            //db_Uitl.Connect();
        }

        public void Add(ClassCourse ann, Account_Teacher acc)
        {
            if (CheckReferences(ann.id, acc.id))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ClassCourse_Teacher (userTeacher,CodeClass,[State]) " +
                    "values(@userTeacher,@CodeClass,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@userTeacher", acc.Username);
                    cm.Parameters.AddWithValue("@CodeClass", ann.CodeClass);
                    cm.Parameters.AddWithValue("@State", ann.State);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
        }

        public bool Add(int idCode, int idTeacher)
        {
            if (CheckReferences(idCode, idTeacher))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ClassCourse_Teacher (userTeacher,CodeClass,[State]) " +
                    "values(@userTeacher,@CodeClass,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@userTeacher", idTeacher);
                    cm.Parameters.AddWithValue("@CodeClass", idCode);
                    cm.Parameters.AddWithValue("@State", 1);
                    cm.ExecuteNonQuery();
                    db_Uitl.Close();
                    return true;
                }
            }
            else
            {
                db_Uitl.Close();
                return false;
            }    
        }

        public List<ClassCourse> GetAllClass(int idTeacher)
        {
            try
            {
                List<ClassCourse> ls = new List<ClassCourse>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse_Teacher where userTeacher = '" + idTeacher + "'";
                    DAO_ClassCourse dAO_ClassCourse = new DAO_ClassCourse();
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        int idClass = reader.GetInt32(2);
                        ls.Add(dAO_ClassCourse.GetClassCourseFull(idClass));
                    }
                    reader.Close();
                    db_Uitl.Close();
                }
                return ls;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public List<Account> GetAllAccountInClass(int idClass)
        {
            try
            {
                List<Account> ls = new List<Account>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse_Teacher where CodeClass = " + idClass;
                    DAO_Account dAO = new DAO_Account();
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        int idAccount = reader.GetInt32(1);
                        ls.Add(dAO.GetAccount(idAccount));
                    }
                    reader.Close();
                    db_Uitl.Close();
                }
                return ls;
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
                return null;
            }
        }

        public bool CheckReferences(int codeClass, int userTeacher)
        {
            DAO_ClassCourse dao_course = new DAO_ClassCourse();
            DAO_Account dao_teacher = new DAO_Account();
            if (!dao_course.Contain(codeClass))
                return false;
            if (!dao_teacher.Contain(userTeacher))
                return false;
            return true;
        }

        public bool RemoveAnTeacherInClass(int idTeacher, int idClass)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Delete From ClassCourse_Teacher where CodeClass = " + idClass + " and userTeacher = " + idTeacher;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
                return true;
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RemoveAllTeacherInClass(int idClass)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Delete From ClassCourse_Teacher where CodeClass = " + idClass;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
                return true;
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
                return false;
            }
        }

        public void Remove(string id)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Delete From ClassCourse where username = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Remove(int id)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Delete From ClassCourse where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
