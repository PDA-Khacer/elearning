using Database_model.DAO;
using Database_model.Model;
using System.Collections.Generic;

namespace Database_model.BUS
{
    public class BUS_Account
    {
        public static Account FindAccount(string query)
        {
            Account acc = new Account();
            DAO_Account dao_acc = new DAO_Account();
            acc = dao_acc.GetAccount(query);
            return acc;
        }

        public static bool checkAccount(string username, string password, int type = 1)
        {
            DAO_Account dao_acc = new DAO_Account();
            if (type == 1)
            {
                Account acc = dao_acc.GetAccount(username);
                if (acc.Password.Equals(password))
                    return true;
                else
                    return false;
            }
            else
            {
                return dao_acc.CheckLogin(username, password);
            }
        }

        public static Account_Student GetStudent(int id)
        {
            DAO_Account dao = new DAO_Account();
            return dao.GetAccountStudent(id);
        }

        public static Account_Teacher GetTeacher(int id)
        {
            DAO_Account dao = new DAO_Account();
            return dao.GetAccountTeacher(id);
        }

        public static List<Account_Student> GetAllStudent()
        {
            DAO_Account dao = new DAO_Account();
            return dao.GetAllStudent();
        }

        public static List<Account_Teacher> GetAllTeacher()
        {
            DAO_Account dao = new DAO_Account();
            return dao.GetAllTeacher();
        }

        public static List<Account> GetAllAccount()
        {
            DAO_Account dao = new DAO_Account();
            return dao.GetAll();
        }
        public static List<Account_Student> FindStudent(string key)
        {
            DAO_Account dao = new DAO_Account();
            return dao.FindStudent(key);
        }
        public static List<Account_Teacher> FindTeacher(string key)
        {
            DAO_Account dao = new DAO_Account();
            return dao.FindTeacher(key);
        }
        public static void AddAccount(string username, string password, string hoten, string email, string quyen)
        {
            DAO_Account dao = new DAO_Account();
            dao.AddAccount(username, password,  hoten, email, quyen);
        }
        public static void UpdateAccount(string username, string password, string hoten, string email, string quyen)
        {
            DAO_Account dao = new DAO_Account();
            dao.UpdateAccount(username, password, hoten, email, quyen);
        }
        public static void DeleteAccount(string username)
        {
            DAO_Account dao = new DAO_Account();
            dao.DeleteAccount(username);
        }
        


    }
}
