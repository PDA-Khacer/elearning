using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Lecture_Student
    {
        public DAO_Lecture_Student()
        {
            db_Uitl.Connect();
        }

        public void Add(Lecture_Student lec)
        {
            if (!Contain(lec.CodeLecture, lec.Student.Username)
                && CheckReferences(lec.id, lec.Student.id))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into LectureClass(CodeLecture,CodeStudent,isComplete,PercentComplete,DayComplete,[State]) " +
                    "values ('@CodeLecture','@CodeStudent','@isComplete','@PercentComplete','@DayComplete','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeLecture", lec.CodeLecture);
                    cm.Parameters.AddWithValue("@CodeStudent", lec.Student.Username);
                    cm.Parameters.AddWithValue("@isComplete", lec.isComplete);
                    cm.Parameters.AddWithValue("@PercentComplete", lec.PercentComplete);
                    cm.Parameters.AddWithValue("@DayComplete", lec.DayComplete);
                    cm.Parameters.AddWithValue("@State", lec.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(string codeLec, string username)
        {
            foreach (Lecture_Student item in GetAll())
            {
                if (codeLec.Equals(item.CodeLecture)
                && username.Equals(item.Student.Username))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(int codeLec, int username)
        {
            DAO_ClassCourse dao_class = new DAO_ClassCourse();
            DAO_Account dao_acc = new DAO_Account();
            if (!dao_class.Contain(codeLec))
                return false;
            if (!dao_acc.Contain(username))
                return false;
            return true;
        }

        public List<Lecture_Student> GetAll()
        {
            try
            {
                List<Lecture_Student> ls = new List<Lecture_Student>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Lecture_Student";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Lecture_Student token = new Lecture_Student();
                        DAO_Lecture dao_lec = new DAO_Lecture();
                        DAO_Account dao_acc = new DAO_Account();
                        Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                        token.CodeLecture = tempLec.CodeLecture;
                        token.DayCreate = tempLec.DayCreate;
                        token.Decription = tempLec.Decription;
                        token.Header = tempLec.Header;
                       
                        token.LstConLec = tempLec.LstConLec;
                        token.State = reader.GetInt16(6);
                        token.Student = new Account_Student(dao_acc.GetAccount(reader.GetString(2)));
                        token.isComplete = reader.GetBoolean(3);
                        token.PercentComplete = reader.GetFloat(4);
                        token.DayComplete = reader.GetDateTime(5);
                        ls.Add(token);
                    }
                    reader.Close();
                }
                return ls;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        /// <summary>
        /// 1: CodeLecture
        /// 2: CodeStudent
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Lecture_Student> GetAll(string id, int type)
        {
            try
            {
                List<Lecture_Student> ls = new List<Lecture_Student>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from Lecture_Student where CodeLecture = '" + id + "'";
                    }
                    else
                    {
                        sqlQuery = "Select * from Lecture_Student where CodeStudent = '" + id + "'";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Lecture_Student token = new Lecture_Student();
                        DAO_Lecture dao_lec = new DAO_Lecture();
                        DAO_Account dao_acc = new DAO_Account();
                        Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                        token.CodeLecture = tempLec.CodeLecture;
                        token.DayCreate = tempLec.DayCreate;
                        token.Decription = tempLec.Decription;
                        token.Header = tempLec.Header;
                       
                        token.LstConLec = tempLec.LstConLec;
                        token.State = reader.GetInt16(6);
                        token.Student = new Account_Student(dao_acc.GetAccount(reader.GetString(2)));
                        token.isComplete = reader.GetBoolean(3);
                        token.PercentComplete = reader.GetFloat(4);
                        token.DayComplete = reader.GetDateTime(5);
                        ls.Add(token);
                    }
                    reader.Close();
                }
                return ls;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Lecture_Student GetLecture_Student(string codeLec, string CodeStudent)
        {
            Lecture_Student token = new Lecture_Student();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Lecture_Student where CodeLecture = N'" + codeLec + "' and CodeStudent = '" + CodeStudent + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Lecture dao_lec = new DAO_Lecture();
                    DAO_Account dao_acc = new DAO_Account();
                    Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                    token.CodeLecture = tempLec.CodeLecture;
                    token.DayCreate = tempLec.DayCreate;
                    token.Decription = tempLec.Decription;
                    token.Header = tempLec.Header;
                   
                    token.LstConLec = tempLec.LstConLec;
                    token.State = reader.GetInt16(6);
                    token.Student = new Account_Student(dao_acc.GetAccount(reader.GetString(2)));
                    token.isComplete = reader.GetBoolean(3);
                    token.PercentComplete = reader.GetFloat(4);
                    token.DayComplete = reader.GetDateTime(5);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Lecture_Student GetLecture_Student(int id)
        {
            Lecture_Student token = new Lecture_Student();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Lecture_Student where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Lecture dao_lec = new DAO_Lecture();
                    DAO_Account dao_acc = new DAO_Account();
                    Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                    token.CodeLecture = tempLec.CodeLecture;
                    token.DayCreate = tempLec.DayCreate;
                    token.Decription = tempLec.Decription;
                    token.Header = tempLec.Header;
                   
                    token.LstConLec = tempLec.LstConLec;
                    token.State = reader.GetInt16(6);
                    token.Student = new Account_Student(dao_acc.GetAccount(reader.GetString(2)));
                    token.isComplete = reader.GetBoolean(3);
                    token.PercentComplete = reader.GetFloat(4);
                    token.DayComplete = reader.GetDateTime(5);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public void Remove(string id)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Update Lecture_Student Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Lecture_Student Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Lecture_Student lec)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Lecture_Student Set isComplete=@isComplete,PercentComplete=@PercentComplete,DayComplete=@DayComplete,[State]=@State 
                                where CodeLecture=@CodeLecture and CodeStudent=@CodeStudent";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeLecture", lec.CodeLecture);
                        cm.Parameters.AddWithValue("@CodeStudent", lec.Student.Username);
                        cm.Parameters.AddWithValue("@isComplete", lec.isComplete);
                        cm.Parameters.AddWithValue("@PercentComplete", lec.PercentComplete);
                        cm.Parameters.AddWithValue("@DayComplete", lec.DayComplete);
                        cm.Parameters.AddWithValue("@State", lec.State);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
