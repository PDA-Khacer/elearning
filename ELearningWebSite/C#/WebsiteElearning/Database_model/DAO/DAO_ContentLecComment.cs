using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_ContentLecComment
    {
        public void Add(Comment acc, string CodeTopic)
        {
            string sqlQuery = "Insert into ContentLecComment(CodeContentLec,idComment,[State]) " +
                "values ('@CodeContentLec','@idComment','@State')";
            using (SqlCommand cm1 = db_Uitl.Conn.CreateCommand())
            {
                cm1.CommandText = sqlQuery;
                cm1.Parameters.AddWithValue("@CodeContentLec", CodeTopic);
                cm1.Parameters.AddWithValue("@idComment", acc.id);
                cm1.Parameters.AddWithValue("@State", 1);
                cm1.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 1: CodeContentLec
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
                        sqlQuery = "select b.*  from (select * from ContentLecComment where CodeContentLec = '" + id + "') as a full join [Comment] as b" +
                           "on a.idComment = b.id";
                    }
                    else
                    {
                        sqlQuery = "";
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

        public List<Comment> GetAllCommentOfAccountAtContentLecture(Account acc, ContentLec con)
        {
            List<Comment> lstComment = new List<Comment>();
            string sqlQuery = "select b.*  from (select * from ContentLecComment where CodeContentLec = '" + con.CodeContentLec + "') as a " +
                "full join (select [comment].* from [Comment] where Self ='" + acc.Username + "') as b" +
                           "on a.idComment = b.id";
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
                lstComment.Add(token);
            }
            reader.Close();
            return lstComment;
        }
    }
}
