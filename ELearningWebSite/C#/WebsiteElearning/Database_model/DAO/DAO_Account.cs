
using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Database_model.DAO
{
    public class DAO_Account
    {
        public DAO_Account()
        {
            
        }

        public void Add(Account acc)
        {
            if (!Contain(acc.id))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Account (DayCreate,[Username],[Password],FullName,Img,BrithDay,Gender,Email,PhoneNumber,Role,[State]) " +
                    "values ('@DayCreate','@Username','@Password','@FullName','@Img','@BrithDay', '@Gender'" +
                    ", '@Email' ,'@PhoneNumber' ,'@Role' ,'@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@DayCreate", acc.DayCreate);
                    cm.Parameters.AddWithValue("@Username", acc.Username);
                    cm.Parameters.AddWithValue("@Password", acc.Password);
                    cm.Parameters.AddWithValue("@FullName", acc.FullName);
                    cm.Parameters.AddWithValue("@Img", acc.Img);
                    cm.Parameters.AddWithValue("@BrithDay", acc.BrithDay);
                    cm.Parameters.AddWithValue("@Gender", acc.Gender);
                    cm.Parameters.AddWithValue("@Email", acc.Email);
                    cm.Parameters.AddWithValue("@PhoneNumber", acc.PhoneNumber);
                    cm.Parameters.AddWithValue("@Role", acc.Role);
                    cm.Parameters.AddWithValue("@State", acc.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(int id)
        {
            foreach (Account item in GetAll())
            {
                if (id == item.id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Account> GetAll()
        {
            try
            {
                List<Account> ls = new List<Account>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Account token = new Account();
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        DAO_Announcement daoAnn = new DAO_Announcement();
                        token.LstAnnoum = daoAnn.GetAll(token.Username);
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

        public List<Account_Student> GetAllStudent()
        {
            try
            {
                List<Account_Student> ls = new List<Account_Student>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where role ='Student'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    Account_Student token = new Account_Student();
                    while (reader.Read())
                    {
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        reader.Close();
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

        public List<Account_Teacher> GetAllTeacher()
        {
            try
            {
                List<Account_Teacher> ls = new List<Account_Teacher>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where role ='Teacher'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    Account_Teacher token = new Account_Teacher();
                    while (reader.Read())
                    {
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        reader.Close();
                        DAO_Announcement dao_ann = new DAO_Announcement();
                        DAO_ContentLec dao_ctl = new DAO_ContentLec();
                        token.LstAnnoum = dao_ann.GetAll(token.Username);
                        token.LstLecSelf = dao_ctl.GetAll(token.Username, 2);
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
        ///  id: Username
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetAccount(string id)
        {
            Account token = new Account();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where [username] = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    if (reader != null)
                    {
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        reader.Close();
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Account_Admin GetAccountAdmin(string id)
        {
            Account_Admin token = new Account_Admin();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where [username] = N'" + id + "' and role ='Admin'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.DayCreate = reader.GetDateTime(1);
                    token.Username = reader.GetString(2);
                    token.Password = reader.GetString(3);
                    token.FullName = reader.GetString(4);
                    token.Img = reader.GetString(5);
                    token.BrithDay = reader.GetString(6);
                    token.Gender = reader.GetString(7);
                    token.Email = reader.GetString(8);
                    token.PhoneNumber = reader.GetString(9);
                    token.Role = reader.GetString(10);
                    token.State = reader.GetInt16(11);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Account_Student GetAccountStudent(string id)
        {
            Account_Student token = new Account_Student();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where [username] = N'" + id + "' and role ='Student'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.DayCreate = reader.GetDateTime(1);
                    token.Username = reader.GetString(2);
                    token.Password = reader.GetString(3);
                    token.FullName = reader.GetString(4);
                    token.Img = reader.GetString(5);
                    token.BrithDay = reader.GetString(6);
                    token.Gender = reader.GetString(7);
                    token.Email = reader.GetString(8);
                    token.PhoneNumber = reader.GetString(9);
                    token.Role = reader.GetString(10);
                    token.State = reader.GetInt16(11);
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

        public Account_Student GetAccountStudent(int id)
        {
            Account_Student token = new Account_Student();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where id = " + id + " and role ='Student'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.DayCreate = reader.GetDateTime(1);
                    token.Username = reader.GetString(2);
                    token.Password = reader.GetString(3);
                    token.FullName = reader.GetString(4);
                    token.Img = reader.GetString(5);
                    token.BrithDay = reader.GetString(6);
                    token.Gender = reader.GetString(7);
                    token.Email = reader.GetString(8);
                    token.PhoneNumber = reader.GetString(9);
                    token.Role = reader.GetString(10);
                    token.State = reader.GetInt16(11);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Account_Teacher GetAccountTeacher(string id)
        {
            Account_Teacher token = new Account_Teacher();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where [username] = N'" + id + "' and role ='Teacher'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.DayCreate = reader.GetDateTime(1);
                    token.Username = reader.GetString(2);
                    token.Password = reader.GetString(3);
                    token.FullName = reader.GetString(4);
                    token.Img = reader.GetString(5);
                    token.BrithDay = reader.GetString(6);
                    token.Gender = reader.GetString(7);
                    token.Email = reader.GetString(8);
                    token.PhoneNumber = reader.GetString(9);
                    token.Role = reader.GetString(10);
                    token.State = reader.GetInt16(11);
                    reader.Close();
                    DAO_Announcement dao_ann = new DAO_Announcement();
                    DAO_ContentLec dao_ctl = new DAO_ContentLec();
                    token.LstAnnoum = dao_ann.GetAll(token.Username);
                    token.LstLecSelf = dao_ctl.GetAll(token.Username, 2);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public Account_Teacher GetAccountTeacher(int id)
        {
            Account_Teacher token = new Account_Teacher();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where id = " + id + " and role ='Teacher'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.DayCreate = reader.GetDateTime(1);
                    token.Username = reader.GetString(2);
                    token.Password = reader.GetString(3);
                    token.FullName = reader.GetString(4);
                    token.Img = reader.GetString(5);
                    token.BrithDay = reader.GetString(6);
                    token.Gender = reader.GetString(7);
                    token.Email = reader.GetString(8);
                    token.PhoneNumber = reader.GetString(9);
                    token.Role = reader.GetString(10);
                    token.State = reader.GetInt16(11);
                    reader.Close();
                    DAO_Announcement dao_ann = new DAO_Announcement();
                    DAO_ContentLec dao_ctl = new DAO_ContentLec();
                    token.LstAnnoum = dao_ann.GetAll(token.Username);
                    token.LstLecSelf = dao_ctl.GetAll(token.Username, 2);
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
            }
            return token;
        }

        public List<Account_Student> GetStudentInClassCourse(int idClass)
        {
            try
            {
                List<Account_Student> ls = new List<Account_Student>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {

                    string sqlQuery = "Select Account.* from Account inner join " +
                     "(select * from ClassCourse_Student where CodeClass = "+idClass+") as b" +
                        " on Account.id = b.userStudent";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Account_Student token = new Account_Student();
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        DAO_Announcement daoAnn = new DAO_Announcement();
                        token.LstAnnoum = daoAnn.GetAll(token.Username);
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
    
        public List<Account_Student> FindStudentInClassCourse(int idClass, string name)
        {
            try
            {
                List<Account_Student> ls = new List<Account_Student>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {

                    string sqlQuery = "Select Account.* from " +
                        "Account " +
                        "inner join " +
                        "(select * from ClassCourse_Student where CodeClass = " + idClass + ") as b " +
                        " on Account.id = b.userStudent " +
                        " where Account.FullName Like N'%"+name+"%'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Account_Student token = new Account_Student();
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        DAO_Announcement daoAnn = new DAO_Announcement();
                        token.LstAnnoum = daoAnn.GetAll(token.Username);
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

        public List<Account_Student> FindStudent( string name)
        {
            try
            {
                List<Account_Student> ls = new List<Account_Student>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {

                    string sqlQuery = "Select * from  Account where FullName Like N'%"+name+"%' and role='Student'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Account_Student token = new Account_Student();
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        DAO_Announcement daoAnn = new DAO_Announcement();
                        token.LstAnnoum = daoAnn.GetAll(token.Username);
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

        public List<Account_Teacher> GetTeacherInClassCourse(int idClass)
        {
            try
            {
                List<Account_Teacher> ls = new List<Account_Teacher>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {

                    string sqlQuery = "Select Account.* from Account inner join " +
                     "(select * from ClassCourse_Teacher where CodeClass = " + idClass + ") as b" +
                        " on Account.id = b.userTeacher";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Account_Teacher token = new Account_Teacher();
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        DAO_Announcement daoAnn = new DAO_Announcement();
                        token.LstAnnoum = daoAnn.GetAll(token.Username);
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

        public List<Account_Teacher> FindTeacherInClassCourse(int idClass, string name)
        {
            try
            {
                List<Account_Teacher> ls = new List<Account_Teacher>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {

                    string sqlQuery = "Select Account.* from " +
                        "Account " +
                        "inner join " +
                        "(select * from ClassCourse_Teacher where CodeClass = " + idClass + ") as b" +
                        " on Account.id = b.userTeacher" +
                        " where Account.FullName Like N'%" + name + "%'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Account_Teacher token = new Account_Teacher();
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        DAO_Announcement daoAnn = new DAO_Announcement();
                        token.LstAnnoum = daoAnn.GetAll(token.Username);
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

        public List<Account_Teacher> FindTeacher(string name)
        {
            try
            {
                List<Account_Teacher> ls = new List<Account_Teacher>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {

                    string sqlQuery = "Select * from  Account where FullName Like N'%" + name + "%' and role='Teacher'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Account_Teacher token = new Account_Teacher();
                        token.id = reader.GetInt32(0);
                        token.DayCreate = reader.GetDateTime(1);
                        token.Username = reader.GetString(2);
                        token.Password = reader.GetString(3);
                        token.FullName = reader.GetString(4);
                        token.Img = reader.GetString(5);
                        token.BrithDay = reader.GetString(6);
                        token.Gender = reader.GetString(7);
                        token.Email = reader.GetString(8);
                        token.PhoneNumber = reader.GetString(9);
                        token.Role = reader.GetString(10);
                        token.State = reader.GetInt16(11);
                        DAO_Announcement daoAnn = new DAO_Announcement();
                        token.LstAnnoum = daoAnn.GetAll(token.Username);
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

        public Account GetAccount(int id)
        {
            Account token = new Account();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Account where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.DayCreate = reader.GetDateTime(1);
                    token.Username = reader.GetString(2);
                    token.Password = reader.GetString(3);
                    token.FullName = reader.GetString(4);
                    token.Img = reader.GetString(5);
                    token.BrithDay = reader.GetString(6);
                    token.Gender = reader.GetString(7);
                    token.Email = reader.GetString(8);
                    token.PhoneNumber = reader.GetString(9);
                    token.Role = reader.GetString(10);
                    token.State = reader.GetInt16(11);
                    reader.Close();
                    db_Uitl.Close();
                }
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
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
                    string sqlQuery = "Update Account Set [State]=1 where [username] = N'" + id + "'";
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
                    string sqlQuery = "Update Account Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(Account acc)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Account Set Password=@Password, FullName=@FullName, Img=@Img
                    , BrithDay=@BrithDay, Gender=@Gender, Email=@Email, PhoneNumber=@PhoneNumber, Role=@Role where, [State]=@State where [username]=@Username";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@Username", acc.Username);
                        cm.Parameters.AddWithValue("@Password", acc.Password);
                        cm.Parameters.AddWithValue("@FullName", acc.FullName);
                        cm.Parameters.AddWithValue("@Img", acc.Img);
                        cm.Parameters.AddWithValue("@BrithDay", acc.BrithDay);
                        cm.Parameters.AddWithValue("@Gender", acc.Gender);
                        cm.Parameters.AddWithValue("@Email", acc.Email);
                        cm.Parameters.AddWithValue("@PhoneNumber", acc.PhoneNumber);
                        cm.Parameters.AddWithValue("@Role", acc.Role);
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

        /// custom fuction
        /// 

        public bool CheckLogin(string username, string password)
        {
            bool re = false;
            try
            {
                if (!db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                }
                string sqlQuery = "Select * from Account where [Username] = N'" + username + "' and [Password] = '" + password + "'";
                SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                SqlDataReader reader = cm.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    re = true;
                }
                reader.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                db_Uitl.Conn.Close();
            }
            return re;
        }
        public void AddAccount(string username, string password, string hoten, string email, string quyen)
        {
            if (true)
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Account (DayCreate,[Username],[Password],FullName,Email,Role)" +
                    "values (@DayCreate,@Username,@Password,@FullName, @Email ,@Role)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@DayCreate",new SqlDateTime(DateTime.Now));
                    cm.Parameters.AddWithValue("@Username", username);
                    cm.Parameters.AddWithValue("@Password", password);
                    cm.Parameters.AddWithValue("@FullName", hoten);
                    cm.Parameters.AddWithValue("@Email", email);
                    cm.Parameters.AddWithValue("@Role", quyen);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
        }

        public void UpdateAccount(string username, string password, string hoten, string email, string quyen)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Account Set Password=@Password, FullName=@FullName,
                    Email=@Email, Role=@Role where [username]=@Username";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@Username", username);
                        cm.Parameters.AddWithValue("@Password", password);
                        cm.Parameters.AddWithValue("@FullName", hoten);
                        cm.Parameters.AddWithValue("@Email", email);
                        cm.Parameters.AddWithValue("@Role", quyen);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }       
            db_Uitl.Close();

        }

        public void DeleteAccount(string username)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = @"Delete Account where [username]="+username;
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            db_Uitl.Close();
        }
    }
}
 
