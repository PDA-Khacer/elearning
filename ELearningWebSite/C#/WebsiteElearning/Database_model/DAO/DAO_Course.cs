using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_Course
    {
        public DAO_Course()
        {
            //db_Uitl.Connect();
        }

        public void Add(Course cou)
        {
            if (!Contain(cou.CodeCourse))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into Course(CodeCourse,NameCourse,[State]) " +
                    "values ('@CodeCourse','@NameCourse','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeCourse", cou.CodeCourse);
                    cm.Parameters.AddWithValue("@NameCourse", cou.NameCourse);
                    cm.Parameters.AddWithValue("@State", cou.State);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
        }

        public bool Contain(string id)
        {
            foreach (Course item in GetAll())
            {
                if (id.Equals(item.CodeCourse))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Course> GetAll()
        {
            try
            {
                List<Course> ls = new List<Course>();
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Course";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        Course token = new Course();
                        token.id = reader.GetInt32(0);
                        token.CodeCourse = reader.GetString(1);
                        token.NameCourse = reader.GetString(2);
                        token.State = reader.GetInt32(3);
                        DAO_ClassCourse dao_class = new DAO_ClassCourse();
                        token.LstClass = new ListClassCourse(dao_class.GetAll(token.id));
                        ls.Add(token);
                    }
                    reader.Close();
                }
                db_Uitl.Close();
                return ls;
            }
            catch (SqlException e)
            {
                db_Uitl.Close();
                Console.WriteLine(e);
                return null;
            }
        }

        public Course GetCourse(string id)
        {
            Course token = new Course();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Course where Self = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeCourse = reader.GetString(1);
                    token.NameCourse = reader.GetString(2);
                    token.State = reader.GetInt32(3);
                    DAO_ClassCourse dao_class = new DAO_ClassCourse();
                    token.LstClass = new ListClassCourse(dao_class.GetAll(token.id));
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
            db_Uitl.Close();
            return token;
        }

        public Course GetCourse(int id)
        {
            Course token = new Course();
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from Course where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.id = reader.GetInt32(0);
                    token.CodeCourse = reader.GetString(1);
                    token.NameCourse = reader.GetString(2);
                    token.State = reader.GetInt32(3);
                    DAO_ClassCourse dao_class = new DAO_ClassCourse();
                    token.LstClass = new ListClassCourse(dao_class.GetAll(token.id));
                    reader.Close();
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
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Update Course Set [State]=1 where username = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
        }

        public void Remove(int id)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // remove liên quan
                    // remove chính
                    string sqlQuery = "Update Course Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
                db_Uitl.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
        }

        public void Update(Course cou)
        {
            try
            {
                db_Uitl.Connect();
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update Course Set NameCourse=@NameCourse, [State]=@State 
                                where CodeCourse=@CodeCourse";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeCourse", cou.CodeCourse);
                        cm.Parameters.AddWithValue("@NameCourse", cou.NameCourse);
                        cm.Parameters.AddWithValue("@State", cou.State);
                        cm.ExecuteNonQuery();
                    }
                }
                db_Uitl.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                db_Uitl.Close();
            }
        }
    }
}
