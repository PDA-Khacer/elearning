using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Question_TF
    {
        public DAO_Question_TF()
        {
            db_Uitl.Connect();
        }

        public void Add(Question_TF lec)
        {
            db_Uitl.Connect();
            for (int i = 0; i < lec.LstAnswer.Count; i++)
            {
                Answer itemAns = lec.LstAnswer[i];
                bool correctAns = lec.LstCorrectAnser[i];
                string sqlQuery = "Insert into QuestionTF(CodeQuestion,CodeAnswer,CorrectAnswer,[State]) " +
                "values ('@CodeQuestion','@CodeAnswer,'@CorrectAnswer,'@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                    cm.Parameters.AddWithValue("@CodeAnswer", itemAns.CodeAnswer);
                    cm.Parameters.AddWithValue("@CodeAnswer", correctAns);
                    cm.Parameters.AddWithValue("@State", lec.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(string codeQuestion, string codeAnswer)
        {
            foreach (Question_TF item in GetAll())
            {
                DAO_Answer dao_ass = new DAO_Answer();
                if (codeQuestion.Equals(item.CodeQuestion))
                {
                    for (int i = 0; i < item.LstAnswer.Count; i++)
                        if (item.LstAnswer[i].CodeAnswer.Equals(codeAnswer))
                        {
                            return true;
                        }
                }
            }
            return false;
        }

        public List<Question_TF> GetAll()
        {
            try
            {
                List<Question_TF> ls = new List<Question_TF>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from QuestionTF";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        string codeQuest = reader.GetString(1);
                        DAO_Question dao_quest = new DAO_Question();
                        DAO_Answer dao_ans = new DAO_Answer();
                        bool exits = false;
                        foreach (Question_TF item in ls)
                        {
                            if (item.CodeQuestion == codeQuest)
                            {
                                exits = true;
                                item.LstAnswer.Add(dao_ans.GetAnswer(reader.GetString(2)));
                                item.LstCorrectAnser.Add(reader.GetBoolean(3));
                            }
                        }
                        if (!exits)
                        {
                            Question_TF token = new Question_TF(dao_quest.GetQuestion(codeQuest));
                            token.LstAnswer.Add(dao_ans.GetAnswer(reader.GetString(2)));
                            token.LstCorrectAnser.Add(reader.GetBoolean(3));
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

        public Question_TF GetQuestion_TF(string codeQuestion)
        {
            Question_TF token = new Question_TF();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from QuestionTF where CodeQuestion = N'" + codeQuestion + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    string codeQuest = reader.GetString(1);
                    DAO_Question dao_quest = new DAO_Question();
                    DAO_Answer dao_ans = new DAO_Answer();
                    token = new Question_TF(dao_quest.GetQuestion(codeQuest));
                    while (reader.Read())
                    {
                        token.LstAnswer.Add(dao_ans.GetAnswer(reader.GetString(2)));
                        token.LstCorrectAnser.Add(reader.GetBoolean(3));
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

        public void Remove(string id)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Update Question_TF Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Question_TF Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Question_TF lec)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Detele * from QuestionTF where CodeQuestion= '@CodeQuestion'";
                    SqlCommand cm = db_Uitl.Conn.CreateCommand();
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                    cm.ExecuteNonQuery();
                    // Update chính
                    for (int i = 0; i < lec.LstAnswer.Count; i++)
                    {
                        Answer itemAns = lec.LstAnswer[i];
                        sqlQuery = @"Insert into QuestionTF(CodeQuestion,CodeAnswer,[State]) " +
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
