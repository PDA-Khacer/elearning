using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Database_model.DAO
{
    public class DAO_Announcement
    {
        public DAO_Announcement()
        {
            //db_Uitl.Connect();
        }

        public void Add(Announcement ann)
        {
            if (!Contain(ann.DayCreate, ann.UserRecive.Username, ann.UserSent.Username) &&
                CheckReferences(ann.UserRecive.id, ann.UserSent.id))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Announcement ('@DayCreate','@UserRecive','@DayUpload','@Title','@Content','@UserSend', '@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@DayCreate", ann.DayCreate);
                    cm.Parameters.AddWithValue("@UserRecive", ann.UserRecive.Username);
                    cm.Parameters.AddWithValue("@DayUpload", ann.DayUpLoad);
                    cm.Parameters.AddWithValue("@Title", ann.Header);
                    cm.Parameters.AddWithValue("@Content", ann.Content);
                    cm.Parameters.AddWithValue("@UserSend", ann.UserSent.Username);
                    cm.Parameters.AddWithValue("@State", ann.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(SqlDateTime id1, string id2, string id3)
        {
            foreach (Announcement item in GetAll())
            {
                if (id1.Equals(item.DayCreate) &&
                    id2.Equals(item.UserRecive.Username) &&
                    id3.Equals(item.UserSent.Username))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(int id1, int id2)
        {
            DAO_Account dao_acc = new DAO_Account();
            if (!dao_acc.Contain(id1))
                return false;
            if (!dao_acc.Contain(id2))
                return false;
            return true;
        }

        public List<Announcement> GetAll()
        {
            try
            {
                List<Announcement> ls = new List<Announcement>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Announcement";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Announcement token = new Announcement();
                        token.DayCreate = reader.GetDateTime(1);
                        DAO_Account dao_acc = new DAO_Account();
                        Account acc = dao_acc.GetAccount(reader.GetString(2));
                        token.UserRecive = acc;
                        token.DayUpLoad = reader.GetDateTime(3);
                        token.Header = reader.GetString(4);
                        token.Content = reader.GetString(5);
                        acc = dao_acc.GetAccount(reader.GetString(6));
                        token.UserSent = acc;
                        token.State = reader.GetInt16(7);
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

        public List<Announcement> GetAll(string username)
        {
            try
            {
                List<Announcement> ls = new List<Announcement>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    
                    string sqlQuery = "Select * from Announcement where UserRecive = '" + username + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Announcement token = new Announcement();
                        token.DayCreate = reader.GetDateTime(1);
                        DAO_Account dao_acc = new DAO_Account();
                        Account acc = dao_acc.GetAccount(username);
                        token.UserRecive = acc;
                        token.DayUpLoad = reader.GetDateTime(3);
                        token.Header = reader.GetString(4);
                        token.Content = reader.GetString(5);
                        acc = dao_acc.GetAccount(reader.GetString(6));
                        token.UserSent = acc;
                        token.State = reader.GetInt16(7);
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

        public Announcement GetAnnouncement(SqlDateTime id1, string id2, string id3)
        {
            Announcement token = new Announcement();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Announcement where DayCreate = '" + id1 +
                        "' and UserRecive='" + id2 + "' and UserSend='" + id3 + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.DayCreate = reader.GetDateTime(1);
                    DAO_Account dao_acc = new DAO_Account();
                    Account acc = dao_acc.GetAccount(reader.GetString(2));
                    token.UserRecive = acc;
                    token.DayUpLoad = reader.GetDateTime(3);
                    token.Header = reader.GetString(4);
                    token.Content = reader.GetString(5);
                    acc = dao_acc.GetAccount(reader.GetString(6));
                    token.UserSent = acc;
                    token.State = reader.GetInt16(7);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Announcement GetAnnouncement(int id)
        {
            Announcement token = new Announcement();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Announcement where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.DayCreate = reader.GetDateTime(1);
                    DAO_Account dao_acc = new DAO_Account();
                    Account acc = dao_acc.GetAccount(reader.GetString(2));
                    token.UserRecive = acc;
                    token.DayUpLoad = reader.GetDateTime(3);
                    token.Header = reader.GetString(4);
                    token.Content = reader.GetString(5);
                    acc = dao_acc.GetAccount(reader.GetString(6));
                    token.UserSent = acc;
                    token.State = reader.GetInt16(7);
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
                    string sqlQuery = "Delete From Announcement where username = N'" + id + "'";
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
                    string sqlQuery = "Delete From Announcement where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Announcement ann)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Announcement Set DayCreate=@DayCreate, Header=@Header, Content=@Content, [State]=@State 
                        where UserRecive=@UserRecive and DayUpload=@DayUpload and UserSend=@UserSend";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@UserRecive", ann.UserRecive);
                        cm.Parameters.AddWithValue("@DayUpload", ann.DayUpLoad);
                        cm.Parameters.AddWithValue("@UserSend", ann.UserSent);
                        cm.Parameters.AddWithValue("@DayCreate", ann.DayCreate);
                        cm.Parameters.AddWithValue("@Header", ann.Header);
                        cm.Parameters.AddWithValue("@Content", ann.Content);
                        cm.Parameters.AddWithValue("@State", ann.State);
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
