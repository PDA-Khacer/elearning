using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_ContentLec_Assignment : DAO_ContentLec
    {
        public override void Add(ContentLec conlec)
        {
            ContentLec_Assignment com = conlec as ContentLec_Assignment;
            if (!Contain(com.CodeContentLec))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ContentLec(CodeContentLec,dayCreate,header,Decription,DayOpen,DayClose,CodeLecture,DayExpire,Content,Self,[State]) " +
                    "values (@CodeContentLec,@dayCreate,@header,@Decription,@DayOpen,@DayClose,@CodeLecture,@DayExpire,@Content,@Self,@State)";
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
                    cm.Parameters.AddWithValue("@Content", com.Content);
                    cm.Parameters.AddWithValue("@Self", com.Self);
                    cm.Parameters.AddWithValue("@State", com.State);
                    cm.ExecuteNonQuery();
                }
            }
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
                        ContentLec_Assignment token = new ContentLec_Assignment();
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        token.DayExpire = reader.GetDateTime(8);
                        token.Content = reader.GetString(9);
                        token.State = reader.GetInt16(14);
                        token.TypeContentLec = "1";
                        DAO_Student_Assignment dao_ass = new DAO_Student_Assignment();
                        token.LstAssignmentStudent = dao_ass.GetAll(token.CodeContentLec, 1);
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
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
        /// 1: code lecture
        /// 2: self
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public override List<ContentLec> GetAll(string id, int type)
        {
            try
            {
                List<ContentLec> ls = new List<ContentLec>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from ContentLec where CodeLecture = '" + id + "'";
                    }
                    else
                    {
                        sqlQuery = "Select * from ContentLec where self = '" + id + "'";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        ContentLec_Assignment token = new ContentLec_Assignment();
                        token.CodeContentLec = reader.GetString(1);
                        token.DayCreate = reader.GetDateTime(2);
                        token.Header = reader.GetString(3);
                        token.Decription = reader.GetString(4);
                        token.DayOpen = reader.GetDateTime(5);
                        token.DayClose = reader.GetDateTime(6);
                        token.DayExpire = reader.GetDateTime(8);
                        token.Content = reader.GetString(9);
                        token.State = reader.GetInt16(14);
                        token.TypeContentLec = "1";
                        DAO_Student_Assignment dao_ass = new DAO_Student_Assignment();
                        token.LstAssignmentStudent = dao_ass.GetAll(token.CodeContentLec, 1);
                        DAO_Account dao_tea = new DAO_Account();
                        token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
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

        public override ContentLec GetContentLec(string id)
        {
            ContentLec_Assignment token = new ContentLec_Assignment();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ContentLec where CodeContentLec = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();

                    token.CodeContentLec = reader.GetString(1);
                    token.DayCreate = reader.GetDateTime(2);
                    token.Header = reader.GetString(3);
                    token.Decription = reader.GetString(4);
                    token.DayOpen = reader.GetDateTime(5);
                    token.DayClose = reader.GetDateTime(6);
                    token.DayExpire = reader.GetDateTime(8);
                    token.Content = reader.GetString(9);
                    token.State = reader.GetInt16(14);
                    token.TypeContentLec = "1";
                    DAO_Student_Assignment dao_ass = new DAO_Student_Assignment();
                    token.LstAssignmentStudent = dao_ass.GetAll(token.CodeContentLec, 1);
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
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
            ContentLec_Assignment token = new ContentLec_Assignment();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ContentLec where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeContentLec = reader.GetString(1);
                    token.DayCreate = reader.GetDateTime(2);
                    token.Header = reader.GetString(3);
                    token.Decription = reader.GetString(4);
                    token.DayOpen = reader.GetDateTime(5);
                    token.DayClose = reader.GetDateTime(6);
                    token.DayExpire = reader.GetDateTime(8);
                    token.Content = reader.GetString(9);

                    token.State = reader.GetInt16(14);
                    token.TypeContentLec = "1";
                    DAO_Student_Assignment dao_ass = new DAO_Student_Assignment();
                    token.LstAssignmentStudent = dao_ass.GetAll(token.CodeContentLec, 1);
                    DAO_Account dao_tea = new DAO_Account();
                    token.Self = dao_tea.GetAccount(reader.GetString(13)) as Account_Teacher;
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public override void Update(ContentLec comLe)
        {
            ContentLec_Assignment com = comLe as ContentLec_Assignment;
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quana
                    // Update chính
                    string sqlQuery = @"Update ContentLec Set header=@header,decription=@decription,DayOpen=@DayOpen,
                                DayClose=@DayClose,CodeLecture=@CodeLecture,DayExpire=@DayExpire,Content=@Content,Self=@self,[State]=@State 
                                where CodeContentLec=@CodeContentLec";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeContentLec", com.Header);
                        cm.Parameters.AddWithValue("@decription", com.Decription);
                        cm.Parameters.AddWithValue("@DayOpen", com.DayOpen);
                        cm.Parameters.AddWithValue("@DayClose", com.DayClose);
                        cm.Parameters.AddWithValue("@DayExpire", com.DayExpire);
                        cm.Parameters.AddWithValue("@Content", com.Content);
                        cm.Parameters.AddWithValue("@Self", com.Self);
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
