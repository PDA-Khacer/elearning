using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Database_model.DAO
{
    public class DAO_ContentLec_Exam : DAO_ContentLec
    {
        public override void Add(ContentLec conlec)
        {
            ContentLec_Exam com = conlec as ContentLec_Exam;
            if (!Contain(com.CodeContentLec))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ContentLec(CodeContentLec,dayCreate,header,Decription,DayOpen,DayClose,CodeLecture,DayExpire,TimeStart,Duration,Self,[State]) " +
                    "values (@CodeContentLec,@dayCreate,@header,@Decription,@DayOpen,@DayClose,@CodeLecture,@DayExpire,@TimeStart,@Duration,@Self,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeContentLec", com.CodeContentLec);
                    cm.Parameters.AddWithValue("@dayCreate", com.DayCreate);
                    cm.Parameters.AddWithValue("@header", com.Header);
                    cm.Parameters.AddWithValue("@Decription", com.Decription);
                    cm.Parameters.AddWithValue("@DayOpen", com.DayOpen);
                    cm.Parameters.AddWithValue("@DayClose", com.DayClose);
                    cm.Parameters.AddWithValue("@DayExpire", com.DayExpire);
                    cm.Parameters.AddWithValue("@TimeStart", com.TimeStart);
                    cm.Parameters.AddWithValue("@Duration", com.Duration);
                    cm.Parameters.AddWithValue("@Self", com.Self.Username);
                    cm.Parameters.AddWithValue("@State", com.State);
                    cm.ExecuteNonQuery();
                }
            }
        }
        public bool Add(string codeContent, string header, string description, string dayOpen, string dayClose, string dayExipre,string timeStart,float duration,int idTeacher,int idLecture)
        {
            if (!Contain(codeContent))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ContentLec(CodeContentLec,dayCreate,header,Decription,DayOpen,DayClose,DayExpire,TimeStart,Duration,CodeLecture,Self,[State],TypeContentLec) " +
                    "values (@CodeContentLec,@dayCreate,@header,@Decription,@DayOpen,@DayClose,@DayExpire,@TimeStart,@Duration,@CodeLecture,@Self,@State,@TypeContentLec)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeContentLec", codeContent);
                    cm.Parameters.AddWithValue("@dayCreate", new SqlDateTime(DateTime.Now));
                    cm.Parameters.AddWithValue("@header", header);
                    cm.Parameters.AddWithValue("@Decription", description);
                    cm.Parameters.AddWithValue("@DayOpen", dayOpen);
                    cm.Parameters.AddWithValue("@DayClose", dayClose);
                    cm.Parameters.AddWithValue("@DayExpire", dayExipre);
                    cm.Parameters.AddWithValue("@TimeStart", timeStart);
                    cm.Parameters.AddWithValue("@Duration", duration);
                    cm.Parameters.AddWithValue("@Self", idTeacher);
                    cm.Parameters.AddWithValue("@State", 1);
                    cm.Parameters.AddWithValue("@TypeContentLec", 2);
                    cm.Parameters.AddWithValue("@CodeLecture", idLecture);
                    cm.ExecuteNonQuery();
                    db_Uitl.Close();
                    return true;
                }
            }
            else
                return false;
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
                        ContentLec_Exam token = new ContentLec_Exam();
                        token.id = reader.GetInt32(0);
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        token.DayExpire = reader.GetDateTime(8);
                        token.TimeStart = reader.GetDateTime(9);
                        token.Duration = reader.GetFloat(9);
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccountTeacher(reader.GetString(13));
                        token.State = reader.GetInt16(14);
                        token.TypeContentLec = "2";
                        DAO_Question dao_que = new DAO_Question();
                        //token.LstQuest = dao_que.GetAll();
                        DAO_Student_Exam dao_se = new DAO_Student_Exam();
                        token.LstExamStudent = dao_se.GetAll(token.CodeContentLec, 1);
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

        public List<ContentLec> GetAll(int id, int type)
        {
            try
            {
                List<ContentLec> ls = new List<ContentLec>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from ContentLec where id = "+id;
                    }
                    else
                    {
                        sqlQuery = "Select * from ContentLec where self = '" + id + "'";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ContentLec_Exam token = new ContentLec_Exam();
                        token.id = reader.GetInt32(0);
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        token.DayExpire = reader.GetDateTime(8);
                        token.TimeStart = reader.GetDateTime(10);
                        token.Duration = reader.GetInt32(11);
                        token.State = reader.GetInt16(14);
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccountTeacher(reader.GetInt32(13));

                        token.TypeContentLec = "2";
                        DAO_Question_MCQ dao_que = new DAO_Question_MCQ();
                        token.LstQuest = new ListQuestion_MCQ();
                        token.LstQuest.question_MCQs = dao_que.GetAllQuest(id);
                        //DAO_Student_Exam dao_se = new DAO_Student_Exam();
                        //token.LstExamStudent = dao_se.GetAll(token.CodeContentLec, 1);
                        reader.Close();
                    }
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

        public override ContentLec GetContentLec(string id)
        {
            ContentLec_Exam token = new ContentLec_Exam();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ContentLec where CodeContentLec = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeContentLec = reader.GetString(1);
                    token.DayCreate = reader.GetDateTime(2);
                    token.Header = reader.GetString(3);
                    token.Decription = reader.GetString(4);
                    token.DayOpen = reader.GetDateTime(5);
                    token.DayClose = reader.GetDateTime(6);
                    token.DayExpire = reader.GetDateTime(8);
                    token.TimeStart = reader.GetDateTime(9);
                    token.Duration = reader.GetFloat(9);
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccountTeacher(reader.GetString(13));
                    token.State = reader.GetInt16(14);
                    token.TypeContentLec = "2";
                    DAO_Question dao_que = new DAO_Question();
                    //token.LstQuest = dao_que.GetAll();
                    DAO_Student_Exam dao_se = new DAO_Student_Exam();
                    token.LstExamStudent = dao_se.GetAll(token.CodeContentLec, 1);
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
            ContentLec_Exam token = new ContentLec_Exam();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ContentLec where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeContentLec = reader.GetString(1);
                    token.DayCreate = reader.GetDateTime(2);
                    token.Header = reader.GetString(3);
                    token.Decription = reader.GetString(4);
                    token.DayOpen = reader.GetDateTime(5);
                    token.DayClose = reader.GetDateTime(6);
                    token.DayExpire = reader.GetDateTime(8);
                    token.TimeStart = reader.GetDateTime(10);
                    token.Duration = reader.GetInt32(11);
                    token.State = reader.GetInt16(14);
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccountTeacher(reader.GetInt32(13));
                    
                    token.TypeContentLec = "2";
                    DAO_Question_MCQ dao_que = new DAO_Question_MCQ();
                    token.LstQuest = new ListQuestion_MCQ();
                    token.LstQuest.question_MCQs = dao_que.GetAllQuest(id);
                    //DAO_Student_Exam dao_se = new DAO_Student_Exam();
                    //token.LstExamStudent = dao_se.GetAll(token.CodeContentLec, 1);
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

        public override void Update(ContentLec comLe)
        {
            ContentLec_Exam com = comLe as ContentLec_Exam;
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update ContentLec Set header=@header,decription=@decription,DayOpen=@DayOpen,
                                DayClose=@DayClose,CodeLecture=@CodeLecture,DayExpire=@DayExpire,TimeStart=@TimeStart,Duration=@Duration,Self=@Self,[State]=@State 
                                where CodeContentLec=@CodeContentLec";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeContentLec", com.Header);
                        cm.Parameters.AddWithValue("@decription", com.Decription);
                        cm.Parameters.AddWithValue("@DayOpen", com.DayOpen);
                        cm.Parameters.AddWithValue("@DayClose", com.DayClose);

                        cm.Parameters.AddWithValue("@DayExpire", com.DayExpire);
                        cm.Parameters.AddWithValue("@TimeStart", com.TimeStart);
                        cm.Parameters.AddWithValue("@Duration", com.Duration);
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
