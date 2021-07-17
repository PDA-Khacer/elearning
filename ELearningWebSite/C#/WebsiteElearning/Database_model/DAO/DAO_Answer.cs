using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Answer
    {
        public DAO_Answer()
        {
            //db_Uitl.Connect();
        }

        /// <summary>
        ///  1: Câu trả lời bt
        ///  2: Câu trả lời của sinh viên
        /// </summary>
        /// <param name="ans"></param>
        /// <param name="type"></param>
        public void Add(Answer ans, string references, int type)
        {
            db_Uitl.Connect();
            string sqlQuery = "Insert into Answer(CodeAnswer,CharOrder,ContentQ,Img,ChoseTime,ChoseTime,CodeQuestion,[State],Self) " +
                    "values (@CodeAnswer,@CharOrder,@ContentQ,@Img,@Content,@ChoseTime ,@CodeQuestion, @State)";
            using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
            {
                cm.CommandText = sqlQuery;
                cm.Parameters.AddWithValue("@CodeAnswer", ans.CodeAnswer);
                cm.Parameters.AddWithValue("@CharOrder", ans.CharOrder);
                cm.Parameters.AddWithValue("@ContentQ", ans.ContentQ);
                cm.Parameters.AddWithValue("@Img", ans.Imgs);
                cm.Parameters.AddWithValue("@CodeQuestion", references);
                cm.Parameters.AddWithValue("@State", ans.State);
                if (type == 1)
                {
                    cm.Parameters.AddWithValue("@ChoseTime", "");
                    cm.Parameters.AddWithValue("@Self", "");
                }
                else
                {
                    cm.Parameters.AddWithValue("@ChoseTime", (ans as Answer_Student).ChoseTime);
                    cm.Parameters.AddWithValue("@Self", (ans as Answer_Student).Self.Username);
                }
                cm.ExecuteNonQuery();
            }

        }

        public bool AddMCQ(string codeAnswer, string charOrder, string content, string img, int codeQuestion)
        {
            try
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Answer(CodeAnswer,CharOrder,ContentQ,Img,CodeQuestion,[State]) " +
                        "values (@CodeAnswer,@CharOrder,@ContentQ,@Img,@CodeQuestion,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeAnswer", codeAnswer);
                    cm.Parameters.AddWithValue("@CharOrder", charOrder);
                    cm.Parameters.AddWithValue("@ContentQ", content);
                    cm.Parameters.AddWithValue("@Img", img);
                    cm.Parameters.AddWithValue("@CodeQuestion", codeQuestion);
                    cm.Parameters.AddWithValue("@State", 1);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
                return true;
            }
            catch(Exception e)
            { e.ToString();
                db_Uitl.Close();
                return false;
            }
            
        }

        public bool Contain(string id)
        {
            foreach (Answer item in GetAll())
            {
                if (id.Equals(item.CodeAnswer))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(string id)
        {
            DAO_Question dao_qus = new DAO_Question();
            if (!dao_qus.Contain(id))
                return false;
            return true;
        }

        public List<Answer> GetAll()
        {
            try
            {
                List<Answer> ls = new List<Answer>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Answer";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read() && reader.GetInt16(7) != 1)
                    {
                        Answer token = new Answer();
                        token.id = reader.GetInt16(0);
                        token.CodeAnswer = reader.GetString(1);
                        token.CharOrder = reader.GetString(2);
                        token.ContentQ = reader.GetString(3);
                        token.Imgs = reader.GetString(4);
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
        /// <summary>
        /// 1. lấy ra câu trả lời của câu hỏi
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Answer> GetAll(string queryString, int type)
        {
            try
            {
                List<Answer> ls = new List<Answer>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Answer where CodeQuestion = '" + queryString + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Answer token = new Answer();
                        token.id = reader.GetInt16(0);
                        token.CodeAnswer = reader.GetString(1);
                        token.CharOrder = reader.GetString(2);
                        token.ContentQ = reader.GetString(3);
                        token.Imgs = reader.GetString(4);
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

        /// <summary>
        /// lấy ra tất cả câu trả lời của sinh viên với câu hỏi đó
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public List<Answer_Student> GetAnswerOfQuestion(string queryString)
        {
            try
            {
                List<Answer_Student> ls = new List<Answer_Student>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Answer where CodeQuestion = '" + queryString + "' and self is not null";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Answer_Student token = new Answer_Student();
                        token.id = reader.GetInt16(0);
                        token.CodeAnswer = reader.GetString(1);
                        token.CharOrder = reader.GetString(2);
                        token.ContentQ = reader.GetString(3);
                        token.Imgs = reader.GetString(4);
                        token.State = reader.GetInt16(7);
                        token.ChoseTime = reader.GetSqlDateTime(5);
                        DAO_Account dao_acc = new DAO_Account();
                        token.Self = dao_acc.GetAccountStudent(reader.GetString(8));
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

        public Answer GetAnswer(string id)
        {
            Answer token = new Answer();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Answer where CodeAnswer = '" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt16(0);
                    token.CodeAnswer = reader.GetString(1);
                    token.CharOrder = reader.GetString(2);
                    token.ContentQ = reader.GetString(3);
                    token.Imgs = reader.GetString(4);
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

        public Answer GetAnswer(int id)
        {
            Answer token = new Answer();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Answer where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeAnswer = reader.GetString(1);
                    token.CharOrder = reader.GetString(2);
                    token.ContentQ = reader.GetString(3);
                    token.Imgs = string.Empty;
                    token.State = reader.GetInt16(7);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            db_Uitl.Close();
            return token;
        }

        public Answer_Student GetAnswerOfStudent(string id)
        {
            Answer_Student token = new Answer_Student();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Answer where CodeAnswer = '" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt16(0);
                    token.CodeAnswer = reader.GetString(1);
                    token.CharOrder = reader.GetString(2);
                    token.ContentQ = reader.GetString(3);
                    token.Imgs = reader.GetString(4);
                    token.State = reader.GetInt16(7);
                    token.ChoseTime = reader.GetSqlDateTime(5);
                    DAO_Account dao_acc = new DAO_Account();
                    token.Self = dao_acc.GetAccountStudent(reader.GetString(8));
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Answer_Student GetAnswerOfStudent(int id)
        {
            Answer_Student token = new Answer_Student();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Answer where id = '" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt16(0);
                    token.CodeAnswer = reader.GetString(1);
                    token.CharOrder = reader.GetString(2);
                    token.ContentQ = reader.GetString(3);
                    token.Imgs = reader.GetString(4);
                    token.State = reader.GetInt16(7);
                    token.ChoseTime = reader.GetSqlDateTime(5);
                    DAO_Account dao_acc = new DAO_Account();
                    token.Self = dao_acc.GetAccountStudent(reader.GetString(8));
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Answer_Student GetAnswerOfStudent(string codeQuest, string username)
        {
            Answer_Student token = new Answer_Student();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Answer where CodeQuestion = '" + codeQuest + "' and Self = '" + username + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt16(0);
                    token.CodeAnswer = reader.GetString(1);
                    token.CharOrder = reader.GetString(2);
                    token.ContentQ = reader.GetString(3);
                    token.Imgs = reader.GetString(4);
                    token.State = reader.GetInt16(7);
                    token.ChoseTime = reader.GetSqlDateTime(5);
                    DAO_Account dao_acc = new DAO_Account();
                    token.Self = dao_acc.GetAccountStudent(username);
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
                    string sqlQuery = "Delete From Answer where username = N'" + id + "'";
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
                    string sqlQuery = "Delete From Answer where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Answer ans, string references)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Answer Set CharOrder=@CharOrder, ContentQ=@ContentQ
                    , Img=@Img, ChoseTime=@ChoseTime, CodeQuestion=@CodeQuestion, [State]=@State where CodeAnswer=@CodeAnswer";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CharOrder", ans.CharOrder);
                        cm.Parameters.AddWithValue("@ContentQ", ans.ContentQ);
                        cm.Parameters.AddWithValue("@Img", ans.Imgs);
                        cm.Parameters.AddWithValue("@CodeQuestion", references);
                        cm.Parameters.AddWithValue("@State", ans.State);
                        cm.Parameters.AddWithValue("@CodeAnswer", ans.CodeAnswer);
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
