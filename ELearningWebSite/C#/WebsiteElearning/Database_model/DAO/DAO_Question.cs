using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Question
    {
        public DAO_Question()
        {
            //db_Uitl.Connect();
        }

        public void Add(Question lec)
        {
            if (!Contain(lec.CodeQuestion))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Question(CodeQuestion,Header,Content,imgs,TypeQuest,CorrectAnswer,[State]) " +
                    "values ('@CodeQuestion','@Header','@Content','@imgs','@TypeQuest','@CorrectAnswer','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                    cm.Parameters.AddWithValue("@Header", lec.Header);
                    cm.Parameters.AddWithValue("@Content", lec.Content);
                    cm.Parameters.AddWithValue("@imgs", lec.Imgs.ToString());
                    cm.Parameters.AddWithValue("@TypeQuest", lec.TypeQuest);
                    cm.Parameters.AddWithValue("@State", lec.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Add(string codeQuest, string numOder, string header,string content,string imgs,int typeQ,int idExam,string codeAnswer)
        {
            if (true) // contain
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Question(CodeQuestion,NumOrder,Header,Content,imgs,TypeQuest,CorrectAnswer,[State],idContentLec) " +
                    "values (@CodeQuestion,@NumOrder,@Header,@Content,@imgs,@TypeQuest,@CorrectAnswer,@State,@idContentLec)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", codeQuest);
                    cm.Parameters.AddWithValue("@NumOrder", numOder);
                    cm.Parameters.AddWithValue("@Header", header);
                    cm.Parameters.AddWithValue("@Content", content);
                    cm.Parameters.AddWithValue("@imgs", imgs);
                    cm.Parameters.AddWithValue("@TypeQuest", typeQ);
                    cm.Parameters.AddWithValue("@CorrectAnswer", codeAnswer);
                    cm.Parameters.AddWithValue("@idContentLec", idExam);
                    cm.Parameters.AddWithValue("@State", 1);
                    cm.ExecuteNonQuery();
                    db_Uitl.Close();
                    return true;
                }
            }
            db_Uitl.Close();
            return false;
        }

        public bool Contain(string id)
        {
            foreach (Question item in GetAll())
            {
                if (id.Equals(item.CodeQuestion))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckReferences(string correctAns)
        {
            DAO_Answer dao_ans = new DAO_Answer();
            if (!dao_ans.Contain(correctAns))
                return false;
            return true;
        }

        public List<Question> GetAll()
        {
            try
            {
                List<Question> ls = new List<Question>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    
                    string sqlQuery = "Select * from Question";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        string fullLink = reader.GetString(4);
                        DAO_Answer dao_ans = new DAO_Answer();
                        Question token = new Question();
                        token.CodeQuestion = reader.GetString(1);
                        token.Header = reader.GetString(2);
                        token.Content = reader.GetString(3);
                        //token.Imgs = new List<string>(fullLink.Split());
                        token.Imgs = null ;
                        token.TypeQuest = reader.GetInt16(5);
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

        /// <summary>
        /// 1: Exam
        /// 2: typeQuest
        /// Chú ý chỉ lấy ra câu hỏi chứ không lấy ra được full câu hỏi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Question> GetAll(string id, int type)
        {
            try
            {
                List<Question> ls = new List<Question>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from Question where CodeContentLec = " + id;
                    }
                    else
                    {
                        sqlQuery = "Select * from Question where TypeQuest = " + id;
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Question token = new Question();
                        string fullLink = reader.GetString(4);
                        token.CodeQuestion = reader.GetString(1);
                        token.Header = reader.GetString(2);
                        token.Content = reader.GetString(3);
                        token.Imgs = new List<string>(fullLink.Split());
                        token.TypeQuest = reader.GetInt16(5);
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

        public List<Question> GetAllFull(string id, int type)
        {
            try
            {
                List<Question> ls = new List<Question>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from Question where CodeContentLec = " + id;
                    }
                    else
                    {
                        sqlQuery = "Select * from Question where TypeQuest = " + id;
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Question token = new Question();
                        string fullLink = reader.GetString(4);
                        token.CodeQuestion = reader.GetString(1);
                        token.Header = reader.GetString(2);
                        token.Content = reader.GetString(3);
                        token.Imgs = new List<string>(fullLink.Split());
                        token.TypeQuest = reader.GetInt16(5);
                        token.State = reader.GetInt16(7);
                        switch (token.TypeQuest)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                        }

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

        public Question GetQuestion(string codeLec)
        {
            Question token = new Question();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Question where CodeQuestion = N'" + codeLec + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Answer dao_ans = new DAO_Answer();
                    string fullLink = reader.GetString(4);
                    token.CodeQuestion = reader.GetString(1);
                    token.Header = reader.GetString(2);
                    token.Content = reader.GetString(3);
                    token.Imgs = new List<string>(fullLink.Split());
                    token.TypeQuest = reader.GetInt16(5);

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

        public Question GetQuestion(int id)
        {
            Question token = new Question();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Question where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Answer dao_ans = new DAO_Answer();
                    token.id = reader.GetInt32(0);
                    string fullLink = reader.GetString(4);
                    token.CodeQuestion = reader.GetString(1);
                    token.NumOrder = reader.GetString(2);
                    token.Header = reader.GetString(3);
                    token.Content = reader.GetString(4);
                    token.Imgs = new List<string>(fullLink.Split());
                    token.CorrectAnswer = reader.GetString(8);
                    token.TypeQuest = reader.GetInt16(6);
                    token.State = reader.GetInt16(9);
                    reader.Close();
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            db_Uitl.Close();
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
                    string sqlQuery = "Update Question Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Question Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Question lec)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Question Set Header=@Header,Content=@Content, imgs=@imgs,TypeQuest=@TypeQuest,CorrectAnswer=@CorrectAnswer,[State]=@State 
                                where CodeQuestion=@CodeQuestion";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                        cm.Parameters.AddWithValue("@Header", lec.Header);
                        cm.Parameters.AddWithValue("@Content", lec.Content);
                        cm.Parameters.AddWithValue("@imgs", lec.Imgs.ToString());
                        cm.Parameters.AddWithValue("@TypeQuest", lec.TypeQuest);

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
