using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Database_model.DAO
{
    public class DAO_Comment
    {
        public DAO_Comment()
        {
            db_Uitl.Connect();
        }

        public void Add(Comment acc)
        {
            if (!Contain(acc.Self.Username, acc.TimeComment) && CheckReferences(acc.Self.id))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into [Comment](Self,Content,TimeComment,[State]) values ('@Self','@Content','@TimeComment','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@Self", acc.Self.Username);
                    cm.Parameters.AddWithValue("@Content", acc.Content);
                    cm.Parameters.AddWithValue("@TimeComment", acc.TimeComment);
                    cm.Parameters.AddWithValue("@State", acc.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public void Add(Comment acc, string codeContentLec)
        {
            Add(acc);
            string sqlQuery = "select id from [Comment] " +
                "wherer TimeComment ='" + acc.TimeComment + "' and Self='" + acc.Self.Username + "'";
            SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
            SqlDataReader reader = cm.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            sqlQuery = "Insert into ContentLecComment(CodeContentLec,idComment,[State]) values ('@CodeContentLec','@idComment','@State')";
            using (SqlCommand cm1 = db_Uitl.Conn.CreateCommand())
            {
                cm1.CommandText = sqlQuery;
                cm1.Parameters.AddWithValue("@CodeContentLec", codeContentLec);
                cm1.Parameters.AddWithValue("@idComment", id);
                cm1.Parameters.AddWithValue("@State", 1);
                cm1.ExecuteNonQuery();
            }
        }

        public bool Contain(string id1, SqlDateTime id2)
        {
            foreach (Comment item in GetAll())
            {
                if (id1.Equals(item.Self.Username) && id2.Equals(item.TimeComment))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(int id)
        {
            DAO_Account dao_acc = new DAO_Account();
            if (!dao_acc.Contain(id))
                return false;
            return true;
        }

        public List<Comment> GetAll()
        {
            try
            {
                List<Comment> ls = new List<Comment>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Comment";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment token = new Comment();
                        token.Content = reader.GetString(2);
                        token.TimeComment = reader.GetDateTime(3);
                        token.State = reader.GetInt16(3);
                        DAO_Account dao_acc = new DAO_Account();
                        token.Self = dao_acc.GetAccount(reader.GetString(1));
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
        /// 1: username
        /// 2: contentLec
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Comment> GetAll(string id, int type)
        {
            try
            {
                List<Comment> ls = new List<Comment>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from Comment where self = '" + id + "'";
                    }
                    else
                    {
                        sqlQuery = "select [Commnet].* form [Comment] as a, (Select * from ContentLecComment where CodeContentLec='" + id + "') as b" +
                            "where a.id = b.idComment";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment token = new Comment();
                        token.Content = reader.GetString(2);
                        token.TimeComment = reader.GetDateTime(3);
                        token.State = reader.GetInt16(3);
                        DAO_Account dao_acc = new DAO_Account();
                        token.Self = dao_acc.GetAccount(reader.GetString(1));
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

        public Comment GetComment(string id, SqlDateTime timecmt)
        {
            Comment token = new Comment();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Comment where Self = N'" + id + "' and timeComment = '" + timecmt + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.Content = reader.GetString(2);
                    token.TimeComment = reader.GetDateTime(3);
                    token.State = reader.GetInt16(3);
                    DAO_Account dao_acc = new DAO_Account();
                    token.Self = dao_acc.GetAccount(reader.GetString(1));
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Comment GetComment(int id)
        {
            Comment token = new Comment();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Comment where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.Content = reader.GetString(2);
                    token.TimeComment = reader.GetDateTime(3);
                    token.State = reader.GetInt16(3);
                    DAO_Account dao_acc = new DAO_Account();
                    token.Self = dao_acc.GetAccount(reader.GetString(1));
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
                    string sqlQuery = "Update Comment Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Comment Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Comment acc)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Comment Set Content=@Content, [State]=@State 
                                where Self=@Self and TimeComment=@TimeComment";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@Self", acc.Self);
                        cm.Parameters.AddWithValue("@Content", acc.Content);
                        cm.Parameters.AddWithValue("@TimeComment", acc.TimeComment);
                        cm.Parameters.AddWithValue("@State", acc.State);
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
