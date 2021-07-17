using Database_model.DB;
using Database_model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Database_model.DAO
{
    public class DAO_FileSelf
    {
        public DAO_FileSelf()
        {
            db_Uitl.Connect();
        }

        public void Add(FileSelf acc)
        {
            if (!Contain(acc.Self.Username) && CheckReferences(acc.Self.id, acc.TailFile.Name))
            {
                db_Uitl.Connect();
                string sqlQuery = "Insert into FileSelf(CodeFile,NameFile,Link,PathSave,Size,Self,typeFile,DayUpload,[State])" +
                    " values (@CodeFile,@NameFile,@Link,@PathSave,@Size,@Self,@typeFile,@DayUpload,@State)";
                using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                {
                    cm.CommandText = sqlQuery;
                    cm.Parameters.AddWithValue("@CodeFile", acc.CodeFile);
                    cm.Parameters.AddWithValue("@NameFile", acc.NameFile);
                    cm.Parameters.AddWithValue("@Link", acc.Link);
                    cm.Parameters.AddWithValue("@PathSave", acc.PathSave);
                    cm.Parameters.AddWithValue("@Size", acc.Size);
                    cm.Parameters.AddWithValue("@Self", acc.Self.Username);
                    cm.Parameters.AddWithValue("@typeFile", acc.TailFile.Name);
                    cm.Parameters.AddWithValue("@State", acc.State);
                    cm.ExecuteNonQuery();
                }
            }
        }

        public bool Contain(string id)
        {
            foreach (FileSelf item in GetAll())
            {
                if (id.Equals(item.CodeFile))
                {
                    return true;
                }
            }
            return false;
        }
        ///
        public bool CheckReferences(int idUser, string typeFile)
        {
            DAO_Account dao_acc = new DAO_Account();
            DAO_TypeFile dao_typeFile = new DAO_TypeFile();
            if (!dao_acc.Contain(idUser))
                return false;
            if (!dao_typeFile.Contain(typeFile))
                return false;
            return true;
        }

        public List<FileSelf> GetAll()
        {
            try
            {
                List<FileSelf> ls = new List<FileSelf>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery = "Select * from FileSelf";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        FileSelf token = new FileSelf();
                        token.CodeFile = reader.GetString(1);
                        token.NameFile = reader.GetString(2);
                        token.Link = reader.GetString(3);
                        token.PathSave = reader.GetString(4);
                        token.Size = reader.GetString(5);
                        DAO_Account dao_acc = new DAO_Account();
                        token.Self = dao_acc.GetAccount(reader.GetString(6));
                        token.DayUpLoad = reader.GetDateTime(7);
                        DAO_TypeFile dao_type = new DAO_TypeFile();
                        token.TailFile = dao_type.GetTypeFile(reader.GetString(8));
                        token.State = reader.GetInt16(9);
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
        /// 1: self
        /// 2: typeFile
        /// 3: fileAssignment (username + / +contentLec)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<FileSelf> GetAll(string id, int type)
        {
            try
            {
                List<FileSelf> ls = new List<FileSelf>();
                if (db_Uitl.isLive())
                {
                    db_Uitl.Connect();
                    string sqlQuery;
                    if (type == 1)
                    {
                        // user
                        sqlQuery = "Select * from [File] where self = '" + id + "'";
                    }
                    else
                    {
                        if (type == 2)
                        {
                            // typeFile
                            sqlQuery = "Select * from [File] where typeFile = '" + id + "'";
                        }
                        else
                        {
                            string usernameString = id.Split('/')[0];
                            string contentLecString = id.Split('/')[1];
                            sqlQuery = "select [File].* form " +
                                "(select CodeFile from AssignmentStudent,FileAssigemnt where AssignmentStudent.id=CodeAssignmentStudent) as a,[File] as b" +
                                "where a.codeFile = b.CodeFile";
                        }
                    }
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        FileSelf token = new FileSelf();
                        token.CodeFile = reader.GetString(1);
                        token.NameFile = reader.GetString(2);
                        token.Link = reader.GetString(3);
                        token.PathSave = reader.GetString(4);
                        token.Size = reader.GetString(5);
                        DAO_Account dao_acc = new DAO_Account();
                        token.Self = dao_acc.GetAccount(reader.GetString(6));
                        token.DayUpLoad = reader.GetDateTime(7);
                        DAO_TypeFile dao_type = new DAO_TypeFile();
                        token.TailFile = dao_type.GetTypeFile(reader.GetString(8));
                        token.State = reader.GetInt16(9);
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

        public FileSelf GetFileSelf(string id)
        {
            FileSelf token = new FileSelf();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from FileSelf where CodeFile = N'" + id + "'";
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeFile = reader.GetString(1);
                    token.NameFile = reader.GetString(2);
                    token.Link = reader.GetString(3);
                    token.PathSave = reader.GetString(4);
                    token.Size = reader.GetString(5);
                    DAO_Account dao_acc = new DAO_Account();
                    token.Self = dao_acc.GetAccount(reader.GetString(6));
                    token.DayUpLoad = reader.GetDateTime(7);
                    DAO_TypeFile dao_type = new DAO_TypeFile();
                    token.TailFile = dao_type.GetTypeFile(reader.GetString(8));
                    token.State = reader.GetInt16(9);
                    reader.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return token;
        }

        public FileSelf GetFileSelf(int id)
        {
            FileSelf token = new FileSelf();
            try
            {
                if (db_Uitl.isLive())
                {
                    string sqlQuery = "Select * from FileSelf where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    SqlDataReader reader = cm.ExecuteReader();
                    reader.Read();
                    token.CodeFile = reader.GetString(1);
                    token.NameFile = reader.GetString(2);
                    token.Link = reader.GetString(3);
                    token.PathSave = reader.GetString(4);
                    token.Size = reader.GetString(5);
                    DAO_Account dao_acc = new DAO_Account();
                    token.Self = dao_acc.GetAccount(reader.GetString(6));
                    token.DayUpLoad = reader.GetDateTime(7);
                    DAO_TypeFile dao_type = new DAO_TypeFile();
                    token.TailFile = dao_type.GetTypeFile(reader.GetString(8));
                    token.State = reader.GetInt16(9);
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
                    string sqlQuery = "Update FileSelf Set [State]=1 where username = N'" + id + "'";
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
                    string sqlQuery = "Update FileSelf Set [State]=1 where id = " + id;
                    SqlCommand cm = new SqlCommand(sqlQuery, db_Uitl.Conn);
                    cm.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void Update(FileSelf acc)
        {
            try
            {
                if (db_Uitl.isLive())
                {
                    // Update liên quan
                    // Update chính
                    string sqlQuery = @"Update FileSelf Set NameFile=@NameFile,Link=@Link,PathSave=@PathSave,Size=@Size,Self=@Self,DayUpload=@DayUpload,typeFile=@typeFile,[State]=@State 
                                where CodeFile=@CodeFile";
                    using (SqlCommand cm = db_Uitl.Conn.CreateCommand())
                    {
                        cm.CommandText = sqlQuery;
                        cm.Parameters.AddWithValue("@CodeFile", acc.CodeFile);
                        cm.Parameters.AddWithValue("@NameFile", acc.NameFile);
                        cm.Parameters.AddWithValue("@Link", acc.Link);
                        cm.Parameters.AddWithValue("@PathSave", acc.PathSave);
                        cm.Parameters.AddWithValue("@Size", acc.Size);
                        cm.Parameters.AddWithValue("@Self", acc.Self.Username);
                        cm.Parameters.AddWithValue("@typeFile", acc.TailFile.Name);
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
