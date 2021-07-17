using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_ContentLec
    {
        public DAO_ContentLec()
        {
            db_Uitl.Connect();
        }

        public virtual void Add(ContentLec com)
        {
            if (!Contain(com.CodeContentLec))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ContentLec(CodeContentLec,dayCreate,header,Decription,DayOpen,DayClose,CodeLecture,Self,[State]) " +
                    "values (@CodeContentLec,@dayCreate,@header,@Decription,@DayOpen,@DayClose,@CodeLecture,@Self,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeContentLec", com.CodeContentLec);
                    cm.Parameters.AddWithValue("@dayCreate", com.DayCreate);
                    cm.Parameters.AddWithValue("@header", com.Header);
                    cm.Parameters.AddWithValue("@Decription", com.Decription);
                    cm.Parameters.AddWithValue("@DayOpen", com.DayOpen);
                    cm.Parameters.AddWithValue("@DayClose", com.DayClose);
                    cm.Parameters.AddWithValue("@Self", com.Self.Username);
                    cm.Parameters.AddWithValue("@State", com.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(string id)
        {
            foreach (ContentLec item in GetAll())
            {
                if (id.Equals(item.CodeContentLec))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(int id)
        {
            DAO_Account dao_com = new DAO_Account();
            if (!dao_com.Contain(id))
                return false;
            return true;
        }

        public virtual List<ContentLec> GetAll()
        {
            try
            {
                List<ContentLec> ls = new List<ContentLec>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    
                    string sqlQuery = "Select * from ContentLec";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ContentLec token = new ContentLec();
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
                        token.State = reader.GetInt16(14);
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
        ///  type = 1 <=> Lecture
        ///  type = 2 <=> Teacher
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual List<ContentLec> GetAll(string id, int type)
        {
            try
            {
                List<ContentLec> ls = new List<ContentLec>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from ContentLec where CodeLecture = '" + id + "'";
                    }
                    else
                    {
                        sqlQuery = "Select * from ContentLec where self = '" + id + "'";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ContentLec token = new ContentLec();
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
                        token.State = reader.GetInt16(14);
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

        public virtual ContentLec GetContentLec(string id)
        {
            ContentLec token = new ContentLec();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ContentLec where CodeContentLec = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeContentLec = reader.GetString(1);
                    token.DayCreate = reader.GetDateTime(2);
                    token.Header = reader.GetString(3);
                    token.Decription = reader.GetString(4);
                    token.DayOpen = reader.GetDateTime(5);
                    token.DayClose = reader.GetDateTime(6);
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
                    token.State = reader.GetInt16(14);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public virtual ContentLec GetContentLec(int id)
        {
            ContentLec token = new ContentLec();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ContentLec where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeContentLec = reader.GetString(1);
                    token.DayCreate = reader.GetDateTime(2);
                    token.Header = reader.GetString(3);
                    token.Decription = reader.GetString(4);
                    token.DayOpen = reader.GetDateTime(5);
                    token.DayClose = reader.GetDateTime(6);
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;

                    token.State = reader.GetInt16(14);
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
                    string sqlQuery = "Update ContentLec Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update ContentLec Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public virtual void Update(ContentLec com)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update ContentLec Set header=@header,decription=@decription,DayOpen=@DayOpen,
                                DayClose=@DayClose,CodeLecture=@CodeLecture,Self=@Self,[State]=@State 
                                where CodeContentLec=@CodeContentLec ";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeContentLec", com.Header);
                        cm.Parameters.AddWithValue("@decription", com.Decription);
                        cm.Parameters.AddWithValue("@DayOpen", com.DayOpen);
                        cm.Parameters.AddWithValue("@DayClose", com.DayClose);
                        cm.Parameters.AddWithValue("@Self", com.Self.Username);
                        cm.Parameters.AddWithValue("@State", com.State);
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
