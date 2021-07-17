using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Database_model.DAO
{
    public class DAO_Topic
    {
        public DAO_Topic()
        {
            db_Uitl.Connect();
        }

        public void Add(Topic topic)
        {
            if (!Contain(topic.CodeTopic) )
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Topic(CodeTopic,header,decription,dayCreate,Self,CodeContentLec,[State]) " +
                    "values (@CodeTopic,@header,@decription,@dayCreate,@Self,@CodeContentLec,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeTopic", topic.CodeTopic);
                    cm.Parameters.AddWithValue("@header", topic.Header);
                    cm.Parameters.AddWithValue("@decription", topic.Decription);
                    cm.Parameters.AddWithValue("@dayCreate", topic.DayCreate);
                    cm.Parameters.AddWithValue("@Self", topic.Self.Username);
                    cm.Parameters.AddWithValue("@State", topic.State);
                    cm.ExecuteNonQuery();
                    // add listComment
                    DAO_Comment dao_com = new DAO_Comment();
                    DAO_Coment_Topic dao_com_top = new DAO_Coment_Topic();
                    foreach (Comment item in topic.LstComment)
                    {
                        dao_com.Add(item);
                        dao_com_top.Add(item, topic.CodeTopic);
                    }
                }
            }
        }

        public bool Contain(string CodeTopic)
        {
            foreach (Topic item in GetAll())
            {
                if (CodeTopic.Equals(item.CodeTopic))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(int CodeContentLec, int Self)
        {
            DAO_Account dao_acc = new DAO_Account();
            DAO_ContentLec dao_cont = new DAO_ContentLec();
            if (!dao_acc.Contain(Self))
                return false;
            if (!dao_acc.Contain(CodeContentLec))
                return false;
            return true;
        }

        public List<Topic> GetAll()
        {
            try
            {
                List<Topic> ls = new List<Topic>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Topic";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Topic token = new Topic();

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

        public List<Topic> GetAll(string username)
        {
            try
            {
                List<Topic> ls = new List<Topic>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Topic where UserRecive = '" + username + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Topic token = new Topic();
                        token.DayCreate = reader.GetDateTime(1);
                        
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

        public Topic GetTopic(SqlDateTime id1, string id2, string id3)
        {
            Topic token = new Topic();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Topic where DayCreate = '" + id1 +
                        "' and UserRecive='" + id2 + "' and UserSend='" + id3 + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.DayCreate = reader.GetDateTime(1);
                    
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Topic GetTopic(int id)
        {
            Topic token = new Topic();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Topic where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.DayCreate = reader.GetDateTime(1);
                   
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
                    string sqlQuery = "Delete From Topic where username = N'" + id + "'";
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
                    string sqlQuery = "Delete From Topic where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Topic topic)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Topic Set DayCreate=@DayCreate, Header=@Header, Content=@Content, [State]=@State 
                        where UserRecive=@UserRecive and DayUpload=@DayUpload and UserSend=@UserSend";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                      
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
