
using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Lecture
    {
        public DAO_Lecture()
        {
            //db_Uitl.Connect();
        }

        public void Add(Lecture lec)
        {
            if (!Contain(lec.CodeLecture))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Lecture(CodeLecture,Header,Decription,Self,[State]) " +
                    "values ('@CodeLecture','@Header','@Decription','@Self','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeLecture", lec.CodeLecture);
                    cm.Parameters.AddWithValue("@Header", lec.Header);
                    cm.Parameters.AddWithValue("@Decription", lec.Decription);
                    cm.Parameters.AddWithValue("@State", lec.State);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
        }
        public bool Add(string codeLec, string header, string description, int idCourse, int idAcc)
        {
            if (!Contain(codeLec))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Lecture(CodeLecture,Header,Decription,idCourse,Self,[State]) " +
                    "values (@CodeLecture,@Header,@Decription,@idCourse,@Self,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeLecture", codeLec);
                    cm.Parameters.AddWithValue("@Header", header);
                    cm.Parameters.AddWithValue("@Decription", description);
                    cm.Parameters.AddWithValue("@idCourse", idCourse);
                    cm.Parameters.AddWithValue("@Self", idAcc);
                    cm.Parameters.AddWithValue("@State", 1);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
                return true;
            }
            db_Uitl.Close();
            return false;
        }



        public bool Contain(string id)
        {
            foreach (Lecture item in GetAll())
            {
                if (id.Equals(item.CodeLecture))
                {
                    return true;
                }
            }
            return false;
        }

        //public bool CheckReferences(string id)
        //{
        //    DAO_Account_Teacher dao_tea = new DAO_Account_Teacher();
        //    if (!dao_tea.Contain(id))
        //        return false;
        //    return true;
        //}

        public List<Lecture> GetAll()
        {
            try
            {
                List<Lecture> ls = new List<Lecture>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    
                    string sqlQuery = "Select * from Lecture";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Lecture token = new Lecture();
                        token.id = reader.GetInt32(0);
                        token.CodeLecture = reader.GetString(1);
                        token.Header = reader.GetString(2);
                        token.Decription = reader.GetString(3);
                        token.State = reader.GetInt16(6);
                        DAO_Account dao = new DAO_Account();
                        token.Self = dao.GetAccountTeacher(reader.GetInt32(5));
                        //DAO_ContentLec DAO_conL = new DAO_ContentLec();
                        //token.LstConLec = DAO_conL.GetAll(reader.GetString(4), 2);
                        ls.Add(token);
                    }
                    reader.Close(); 
                }
                db_Uitl.Close();
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
        /// 1: Self
        /// 2: CodeClass
        /// </summary>
        /// <param name="username"></param>
        /// <param name="type"></param>1
        /// <returns></returns>
        public List<Lecture> GetAll(int id, int type)
        {
            try
            {
                List<Lecture> ls = new List<Lecture>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from Lecture where Self = " + id;
                    }
                    else
                    {
                        sqlQuery = "Select Lecture.* from Lecture inner join (Select * from LectureClass where CodeClass = "+id+") as b on Lecture.id = b.CodeLecture";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {            
                        Lecture token = new Lecture();
                        token.id = reader.GetInt32(0);
                        token.CodeLecture = reader.GetString(1);
                        token.Header = reader.GetString(2);
                        token.Decription = reader.GetString(3);
                        token.State = reader.GetInt16(6);
                        //DAO_ContentLec DAO_conL = new DAO_ContentLec();
                        DAO_Account dao = new DAO_Account();
                        token.Self = dao.GetAccountTeacher(reader.GetInt32(5));
                        //token.LstConLec = DAO_conL.GetAll(reader.GetString(4), 2);
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

        public Lecture GetLecture(string codeLec)
        {
            Lecture token = new Lecture();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Lecture where CodeLecture = N'" + codeLec + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeLecture = reader.GetString(1);
                    token.Header = reader.GetString(2);
                    token.Decription = reader.GetString(3);
                    token.State = reader.GetInt16(6);
                    DAO_Account dao = new DAO_Account();
                    token.Self = dao.GetAccountTeacher(reader.GetInt32(5));
                    //DAO_ContentLec DAO_conL = new DAO_ContentLec();
                    //token.LstConLec = DAO_conL.GetAll(reader.GetString(4), 2);
                    reader.Close();
                }
                db_Uitl.Close();
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
            }
            return token;
        }

        public Lecture GetLecture(int id)
        {
            Lecture token = new Lecture();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Lecture where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeLecture = reader.GetString(1);
                    token.Header = reader.GetString(2);
                    token.Decription = reader.GetString(3);
                    token.State = reader.GetInt16(6);
                    DAO_Account dao = new DAO_Account();
                    token.Self = dao.GetAccountTeacher(reader.GetInt32(5));
                    //DAO_ContentLec DAO_conL = new DAO_ContentLec();
                    //token.LstConLec = DAO_conL.GetAll(reader.GetString(4), 2);
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
                    string sqlQuery = "Update Lecture Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Lecture Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Lecture lec)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Lecture Set Header=@Header,Decription=@Decription,Self=@Self,[State]=@State 
                                where CodeLecture=@CodeLecture";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeLecture", lec.CodeLecture);
                        cm.Parameters.AddWithValue("@Header", lec.Header);
                        cm.Parameters.AddWithValue("@Decription", lec.Decription);
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


