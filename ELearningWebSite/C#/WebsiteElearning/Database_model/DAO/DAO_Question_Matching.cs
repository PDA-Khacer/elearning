using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Question_Matching
    {
        public DAO_Question_Matching()
        {
            db_Uitl.Connect();
        }

        public void Add(Question_Matching lec)
        {
            db_Uitl.Connect();
            for (int i = 0; i < lec.LstAnswer1.Count; i++)
            {
                Answer itemAns1 = lec.LstAnswer1[i];
                Answer itemAns2 = lec.LstAnswer2[i];
                string sqlQuery = "Insert into QuestionMatching(CodeQuestion,CodeAnswer1,CodeAnswer2,[State]) " +
                "values ('@CodeQuestion','@CodeAnswer1','@CodeAnswer2','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                    cm.Parameters.AddWithValue("@CodeAnswer1", itemAns1.CodeAnswer);
                    cm.Parameters.AddWithValue("@CodeAnswer2", itemAns1.CodeAnswer);
                    cm.Parameters.AddWithValue("@State", lec.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(string codeQuestion, string codeAnswer1, string codeAnswer2)
        {
            foreach (Question_Matching item in GetAll())
            {
                DAO_Answer dao_ass = new DAO_Answer();
                if (codeQuestion.Equals(item.CodeQuestion))
                {
                    for (int i = 0; i < item.LstAnswer1.Count; i++)
                        if (item.LstAnswer1[i].CodeAnswer.Equals(codeAnswer1) &&
                            item.LstAnswer2[i].CodeAnswer.Equals(codeAnswer2))
                        {
                            return true;
                        }
                }
            }
            return false;
        }

        public List<Question_Matching> GetAll()
        {
            try
            {
                List<Question_Matching> ls = new List<Question_Matching>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from Question_Matching";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        string codeQuest = reader.GetString(1);
                        DAO_Question dao_quest = new DAO_Question();
                        DAO_Answer dao_ans = new DAO_Answer();
                        bool exits = false;
                        foreach (Question_Matching item in ls)
                        {
                            if (item.CodeQuestion == codeQuest)
                            {
                                exits = true;
                                item.LstAnswer1.Add(dao_ans.GetAnswer(reader.GetString(2)));
                                item.LstAnswer2.Add(dao_ans.GetAnswer(reader.GetString(3)));
                            }
                        }
                        if (!exits)
                        {
                            Question_Matching token = new Question_Matching(dao_quest.GetQuestion(codeQuest));
                            token.LstAnswer1.Add(dao_ans.GetAnswer(reader.GetString(2)));
                            token.LstAnswer2.Add(dao_ans.GetAnswer(reader.GetString(3)));
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

        public Question_Matching GetQuestion_Matching(string codeQuestion)
        {
            Question_Matching token = new Question_Matching();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from QuestionMatching where CodeQuestion = N'" + codeQuestion + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    string codeQuest = reader.GetString(1);
                    DAO_Question dao_quest = new DAO_Question();
                    DAO_Answer dao_ans = new DAO_Answer();
                    token = new Question_Matching(dao_quest.GetQuestion(codeQuest));
                    while (reader.Read())
                    {
                        token.LstAnswer1.Add(dao_ans.GetAnswer(reader.GetString(2)));
                        token.LstAnswer2.Add(dao_ans.GetAnswer(reader.GetString(3)));
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
                    string sqlQuery = "Update Question_Matching Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Question_Matching Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Question_Matching lec)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Detele * from QuestionMatching where CodeQuestion= '@CodeQuestion'";
                    SqlCommand cm = db_Uitl.Conn.CreateCommand();
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                    cm.ExecuteNonQuery();
                    // Update chính

                    for (int i = 0; i < lec.LstAnswer1.Count; i++)
                    {
                        Answer itemAns1 = lec.LstAnswer1[i];
                        Answer itemAns2 = lec.LstAnswer2[i];
                        sqlQuery = @"Insert into QuestionMatching(CodeQuestion,CodeAnswer1,CodeAnswer2,[State]) " +
                            "values ('@CodeQuestion','@CodeAnswer1','@CodeAnswer2','@State')";
                        using (SqlCommand cm1 = db_Uitl.Conn.CreateCommand())
                        {
                            cm1.CommandText = sqlQuery;
                            cm1.Parameters.AddWithValue("@CodeQuestion", lec.CodeQuestion);
                            cm1.Parameters.AddWithValue("@CodeAnswer1", itemAns1.CodeAnswer);
                            cm1.Parameters.AddWithValue("@CodeAnswer2", itemAns1.CodeAnswer);
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
