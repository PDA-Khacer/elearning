using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_TypeFile
    {
        public DAO_TypeFile()
        {
            db_Uitl.Connect();
        }

        public void Add(TypeFile acc)
        {
            if (!Contain(acc.CodeType))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into TypeFile(CodeType,NameType,Img,[State]) " +
                    "values ('@Self','@Content','@TimeTypeFile','@State')";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeType", acc.CodeType);
                    cm.Parameters.AddWithValue("@NameType", acc.Name);
                    cm.Parameters.AddWithValue("@Img", acc.Img);
                    cm.Parameters.AddWithValue("@State", acc.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(string CodeType)
        {
            foreach (TypeFile item in GetAll())
            {
                if (CodeType.Equals(item.CodeType))
                {
                    return true;
                }
            }
            return false;
        }

        public List<TypeFile> GetAll()
        {
            try
            {
                List<TypeFile> ls = new List<TypeFile>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from TypeFile";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        TypeFile token = new TypeFile();
                        token.CodeType = reader.GetString(1);
                        token.Name = reader.GetString(2);
                        token.State = reader.GetInt16(4);
                        token.Img = reader.GetString(3);
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

        public TypeFile GetTypeFile(string id)
        {
            TypeFile token = new TypeFile();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from TypeFile where CodeType = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeType = reader.GetString(1);
                    token.Name = reader.GetString(2);
                    token.State = reader.GetInt16(4);
                    token.Img = reader.GetString(3);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public TypeFile GetTypeFile(int id)
        {
            TypeFile token = new TypeFile();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from TypeFile where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeType = reader.GetString(1);
                    token.Name = reader.GetString(2);
                    token.State = reader.GetInt16(4);
                    token.Img = reader.GetString(3);
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
                    string sqlQuery = "Update TypeFile Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update TypeFile Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(TypeFile acc)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update TypeFile Set NameType=@NameType,Img=@Img, [State]=@State 
                                where CodeType=@CodeType ";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeType", acc.CodeType);
                        cm.Parameters.AddWithValue("@NameType", acc.Name);
                        cm.Parameters.AddWithValue("@Img", acc.Img);
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
