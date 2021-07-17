using Database_model.BUS;
using Database_model.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicesProject.ServicesWebASMX
{
    /// <summary>
    /// Summary description for Account_services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Account_services : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool CheckLogin(string username, string password)
        {
            Database_model.DAO.DAO_Account dao_Acc = new Database_model.DAO.DAO_Account();
            return dao_Acc.CheckLogin(username,password);
        }
        [WebMethod]
        public string getAllAccountSystem()
        {
            return JsonConvert.SerializeObject(new ListAccount(BUS_Account.GetAllAccount()));
        }
        [WebMethod]
        public void AddAccount(string username, string password, string hoten, string email, string quyen)
        {
            BUS_Account.AddAccount(username, password, hoten, email, quyen);
        }
        [WebMethod]
        public void updateAccount(string username, string password, string hoten, string email, string quyen)
        {
            BUS_Account.UpdateAccount(username, password, hoten, email, quyen);
        }
        [WebMethod]
        public void deleteAccount(string username)
        {
            BUS_Account.DeleteAccount(username);
        }
        
    }

}
