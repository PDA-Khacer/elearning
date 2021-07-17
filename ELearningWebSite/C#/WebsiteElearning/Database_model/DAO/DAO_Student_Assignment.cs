using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Student_Assignment
    {
        public DAO_Student_Assignment()
        {
            db_Uitl.Connect();
        }

        public void Add(Student_Assignment stuAss)
        {
            if (!Contain())
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into AssignmentStudent(CodeContentLec,LastUpdate,point,TeacherGive,TimeGivePoint,StudentOwns,[State]) " +
                "values ('@CodeContentLec','@LastUpdate,'@point,'@TeacherGive','@TimeGivePoint','@StudentOwns','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@LastUpdate", stuAss.LastUpdate);
                    cm.Parameters.AddWithValue("@point", stuAss.Point);
                    cm.Parameters.AddWithValue("@TeacherGive", stuAss.TeacherGive.Username);
                    cm.Parameters.AddWithValue("@TimeGivePoint", stuAss.TimeGive);
                    cm.Parameters.AddWithValue("@StudentOwns", stuAss.Owns.Username);
                    cm.Parameters.AddWithValue("@State", stuAss.State);
                    cm.ExecuteNonQuery();
                }
                // lay ra id ma vua add
                sqlQuery = @"select max(id) from AssignmentStudent";
                //sqlQuery = @"select id from AssignmentStudent where CodeContentLec=@CodeContentLec and StudentOwns=@StudentOwns";
                SqlCommand cm1 = new SqlCommand(sqlQuery, db_Uitl.Conn);
                SqlDataReader reader = cm1.ExecuteReader();
                reader.Read();
                int id = reader.GetInt16(0);
                reader.Close();
                // add all list
                foreach (FileSelf item in stuAss.LstFile)
                {
                    sqlQuery = "Insert into FileAssigemnt(CodeFile,CodeAssignmentStudent,Files,[State]) " +
                    "values ('@CodeFile','@CodeAssignmentStudent','@Files','@State')";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeFile", item.CodeFile);
                        cm.Parameters.AddWithValue("@CodeAssignmentStudent", id);
                        cm.Parameters.AddWithValue("@State", stuAss.State);
                        cm.ExecuteNonQuery();
                    }
                }
                foreach (Comment item in stuAss.LstComment)
                {
                    sqlQuery = "Insert into ContentLecComment(CodeContentLec,idComment,[State]) " +
                    "values ('@CodeContentLec','@idComment','@State')";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        // lay id comment
                        string sqlQuery1 = @"select id from [Comment] where Self='" + item.Self.Username + "' and TimeComment='" + item.TimeComment + "'";
                        SqlCommand cm2 = new SqlCommand(sqlQuery1, db_Uitl.Conn);
                        SqlDataReader reader1 = cm2.ExecuteReader();
                        reader1.Read();
                        int idComment = reader.GetInt16(0);
                        reader1.Close();
                        cm.Parameters.AddWithValue("@idComment", idComment);
                        cm.Parameters.AddWithValue("@State", stuAss.State);
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool Contain()
        {
            // kiểm tra file trùng ....
            return true;
        }

        public bool CheckReferences(int id1, int id2)
        {
            DAO_Account dao_acc = new DAO_Account();
            if (!dao_acc.Contain(id1))
                return false;
            if (!dao_acc.Contain(id2))
                return false;
            return true;
        }

        public List<Student_Assignment> GetAll()
        {
            try
            {
                List<Student_Assignment> ls = new List<Student_Assignment>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from AssignmentStudent";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Student_Assignment token = new Student_Assignment();
                        token.State = reader.GetInt16(7);
                        if (token.State == 1)
                        {

                            DAO_FileSelf dao_file = new DAO_FileSelf();
                            DAO_Comment dao_com = new DAO_Comment();
                            DAO_Account dao_acc = new DAO_Account();
                            DAO_Account dao_tea = new DAO_Account();

                            token.LastUpdate = reader.GetDateTime(2);
                            token.Point = reader.GetFloat(3);
                            token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                            token.TimeGive = reader.GetDateTime(5);
                            token.Owns = new Account_Student(dao_acc.GetAccount(reader.GetString(6)));
                            // lay ra cac list tuong ung
                            //token.LstComment = dao_com.GetAll(token.CodeContentLec, 2);
                            //string para1 = token.Owns.Username + '/' + token.CodeContentLec;
                            //token.LstFile = dao_file.GetAll(para1, 3);
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

        /// <summary>
        /// 1: contentLec
        /// 2: student
        /// 3: teacherGive
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Student_Assignment> GetAll(string id, int type)
        {
            try
            {
                List<Student_Assignment> ls = new List<Student_Assignment>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        sqlQuery = "Select * from AssignmentStudent where CodeContentLec ='" + id + "'";
                    }
                    else
                    {
                        if (type == 2)
                        {
                            sqlQuery = "Select * from AssignmentStudent where StudentOwns='" + id + "'";
                        }
                        else
                        {
                            sqlQuery = "Select * from AssignmentStudent where TeacherGive='" + id + "'";
                        }
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Student_Assignment token = new Student_Assignment();
                        token.State = reader.GetInt16(7);
                        if (token.State == 1)
                        {
                            DAO_FileSelf dao_file = new DAO_FileSelf();
                            DAO_Comment dao_com = new DAO_Comment();
                            DAO_Account dao_acc = new DAO_Account();
                            DAO_Account dao_tea = new DAO_Account();

                            token.LastUpdate = reader.GetDateTime(2);
                            token.Point = reader.GetFloat(3);
                            token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                            token.TimeGive = reader.GetDateTime(5);
                            token.Owns = new Account_Student(dao_acc.GetAccount(reader.GetString(6)));
                            // lay ra cac list tuong ung
                            //token.LstComment = dao_com.GetAll(token.CodeContentLec, 2);
                            //string para1 = token.Owns.Username + '/' + token.CodeContentLec;
                            //token.LstFile = dao_file.GetAll(para1, 3);
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

        public Student_Assignment GetStudent_Assignment(string codeContentLec, string username)
        {
            Student_Assignment token = new Student_Assignment();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from AssignmentStudent where CodeContentLec = '" + codeContentLec +
                        "' and StudentOwns='" + username + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        token.State = reader.GetInt16(7);
                        if (token.State == 1)
                        {
                            DAO_FileSelf dao_file = new DAO_FileSelf();
                            DAO_Comment dao_com = new DAO_Comment();
                            DAO_Account dao_acc = new DAO_Account();
                            DAO_Account dao_tea = new DAO_Account();

                            token.LastUpdate = reader.GetDateTime(2);
                            token.Point = reader.GetFloat(3);
                            token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                            token.TimeGive = reader.GetDateTime(5);
                            token.Owns = new Account_Student(dao_acc.GetAccount(reader.GetString(6)));
                            // lay ra cac list tuong ung
                            //token.LstComment = dao_com.GetAll(token.CodeContentLec, 2);
                            //string para1 = token.Owns.Username + '/' + token.CodeContentLec;
                            //token.LstFile = dao_file.GetAll(para1, 3);
                        }
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

        public Student_Assignment GetStudent_Assignment(int id)
        {
            Student_Assignment token = new Student_Assignment();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Student_Assignment where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.State = reader.GetInt16(7);
                    if (token.State == 1)
                    {
                        DAO_FileSelf dao_file = new DAO_FileSelf();
                        DAO_Comment dao_com = new DAO_Comment();
                        DAO_Account dao_acc = new DAO_Account();
                        DAO_Account dao_tea = new DAO_Account();
                        token.LastUpdate = reader.GetDateTime(2);
                        token.Point = reader.GetFloat(3);
                        token.TeacherGive = new Account_Teacher(dao_tea.GetAccount(reader.GetString(4)));
                        token.TimeGive = reader.GetDateTime(5);
                        token.Owns = new Account_Student(dao_acc.GetAccount(reader.GetString(6)));
                        // lay ra cac list tuong ung
                        //token.LstComment = dao_com.GetAll(token.CodeContentLec, 2);
                        //string para1 = token.Owns.Username + '/' + token.CodeContentLec;
                        //token.LstFile = dao_file.GetAll(para1, 3);
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
                    string sqlQuery = "Delete From Student_Assignment where username = N'" + id + "'";
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
                    string sqlQuery = "Delete From Student_Assignment where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Student_Assignment stuAss)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update AssignmentStudent Set LastUpdate=@LastUpdate, point=@point, TeacherGive=@TeacherGive,TimeGivePoint=@TimeGivePoint, [State]=@State 
                        where CodeContentLec=@CodeContentLec and StudentOwns=@StudentOwns";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@StudentOwns", stuAss.Owns.Username);
                        cm.Parameters.AddWithValue("@LastUpdate", stuAss.LastUpdate);
                        cm.Parameters.AddWithValue("@point", stuAss.Point);
                        cm.Parameters.AddWithValue("@TeacherGive", stuAss.TeacherGive.Username);
                        cm.Parameters.AddWithValue("@TimeGivePoint", stuAss.TimeGive);
                        cm.Parameters.AddWithValue("@State", stuAss.State);
                        cm.ExecuteNonQuery();
                    }
                    // update list
                    foreach (FileSelf item in stuAss.LstFile)
                    {
                        DAO_FileSelf dao_file = new DAO_FileSelf();
                        dao_file.Update(item);
                    }
                    foreach (Comment item in stuAss.LstComment)
                    {
                        DAO_Comment dao_com = new DAO_Comment();
                        dao_com.Update(item);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateFileStudent(Student_Assignment stuAss)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    foreach (FileSelf item in stuAss.LstFile)
                    {
                        DAO_FileSelf dao_file = new DAO_FileSelf();
                        dao_file.Update(item);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateComment(Student_Assignment stuAss)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    foreach (Comment item in stuAss.LstComment)
                    {
                        DAO_Comment dao_com = new DAO_Comment();
                        dao_com.Update(item);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdatePoint(Student_Assignment stuAss)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = @"Update AssignmentStudent Set LastUpdate=@LastUpdate, point=@point, TeacherGive=@TeacherGive,TimeGivePoint=@TimeGivePoint, [State]=@State 
                        where CodeContentLec=@CodeContentLec and StudentOwns=@StudentOwns";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@StudentOwns", stuAss.Owns.Username);
                        cm.Parameters.AddWithValue("@LastUpdate", stuAss.LastUpdate);
                        cm.Parameters.AddWithValue("@point", stuAss.Point);
                        cm.Parameters.AddWithValue("@TeacherGive", stuAss.TeacherGive.Username);
                        cm.Parameters.AddWithValue("@TimeGivePoint", stuAss.TimeGive);
                        cm.Parameters.AddWithValue("@State", stuAss.State);
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
