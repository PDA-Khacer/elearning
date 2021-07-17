using System;
using System.Data.SqlTypes;

namespace Website.Model
{
    public class Account_Student : Account
    {
        public Account_Student()
        {
            Role = "student";
            DayCreate = new SqlDateTime(DateTime.Now);
        }
        public Account_Student(Account acc)
        {
            Role = "student";
            DayCreate = new SqlDateTime(DateTime.Now);
            this.Username = acc.Username;
            this.BrithDay = acc.BrithDay;
            this.DayCreate = acc.DayCreate;
            this.EduMaill = acc.EduMaill;
            this.Email = acc.Email;
            this.FullName = acc.FullName;
            this.Gender = acc.Gender;
            this.Img = acc.Img;
            this.LstAnnoum = acc.LstAnnoum;
            this.Password = acc.Password;
            this.PhoneNumber = acc.PhoneNumber;
            this.State = acc.State;
        }
    }
}
