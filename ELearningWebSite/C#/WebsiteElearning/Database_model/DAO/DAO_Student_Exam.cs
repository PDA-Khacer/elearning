using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Student_Exam
    {
        public DAO_Student_Exam()
        {
            db_Uitl.Connect();
        }

        public void Add(Student_Exam acc)
        {
            if (!Contain())
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into ExamStudent(CodeContentLec,dutationDo,point,TeacherGive,TimeGivePoint,StudentOwns,[State]) " +
                    "values ('@CodeContentLec','@dutationDo','@point','@TeacherGive,'@TimeGivePoint,'@StudentOwns','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                   
                    cm.Parameters.AddWithValue("@point", acc.Point);
                    cm.Parameters.AddWithValue("@dutationDo", acc.DurationDo);
                    cm.Parameters.AddWithValue("@TeacherGive", acc.TeacherGive.Username);
                    cm.Parameters.AddWithValue("@TimeGivePoint", acc.TimeGivePoint);
                    cm.Parameters.AddWithValue("@StudentOwns", acc.StudentDo);
                    cm.Parameters.AddWithValue("@State", acc.State);
                    cm.ExecuteNonQuery();
                }
                // add list

            }
        }

        public bool Contain()
        {
            //foreach (Student_Exam item in GetAll())
            //{
            //    if (id1.Equals(item.Self.Username) && id2.Equals(item.TimeStudent_Exam))
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public bool CheckReferences(int id)
        {
            DAO_Account dao_acc = new DAO_Account();
            if (!dao_acc.Contain(id))
                return false;
            return true;
        }

        public List<Student_Exam> GetAll()
        {
            try
            {
                List<Student_Exam> ls = new List<Student_Exam>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from ExamStudent";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Student_Exam token = new Student_Exam();
                        DAO_Account dao_acc = new DAO_Account();
                        DAO_Account dao_tea = new DAO_Account();
                        DAO_Comment dao_com = new DAO_Comment();
                        token.DurationDo = reader.GetFloat(2);
                        token.Point = reader.GetFloat(3);
                        token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                        token.TimeGivePoint = reader.GetDateTime(5);
                        token.StudentDo = new Account_Student(dao_tea.GetAccount(reader.GetString(5)));
                        token.State = reader.GetInt32(6);
                        // lsst ans
                        //List<Answer> lstans = dao_ansS.GetAll(token.StudentDo.Username + "/" + token.CodeContentLec, 3);
                        //foreach (Answer item in lstans)
                        //{
                        //    token.LstAnswer.Add(new Answer_Student(item, token.StudentDo));
                        //}
                        //ls.Add(token);
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
        /// 1: contentLec
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Student_Exam> GetAll(string id, int type)
        {
            try
            {
                List<Student_Exam> ls = new List<Student_Exam>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from ExamStudent where CodeContentLec = '" + id + "'";
                    }
                    else
                    {
                        sqlQuery = "";
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Student_Exam token = new Student_Exam();
                        DAO_Account dao_acc = new DAO_Account();
                        DAO_Account dao_tea = new DAO_Account();
                        DAO_Comment dao_com = new DAO_Comment();
                        token.DurationDo = reader.GetFloat(2);
                        token.Point = reader.GetFloat(3);
                        token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                        token.TimeGivePoint = reader.GetDateTime(5);
                        token.StudentDo = new Account_Student(dao_tea.GetAccount(reader.GetString(5)));
                        token.State = reader.GetInt32(6);
                        // lsst ans
                        //List<Answer> lstans = dao_ansS.GetAll(token.StudentDo.Username + "/" + token.CodeContentLec, 3);
                        //foreach (Answer item in lstans)
                        //{
                        //    token.LstAnswer.Add(new Answer_Student(item, token.StudentDo));
                        //}
                        //ls.Add(token);
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

        public Student_Exam GetStudent_Exam(string codeContentLec, string studentDo)
        {
            Student_Exam token = new Student_Exam();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from ExamStudent where CodeContentLec = N'" + codeContentLec + "' and StudentOwns = '" + studentDo + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Account dao_tea = new DAO_Account();
                    DAO_Comment dao_com = new DAO_Comment();
                    token.DurationDo = reader.GetFloat(2);
                    token.Point = reader.GetFloat(3);
                    token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                    token.TimeGivePoint = reader.GetDateTime(5);
                    token.StudentDo = new Account_Student(dao_tea.GetAccount(reader.GetString(5)));
                    token.State = reader.GetInt16(6);
                    // lsst ans
                    //List<Answer> lstans = dao_ansS.GetAll(token.StudentDo.Username + "/" + token.CodeContentLec, 3);
                    //foreach (Answer item in lstans)
                    //{
                    //    token.LstAnswer.Add(new Answer_Student(item, token.StudentDo));
                    //}
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Student_Exam GetStudent_Exam(int id)
        {
            Student_Exam token = new Student_Exam();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Student_Exam where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    DAO_Account dao_tea = new DAO_Account();
                    DAO_Comment dao_com = new DAO_Comment();
                    token.DurationDo = reader.GetFloat(2);
                    token.Point = reader.GetFloat(3);
                    token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                    token.TimeGivePoint = reader.GetDateTime(5);
                    token.StudentDo = new Account_Student(dao_tea.GetAccount(reader.GetString(5)));
                    token.State = reader.GetInt16(6);
                    // lsst ans
                    //List<Answer> lstans = dao_ansS.GetAll(token.StudentDo.Username + "/" + token.CodeContentLec, 3);
                    //foreach (Answer item in lstans)
                    //{
                    //    token.LstAnswer.Add(new Answer_Student(item, token.StudentDo));
                    //}
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
                    string sqlQuery = "Update Student_Exam Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update Student_Exam Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Student_Exam acc)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Student_Exam Set Content=@Content, [State]=@State 
                                where Self=@Self and TimeStudent_Exam=@TimeStudent_Exam";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        //cm.Parameters.AddWithValue("@Self", acc.Self);
                        //cm.Parameters.AddWithValue("@Content", acc.Content);
                        //cm.Parameters.AddWithValue("@TimeStudent_Exam", acc.TimeStudent_Exam);
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
