using Database_model.BUS;
using Database_model.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;


namespace ServicesProject.ServicesWebASMX
{
    /// <summary>
    /// Summary description for Admin_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Admin_Service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllCourse()
        {
            return JsonConvert.SerializeObject(new ListCourse(Bus_Course.getAllCourse()));    
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetCourse(int id)
        {
            return JsonConvert.SerializeObject(Bus_Course.getCourseFull(id));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllClassCourse()
        {
            return JsonConvert.SerializeObject(new ListClassCourse(BUS_ClassCourse.GetAllClassCourse()));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllClassCourseOfCourse(int id)
        {
            return JsonConvert.SerializeObject(new ListClassCourse(BUS_ClassCourse.GetAllClassOfCourse(id)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetClassCourse(int id)
        {
            return JsonConvert.SerializeObject(BUS_ClassCourse.GetAClassCourse(id));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAcountInClass(int idClass)
        {
            return JsonConvert.SerializeObject(BUS_ClassCourse.GetAllAccountInClass(idClass));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetStudentInSystem(int id)
        {
            return JsonConvert.SerializeObject(BUS_Account.GetStudent(id));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetTeacherInSystem(int id)
        {
            return JsonConvert.SerializeObject(BUS_Account.GetTeacher(id));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllStudentInSystem()
        {
            return JsonConvert.SerializeObject(new ListAccountStudent(BUS_Account.GetAllStudent()));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllTeacherInSystem()
        {
            return JsonConvert.SerializeObject(new ListAccountTeacher(BUS_Account.GetAllTeacher()));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllStudent(int idClass)
        {
            return JsonConvert.SerializeObject(new ListAccountStudent(BUS_ClassCourse.GetAllStudentInClass(idClass)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string GetAllTeacher(int idClass)
        {
            return JsonConvert.SerializeObject(new ListAccountTeacher(BUS_ClassCourse.GetAllTeacherInClass(idClass)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool AddStudentToClassCourse(int idClass,int idAccount)
        {
            return BUS_ClassCourse.AddAccountStudentToClass(idClass,idAccount);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool AddTeacherToClassCourse(int idClass, int idAccount)
        {
            return BUS_ClassCourse.AddAccountTeacherToClass(idClass, idAccount);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool RemoveStudentToClassCourse(int idClass, int idAccount)
        {
            return BUS_ClassCourse.RemoveAnAccountStudentToClass(idClass, idAccount);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool RemoveAllStudentToClassCourse(int idClass)
        {
            return BUS_ClassCourse.RemoveAllAccountStudentToClass(idClass);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool RemoveTeacherToClassCourse(int idClass, int idAccount)
        {
            return BUS_ClassCourse.RemoveAnAccountTeacherToClass(idClass, idAccount);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public bool RemoveAllTeacherToClassCourse(int idClass)
        {
            return BUS_ClassCourse.RemoveAllAccountTeacherToClass(idClass);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string FindStudentInSystem(string key)
        {
            return JsonConvert.SerializeObject(new ListAccountStudent(BUS_Account.FindStudent(key)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string FindTeacherInSystem(string key)
        {
            return JsonConvert.SerializeObject(new ListAccountTeacher(BUS_Account.FindTeacher(key)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string FindStudentInClass(int idClass, string key)
        {
            return JsonConvert.SerializeObject(new ListAccountStudent(BUS_ClassCourse.FindStudentInClass(idClass,key)));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string FindTeacherInClass(int idClass, string key)
        {
            return JsonConvert.SerializeObject(new ListAccountTeacher(BUS_ClassCourse.FindTeacherInClass(idClass,key)));
        }


    }
}
