using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_ClassCourse
    {
        public DAO_ClassCourse()
        {
            
        }

        public void Add(ClassCourse ann, string course)
        {
            db_Uitl.Connect();
            if (!Contain(ann.id))
            {
                
                string sqlQuery = "Insert into ClassCourse(CodeClass,nameClass,CodeCourse,[State]) " +
                    "values (@CodeClass,@nameClass,@CodeCourse,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeClass", ann.CodeClass);
                    cm.Parameters.AddWithValue("@nameClass", ann.NameClass);
                    cm.Parameters.AddWithValue("@CodeCourse", course);
                    cm.Parameters.AddWithValue("@State", ann.State);
                    cm.ExecuteNonQuery();
                }
            }
            db_Uitl.Close();
        }
        /// <summary>
        /// hàm add luôn các list có sẵn đã có.
        /// </summary>
        /// <param name="ann"></param>
        /// <param name="course"></param>
        public void AddFull(ClassCourse ann, string course)
        {
            if (!Contain(ann.id))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ClassCourse(CodeClass,nameClass,CodeCourse,[State]) " +
                    "values (@CodeClass,@nameClass,@CodeCourse,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeClass", ann.CodeClass);
                    cm.Parameters.AddWithValue("@nameClass", ann.NameClass);
                    cm.Parameters.AddWithValue("@CodeCourse", course);
                    cm.Parameters.AddWithValue("@State", ann.State);
                    cm.ExecuteNonQuery();
                }
                DAO_ClassCoure_Student dao_ccStudent = new DAO_ClassCoure_Student();
                DAO_ClassCoure_Teacher dao_ccTeacher = new DAO_ClassCoure_Teacher();
                DAO_Lecture dao_lec = new DAO_Lecture();
                foreach (Account_Student item in ann.LstStudent.accounts)
                {
                    dao_ccStudent.Add(ann, item);
                }
                foreach (Account_Teacher item in ann.LstTeacher.accounts)
                {
                    dao_ccTeacher.Add(ann, item);
                }
                foreach (Lecture item in ann.LstLecture.lectures)
                {
                    dao_lec.Add(item);
                }
                db_Uitl.Close();
            }
        }

        public bool Contain(int id)
        {
            foreach (ClassCourse item in GetAll())
            {
                if (id== item.id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(string id)
        {
            DAO_Course dao_course = new DAO_Course();
            if (!dao_course.Contain(id))
                return false;
            return true;
        }
        /// <summary>
        /// fuction kong lấy ra các list
        /// </summary>
        /// <returns></returns>
        public List<ClassCourse> GetAll()
        {
            try
            {
                List<ClassCourse> ls = new List<ClassCourse>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassCourse token = new ClassCourse();
                        token.id = reader.GetInt32(0);
                        token.CodeClass = reader.GetString(1);
                        token.NameClass = reader.GetString(2);
                        token.idCourse = reader.GetInt32(3);
                        token.State = reader.GetInt16(4);
                        ls.Add(token);
                    }
                    reader.Close();
                    db_Uitl.Close();
                }
                return ls;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
                return null;
            }
        }

        /// <summary>
        /// function lấy cả các list
        /// </summary>
        /// <returns></returns>
        public List<ClassCourse> GetAllFull()
        {
            try
            {
                List<ClassCourse> ls = new List<ClassCourse>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassCourse token = new ClassCourse();
                        token.id = reader.GetInt32(0);
                        token.CodeClass = reader.GetString(1);
                        token.NameClass = reader.GetString(2);
                        token.idCourse = reader.GetInt32(3);
                        DAO_Account dao_acc = new DAO_Account();
                        DAO_Lecture dao_lec = new DAO_Lecture();
                        token.LstStudent = new ListAccountStudent(dao_acc.GetStudentInClassCourse(token.id));
                        token.LstTeacher = new ListAccountTeacher( dao_acc.GetTeacherInClassCourse(token.id));
                        token.LstLecture = new ListLecture(dao_lec.GetAll(token.id, 2));
                        ls.Add(token);
                    }
                    reader.Close();
                    db_Uitl.Close();
                }
                return ls;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
                return null;
            }
        }
        /// <summary>
        /// fuction kong lấy ra các list
        /// </summary>
        /// <returns></returns>
        public List<ClassCourse> GetAll(int codeCourse)
        {
            try
            {
                List<ClassCourse> ls = new List<ClassCourse>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse where CodeCourse = '" + codeCourse + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassCourse token = new ClassCourse();
                        token.id = reader.GetInt32(0);
                        token.CodeClass = reader.GetString(1);
                        token.idCourse = reader.GetInt32(3);
                        token.NameClass = reader.GetString(2);
                        token.State = reader.GetInt16(4);
                        ls.Add(token);
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
        /// <summary>
        /// function lấy cả các list
        /// </summary>
        /// <returns></returns>
        public List<ClassCourse> GetAllFull(int codeCourse)
        {
            try
            {
                List<ClassCourse> ls = new List<ClassCourse>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse where CodeCourse = '" + codeCourse + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassCourse token = new ClassCourse();
                        token.id = reader.GetInt32(0);
                        token.CodeClass = reader.GetString(1);
                        token.NameClass = reader.GetString(2);
                        token.idCourse = reader.GetInt32(3);
                        DAO_Account dao_acc = new DAO_Account();
                        DAO_Lecture dao_lec = new DAO_Lecture();
                        token.LstStudent = new ListAccountStudent(dao_acc.GetStudentInClassCourse(token.id));
                        token.LstTeacher = new ListAccountTeacher(dao_acc.GetTeacherInClassCourse(token.id));
                        token.LstLecture = new ListLecture(dao_lec.GetAll(token.id, 2));
                        ls.Add(token);
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

        public ClassCourse GetClassCourse(string id)
        {
            ClassCourse token = new ClassCourse();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse where CodeClass = '" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeClass = reader.GetString(1);
                    token.NameClass = reader.GetString(2);
                    token.idCourse = reader.GetInt32(3);
                    token.State = reader.GetInt16(4);
                    reader.Close();
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
            return token;
        }

        public ClassCourse GetClassCourse(int id)
        {
            ClassCourse token = new ClassCourse();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse where id = '" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeClass = reader.GetString(1);
                    token.idCourse = reader.GetInt32(3);
                    token.NameClass = reader.GetString(2);
                    reader.Close();
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
            return token;
        }

        public ClassCourse GetClassCourseFull(string id)
        {
            ClassCourse token = new ClassCourse();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse where CodeClass = '" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeClass = reader.GetString(1);
                    token.NameClass = reader.GetString(2);
                    DAO_Account dao_acc = new DAO_Account();
                    DAO_Lecture dao_lec = new DAO_Lecture();
                    token.LstStudent = new ListAccountStudent(dao_acc.GetStudentInClassCourse(token.id));
                    token.LstTeacher = new ListAccountTeacher(dao_acc.GetTeacherInClassCourse(token.id));
                    token.LstLecture = new ListLecture(dao_lec.GetAll(token.id, 2));
                    token.idCourse = reader.GetInt32(3);
                    reader.Close();
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
            }
            return token;
        }

        public ClassCourse GetClassCourseFull(int id)
        {
            ClassCourse token = new ClassCourse();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ClassCourse where id = '" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeClass = reader.GetString(1);
                    token.NameClass = reader.GetString(2);
                    DAO_Account dao_acc = new DAO_Account();
                    DAO_Lecture dao_lec = new DAO_Lecture();
                    token.LstStudent = new ListAccountStudent(dao_acc.GetStudentInClassCourse(token.id));
                    token.LstTeacher = new ListAccountTeacher(dao_acc.GetTeacherInClassCourse(token.id));
                    token.LstLecture = new ListLecture(dao_lec.GetAll(token.id, 2));
                    token.idCourse = reader.GetInt32(3);
                    reader.Close();
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
            return token;
        }

        public void Remove(string id)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Delete From ClassCourse where username = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
            }
        }

        public void Remove(int id)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính

                    string sqlQuery = "Delete From ClassCourse where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
        }

        public void Update(ClassCourse ann)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update ClassCourse Set nameClass=@nameClass, CodeCourse=@CodeCourse
                    , State=@State where CodeClass=@CodeClass";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeClass", ann.CodeClass);
                        cm.Parameters.AddWithValue("@nameClass", ann.NameClass);
                        cm.Parameters.AddWithValue("@State", ann.State);
                        cm.ExecuteNonQuery();
                    }
                }
                db_Uitl.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
