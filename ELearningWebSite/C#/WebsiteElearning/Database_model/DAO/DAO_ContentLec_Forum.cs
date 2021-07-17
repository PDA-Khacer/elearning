using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_ContentLec_Forum : DAO_ContentLec
    {
        public override void Add(ContentLec conlec)
        {
            ContentLec_Forum com = conlec as ContentLec_Forum;
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

        public override List<ContentLec> GetAll()
        {
            try
            {
                List<ContentLec> ls = new List<ContentLec>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from ContentLec";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ContentLec_Forum token = new ContentLec_Forum();
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        
                        token.State = reader.GetInt16(14);
                        token.TypeContentLec = "3";
                        //token.LstTopic = token3;
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
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

        public override List<ContentLec> GetAll(string id, int type)
        {
            try
            {
                List<ContentLec> ls = new List<ContentLec>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
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
                        ContentLec_Forum token = new ContentLec_Forum();
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        
                        token.State = reader.GetInt16(14);
                        token.TypeContentLec = "3";
                        //token.LstTopic = token3;
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
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

        public override ContentLec GetContentLec(string id)
        {
            ContentLec_Forum token = new ContentLec_Forum();
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
                    
                    token.State = reader.GetInt16(14);
                    token.TypeContentLec = "3";
                    //token.LstTopic = token3;
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public override ContentLec GetContentLec(int id)
        {
            ContentLec_Forum token = new ContentLec_Forum();
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
                    
                    token.State = reader.GetInt16(14);
                    token.TypeContentLec = "3";
                    //token.LstTopic = token3;
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public override void Update(ContentLec comLe)
        {
            ContentLec_Forum com = comLe as ContentLec_Forum;
            try
            {
                if (db_Uitl.isLive() )
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update ContentLec Set header=@header,decription=@decription,DayOpen=@DayOpen,
                                DayClose=@DayClose,CodeLecture=@CodeLecture,Self=@Self,[State]=@State 
                                where CodeContentLec=@CodeContentLec";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeContentLec", com.Header);
                        cm.Parameters.AddWithValue("@decription", com.Decription);
                        cm.Parameters.AddWithValue("@DayOpen", com.DayOpen);
                        cm.Parameters.AddWithValue("@DayClose", com.DayClose);
                        //cm.Parameters.AddWithValue("@CodeLecture", com.OwnsLecture.CodeLecture);
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
