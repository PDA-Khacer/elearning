using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Question_MCQ
    {
        public DAO_Question_MCQ()
        {
            //db_Uitl.Connect();
        }

        public void Add(Question_MCQ lec)
        {
            db_Uitl.Connect();
            for (int i = 0; i < lec.LstAnswer.answers.Count; i++)
            {
                Answer itemAns = lec.LstAnswer.answers[i];
                string sqlQuery = "Insert into QuestionMCQ(CodeQuestion,CodeAnswer,[State]) " +
                "values ('@CodeQuestion','@CodeAnswer,'@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                    cm.Parameters.AddWithValue("@CodeAnswer", itemAns.CodeAnswer);
                    cm.Parameters.AddWithValue("@State", lec.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Add(string codeQuest, string numOder, string header, string content, string imgs, int typeQ, int idExam, string codeAnswer)
        {
            try
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Question(CodeQuestion,NumOrder,Header,Content,imgs,TypeQuest,CorrectAnswer,[State],idContentLec) " +
                    "values (@CodeQuestion,@Header,@Content,@imgs,@TypeQuest,@CorrectAnswer,@State,@idContentLec)";
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
            catch(Exception e)
            {
                e.ToString();
                return false;
            }
            
            
        }

        public bool Contain(string codeQuestion, string codeAnswer)
        {
            foreach (Question_MCQ item in GetAll())
            {
                DAO_Answer dao_ass = new DAO_Answer();
                if (codeQuestion.Equals(item.CodeQuestion))
                {
                    for (int i = 0; i < item.LstAnswer.answers.Count; i++)
                        if (item.LstAnswer.answers[i].CodeAnswer.Equals(codeAnswer))
                        {
                            return true;
                        }
                }
            }
            return false;
        }

        public List<Question_MCQ> GetAll()
        {
            try
            {
                List<Question_MCQ> ls = new List<Question_MCQ>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from QuestionMCQ";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        string codeQuest = reader.GetString(1);
                        DAO_Question dao_quest = new DAO_Question();
                        DAO_Answer dao_ans = new DAO_Answer();
                        bool exits = false;
                        foreach (Question_MCQ item in ls)
                        {
                            if (item.CodeQuestion == codeQuest)
                            {
                                exits = true;
                                item.LstAnswer.answers.Add(dao_ans.GetAnswer(reader.GetString(2)));
                            }
                        }
                        if (!exits)
                        {
                            Question_MCQ token = new Question_MCQ(dao_quest.GetQuestion(codeQuest));
                            token.LstAnswer.answers.Add(dao_ans.GetAnswer(reader.GetString(2)));
                            ls.Add(token);
                        }
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

        public Question_MCQ GetQuestion_MCQ(string codeQuestion)
        {
            Question_MCQ token = new Question_MCQ();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from QuestionMCQ where CodeQuestion = N'" + codeQuestion + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    string codeQuest = reader.GetString(1);
                    DAO_Question dao_quest = new DAO_Question();
                    DAO_Answer dao_ans = new DAO_Answer();
                    token = new Question_MCQ(dao_quest.GetQuestion(codeQuest));
                    while (reader.Read())
                    {
                        token.LstAnswer.answers.Add(dao_ans.GetAnswer(reader.GetString(2)));
                    }
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Question_MCQ GetQuestion_MCQ(int id)
        {
            Question_MCQ token = new Question_MCQ();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    DAO_Question dao_quest = new DAO_Question();
                    token = new Question_MCQ(dao_quest.GetQuestion(id));
                    db_Uitl.Connect();
                    // câu trả lời
                    string sqlQuery = "Select * from Answer where CodeQuestion = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    DAO_Answer dao_ans = new DAO_Answer();
                    while (reader.Read())
                    {
                        token.LstAnswer.answers.Add(dao_ans.GetAnswer(reader.GetInt32(0)));
                    }
                    reader.Close();
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
            return token;
        }
        public List<Question_MCQ> GetAllQuest(int idExam)
        {

            try
            {
                List<Question_MCQ> ls = new List<Question_MCQ>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Question where idContentLec = '"+idExam+"' and TypeQuest = 2 ";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    List<int> lstId = new List<int>();
                    while (reader.Read())
                    {
                        lstId.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                    db_Uitl.Close();
                    foreach (int item in lstId)
                    {
                        ls.Add(GetQuestion_MCQ(item));
                    }
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



        public void Remove(string id)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Update Question_MCQ Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Question_MCQ Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Question_MCQ lec)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Detele * from QuestionMCQ where CodeQuestion= '@CodeQuestion'";
                    SqlCommand cm = db_Uitl.Conn.CreateCommand();
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                    cm.ExecuteNonQuery();
                    // Update chính
                    for (int i = 0; i < lec.LstAnswer.answers.Count; i++)
                    {
                        Answer itemAns = lec.LstAnswer.answers[i];
                        sqlQuery = @"Insert into QuestionMCQ(CodeQuestion,CodeAnswer,[State]) " +
                            "values ('@CodeQuestion','@CodeAnswer,'@State')";
                        using (SqlCommand cm1 = db_Uitl.Conn.CreateCommand())
                        {
                            cm1.CommandText = sqlQuery;
                            cm1.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                            cm1.Parameters.AddWithValue("@CodeAnswer", itemAns.CodeAnswer);
                            cm1.Parameters.AddWithValue("@State", lec.State);
                            cm1.ExecuteNonQuery();
                        }
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
