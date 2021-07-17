using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Database_model.DAO
{
    public class DAO_Lecture_Class
    {
        public DAO_Lecture_Class()
        {
            db_Uitl.Connect();
        }

        public void Add(Lecture_Class lec)
        {
            if (!Contain(lec.CodeLecture))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into LectureClass(CodeLecture,CodeClass,DayAdd,[State]) " +
                    "values ('@CodeLecture','@CodeClass','@DayAdd','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeLecture", lec.CodeLecture);
                    cm.Parameters.AddWithValue("@DayAdd", lec.DayAdd);
                    cm.Parameters.AddWithValue("@State", lec.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Add(int idLec, int idClass)
        {
            db_Uitl.Connect();
            try
            {
                string sqlQuery = "Insert into LectureClass(CodeLecture,CodeClass,DayAdd,[State]) " +
                "values (@CodeLecture,@CodeClass,@DayAdd,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeLecture", idLec);
                    cm.Parameters.AddWithValue("@CodeClass", idClass);
                    cm.Parameters.AddWithValue("@DayAdd", new SqlDateTime(DateTime.Now));
                    cm.Parameters.AddWithValue("@State", 1);
                    cm.ExecuteNonQuery();
                    db_Uitl.Close();
                    return true;
                }
            }
            catch(Exception e)
            {
                e.ToString();
                db_Uitl.Close();
                return false;
            }
        }

        public bool Contain(string codeLec)
        {
            foreach (Lecture_Class item in GetAll())
            {
                if (codeLec.Equals(item.CodeLecture))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(int codeLec, string codeClass)
        {
            DAO_ClassCourse dao_class = new DAO_ClassCourse();
            DAO_Lecture dao_lec = new DAO_Lecture();
            if (!dao_class.Contain(codeLec))
                return false;
            if (!dao_lec.Contain(codeClass))
                return false;
            return true;
        }

        public List<Lecture_Class> GetAll()
        {
            try
            {
                List<Lecture_Class> ls = new List<Lecture_Class>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Lecture_Class";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Lecture_Class token = new Lecture_Class();
                        DAO_Lecture dao_lec = new DAO_Lecture();
                        DAO_ClassCourse dao_CS = new DAO_ClassCourse();
                        Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                        token.CodeLecture = tempLec.CodeLecture;
                        token.DayCreate = tempLec.DayCreate;
                        token.Decription = tempLec.Decription;
                        token.Header = tempLec.Header;
                        token.LstConLec = tempLec.LstConLec;
                        token.State = reader.GetInt32(4);
                        token.DayAdd = reader.GetDateTime(3);
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
        /// 2: CodeClass
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Lecture_Class> GetAll(string id, int type)
        {
            try
            {
                List<Lecture_Class> ls = new List<Lecture_Class>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from Lecture_Class where CodeLecture = '" + id + "'";
                    }
                    else
                    {
                        sqlQuery = "Select * from Lecture_Class where CodeClass = '" + id + "'";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Lecture_Class token = new Lecture_Class();
                        DAO_Lecture dao_lec = new DAO_Lecture();
                        DAO_ClassCourse dao_CS = new DAO_ClassCourse();
                        Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                        token.CodeLecture = tempLec.CodeLecture;
                        token.DayCreate = tempLec.DayCreate;
                        token.Decription = tempLec.Decription;
                        token.Header = tempLec.Header;
                        token.LstConLec = tempLec.LstConLec;
                        token.State = reader.GetInt32(4);
                        token.DayAdd = reader.GetDateTime(3);
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

        public Lecture_Class GetLecture_Class(string codeLec, string codeClass)
        {
            Lecture_Class token = new Lecture_Class();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Lecture_Class where CodeLecture = N'" + codeLec + "' and CodeClass = '" + codeClass + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Lecture dao_lec = new DAO_Lecture();
                    DAO_ClassCourse dao_CS = new DAO_ClassCourse();
                    Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                    token.CodeLecture = tempLec.CodeLecture;
                    token.DayCreate = tempLec.DayCreate;
                    token.Decription = tempLec.Decription;
                    token.Header = tempLec.Header;
                    token.LstConLec = tempLec.LstConLec;
                    token.State = reader.GetInt32(4);
                    token.DayAdd = reader.GetDateTime(3);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Lecture_Class GetLecture_Class(int id)
        {
            Lecture_Class token = new Lecture_Class();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Lecture_Class where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Lecture dao_lec = new DAO_Lecture();
                    DAO_ClassCourse dao_CS = new DAO_ClassCourse();
                    Lecture tempLec = dao_lec.GetLecture(reader.GetString(1));
                    token.CodeLecture = tempLec.CodeLecture;
                    token.DayCreate = tempLec.DayCreate;
                    token.Decription = tempLec.Decription;
                    token.Header = tempLec.Header;
                    token.LstConLec = tempLec.LstConLec;
                    token.State = reader.GetInt32(4);
                    token.DayAdd = reader.GetDateTime(3);
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
                    string sqlQuery = "Update Lecture_Class Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Lecture_Class Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Lecture_Class lec)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Lecture_Class Set [State]=@State 
                                where CodeLecture=@CodeLecture and CodeClass=@CodeClass";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeLecture", lec.CodeLecture);
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
